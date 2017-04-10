using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Entitas.VisualDebugging.Unity.Editor;
using Entitas.Utils;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Entitas.Blueprints.Unity
{

    [CustomEditor(typeof(JsonBlueprint))]
    public class JsonBlueprintInspector : UnityEditor.Editor {

        public static JsonBlueprint[] FindAllBlueprints() {
            return AssetDatabase.FindAssets("l:" + JsonBlueprintPostprocessor.ASSET_LABEL)
                .Select(guid => AssetDatabase.GUIDToAssetPath(guid))
                .Select(path => AssetDatabase.LoadAssetAtPath<JsonBlueprint>(path))
                .ToArray();
        }

        [DidReloadScripts, MenuItem("Entitas/Blueprints/Update all Json Blueprints", false, 300)]
        public static void UpdateAllJsonBlueprints() {
            if(!EditorApplication.isPlayingOrWillChangePlaymode) {
                var allContexts = findAllContexts();
                if(allContexts == null) {
                    return;
                }

                var jsonBlueprints = FindAllBlueprints();
                var allContextNames = allContexts.Select(context => context.contextInfo.name).ToArray();
                var updated = 0;
                foreach(var jsonBlueprint in jsonBlueprints) {
                    var didUpdate = UpdateJsonBlueprint(jsonBlueprint, allContexts, allContextNames);
                    if(didUpdate) {
                        updated += 1;
                    }
                }

                if(updated > 0) {
                    Debug.Log("Validated " + jsonBlueprints.Length + " Blueprints, " + updated + " have been updated.");
                }
            }
        }
        
        public static bool UpdateJsonBlueprint(JsonBlueprint jsonBlueprint, IContext[] allContexts, string[] allContextNames) {
            var blueprint = jsonBlueprint.Deserialize();
        
            var needsUpdate = false;
            var needsRebuild = false;
            
            var contextIndex = Array.IndexOf(allContextNames, blueprint.contextIdentifier);
            if(contextIndex < 0) {
                contextIndex = 0;
                needsUpdate = true;
            }

            var context = allContexts[contextIndex];
            blueprint.contextIdentifier = context.contextInfo.name;

            foreach(var component in blueprint.components) {
                var type = component.fullTypeName.ToType();
                var index = Array.IndexOf(context.contextInfo.componentTypes, type);

                if(index != component.index) {

                    if (index > -1) {
                    Debug.Log(string.Format(
                        "Blueprint '{0}' has invalid or outdated component index for '{1}'. Index was {2} but should be {3}. Updated index.",
                        blueprint.name, component.fullTypeName, component.index, index));
                    }
                    else {
                    needsRebuild = true;
                    Debug.Log(string.Format(
                        "Blueprint '{0}' has invalid or outdated component index for '{1}'. Index was {2} but this component should be removed, it no longer exists. Rebuilding Blueprint.",
                        blueprint.name, component.fullTypeName, component.index));
                    }

                    component.index = index;
                    needsUpdate = true;
                }
            }

            if(needsUpdate) {
                Debug.Log("Updating Json Blueprint '" + blueprint.name + "'");
                if (needsRebuild) {
                    List<ComponentBlueprint> clist = new List<ComponentBlueprint>();
                    foreach (var component in blueprint.components){
                        var type = component.fullTypeName.ToType();
                        if(context.contextInfo.componentTypes.Contains(type)){
                            clist.Add(component);
                        }
                    }
                    blueprint.components = clist.ToArray();
                }
                jsonBlueprint.Serialize(blueprint);
            }

            return needsUpdate;
        }

        static IContext[] findAllContexts() {
            var contextsType = AppDomain.CurrentDomain
				.GetNonAbstractTypes<IContexts>()
                .SingleOrDefault();

            if(contextsType != null) {
                var contexts = (IContexts)Activator.CreateInstance(contextsType);
                return contexts.allContexts;
            }

            return null;
        }

        Blueprint _blueprint;

        IContext[] _allContexts;
        string[] _allContextNames;
        int _contextIndex;

        IContext _context;
        IEntity _entity;

        void Awake() {
            _allContexts = findAllContexts();
            if(_allContexts == null) {
                return;
            }

            var jsonBlueprint = ((JsonBlueprint)target);

            _allContextNames = _allContexts.Select(context => context.contextInfo.name).ToArray();

            UpdateJsonBlueprint(jsonBlueprint, _allContexts, _allContextNames);

            _blueprint = jsonBlueprint.Deserialize();

            AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(target), _blueprint.name);

            _contextIndex = Array.IndexOf(_allContextNames, _blueprint.contextIdentifier);
            switchToContext();

            _entity.ApplyBlueprint(_blueprint);

            // Serialize in case the structure of a component changed, e.g. field got removed
            jsonBlueprint.Serialize(_entity);
        }

        void OnDisable() {
            if(_context != null) {
                _context.Reset();
            }
        }

        public override void OnInspectorGUI() {
            var jsonBlueprint = ((JsonBlueprint)target);

            EditorGUI.BeginChangeCheck();
            {
                EditorGUILayout.LabelField("Blueprint", EditorStyles.boldLabel);
                jsonBlueprint.name = EditorGUILayout.TextField("Name", jsonBlueprint.name);

                if(_context != null) {
                    EditorGUILayout.BeginHorizontal();
                    {
                        _contextIndex = EditorGUILayout.Popup(_contextIndex, _allContextNames);

                        if(GUILayout.Button("Switch Context")) {
                            switchToContext();
                        }
                    }
                    EditorGUILayout.EndHorizontal();

                    EntityDrawer.DrawComponents(_context, _entity);
                } else {
                    EditorGUILayout.LabelField("No contexts found!");
                }
            }
            var changed = EditorGUI.EndChangeCheck();
            if(changed) {
                jsonBlueprint.Serialize(_entity);
                AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(target), jsonBlueprint.name);
                EditorUtility.SetDirty(target);
            }
        }

        void switchToContext() {
            if(_context != null) {
                _context.Reset();
            }
            var targetContext = _allContexts[_contextIndex];
            _context = (IContext)Activator.CreateInstance(targetContext.GetType());
            _entity = (IEntity)_context.GetType().GetMethod("CreateEntity").Invoke(_context, null);
        }
    }
}
