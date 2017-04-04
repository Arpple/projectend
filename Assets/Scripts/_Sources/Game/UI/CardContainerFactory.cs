using UnityEngine;
using System.Collections.Generic;

namespace Game.UI
{
	public abstract class CardContainerFactory<T> : MonoBehaviour where T : CardContainer
	{
		public T ContainerPrefabs;
		public Dictionary<int, T> AllContainers;
		public GameObject CreatingObjectParent;

		public T CreateContainer(string containerName, int playerId)
		{
			var container = Instantiate(ContainerPrefabs);
			container.Init();
			container.name = containerName + " " + playerId;
			container.transform.SetParent(CreatingObjectParent.transform, false);

			AllContainers.Add(playerId, container);
			container.gameObject.SetActive(false);

			return container;
		}

		public virtual void Init()
		{
			AllContainers = new Dictionary<int, T>();
			CreatingObjectParent = CreatingObjectParent ?? gameObject;
		}
	}
}
