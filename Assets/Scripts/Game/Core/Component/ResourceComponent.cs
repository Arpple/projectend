using Entitas;
using UnityEngine;
using Entitas.CodeGenerator.Api;

namespace End
{
	[Game]
	public class ResourceComponent : IComponent
	{
		public string SpritePath;
		public string BasePrefabsPath;
	}
}

