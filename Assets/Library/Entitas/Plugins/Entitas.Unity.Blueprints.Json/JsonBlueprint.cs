using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Entitas.Blueprints;
using UnityEngine;
using FullSerializer;

namespace Entitas.Blueprints.Unity
{

    [CreateAssetMenu(menuName = "Entitas/Json Blueprint", fileName = "New Json Blueprint.asset")]
    public class JsonBlueprint : ScriptableObject {

        public string blueprintData;

		private fsSerializer _serializer;

		public void OnEnable()
		{
			_serializer = new fsSerializer();
		}

		public Blueprint Deserialize() {
            Blueprint blueprint;
            if(blueprintData == null || blueprintData.Length == 0) {
                blueprint = new Blueprint(string.Empty, "New Json Blueprint", null);
            } else {
				object deserialize = null;
				var fsData = fsJsonParser.Parse(blueprintData);
				_serializer.TryDeserialize(fsData, typeof(Blueprint), ref deserialize).AssertSuccessWithoutWarnings();
				blueprint = deserialize as Blueprint;
            }

            name = blueprint.name;
            return blueprint;
        }

        public void Serialize(IEntity entity) {
            var blueprint = new Blueprint(entity.contextInfo.name, name, entity);
            Serialize(blueprint);
        }

        public void Serialize(Blueprint blueprint) {
			fsData data;
			_serializer.TrySerialize(typeof(Blueprint), blueprint, out data).AssertSuccessWithoutWarnings();
			blueprintData = data.ToString();
        }
    }
}
