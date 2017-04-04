using System.Linq;
using Entitas.CodeGenerator;

namespace Entitas.Unity.Blueprints {

    public class JsonBlueprintDataProvider : ICodeGeneratorDataProvider {

        public string name { get { return "Json Blueprint"; } }
        public bool isEnabledByDefault { get { return true; } }

        readonly string[] _blueprintNames;

        public JsonBlueprintDataProvider() {
            _blueprintNames = JsonBlueprintInspector
                .FindAllBlueprints()
                .Select(b => b.Deserialize().name)
                .ToArray();
        }

        public CodeGeneratorData[] GetData() {
            return _blueprintNames
                .Select(blueprintName => {
                    var data = new JsonBlueprintData();
                    data.SetBlueprintName(blueprintName);
                    return data;
                }).ToArray();
        }
    }

    public static class JsonBlueprintDataProviderExtension {

        public const string BLUEPRINT_NAME = "jsonBlueprint_name";

        public static string GetBlueprintName(this JsonBlueprintData data) {
            return (string)data[BLUEPRINT_NAME];
        }

        public static void SetBlueprintName(this JsonBlueprintData data, string blueprintName) {
            data[BLUEPRINT_NAME] = blueprintName;
        }
    }
}