using System.Collections.Generic;
using UnityEditor;

namespace Entitas.Unity.Blueprints {

    public class JsonBlueprintPostprocessor : AssetPostprocessor {

        public const string ASSET_LABEL = "EntitasJsonBlueprint";

        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromPath) {
            foreach(string assetPath in importedAssets) {
                var asset = AssetDatabase.LoadAssetAtPath<JsonBlueprint>(assetPath);
                if(asset != null) {
                    var labels = new List<string>(AssetDatabase.GetLabels(asset));
                    if(!labels.Contains(ASSET_LABEL)) {
                        labels.Add(ASSET_LABEL);
                        AssetDatabase.SetLabels(asset, labels.ToArray());
                    }
                }
            }
        }
    }
}
