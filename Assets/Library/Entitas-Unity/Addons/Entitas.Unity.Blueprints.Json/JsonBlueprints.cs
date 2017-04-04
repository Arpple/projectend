using System.Collections.Generic;
using Entitas.Blueprints;
using UnityEngine;

namespace Entitas.Unity.Blueprints {

    [CreateAssetMenu(menuName = "Entitas/Json Blueprints", fileName = "Json Blueprints.asset")]
    public class JsonBlueprints : ScriptableObject {

        public JsonBlueprint[] blueprints;

        Dictionary<string, JsonBlueprint> _jsonBlueprintsMap;

        #if(!UNITY_EDITOR)
        Dictionary<string, Blueprint> _blueprintsMap;
        #endif

        void OnEnable() {
            if(blueprints == null) {
                blueprints = new JsonBlueprint[0];
            }

            _jsonBlueprintsMap = new Dictionary<string, JsonBlueprint>(blueprints.Length);
            #if(!UNITY_EDITOR)
            _blueprintsMap = new Dictionary<string, Blueprint>(blueprints.Length);
            #endif

            for (int i = 0; i < blueprints.Length; i++) {
                var blueprint = blueprints[i];
                if(blueprint != null) {
                    _jsonBlueprintsMap.Add(blueprint.name, blueprint);
                }
            }
        }

        #if(UNITY_EDITOR)

        public Blueprint GetBlueprint(string name) {
            JsonBlueprint jsonBlueprint;
            if(!_jsonBlueprintsMap.TryGetValue(name, out jsonBlueprint)) {
                throw new JsonBlueprintsNotFoundException(name);
            }

            return jsonBlueprint.Deserialize();
        }

        #else

        public Blueprint GetBlueprint(string name) {
            Blueprint blueprint;
            if(!_blueprintsMap.TryGetValue(name, out blueprint)) {
                JsonBlueprint jsonBlueprint;
                if(_jsonBlueprintsMap.TryGetValue(name, out jsonBlueprint)) {
                    blueprint = jsonBlueprint.Deserialize();
                    _blueprintsMap.Add(name, blueprint);
                } else {
                    throw new JsonBlueprintsNotFoundException(name);
                }
            }

            return blueprint;
        }

        #endif
    }
}
