namespace Entitas.Unity.Blueprints {

    public class JsonBlueprintsNotFoundException : EntitasException {

        public JsonBlueprintsNotFoundException(string blueprintName)
            : base("'" + blueprintName + "' does not exist!", "Did you update the Json Blueprints ScriptableObject?") {
        }
    }
}