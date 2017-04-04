using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Entitas;

namespace Game
{
	public static class GameEvent
	{
		public static void CreateEvent<T>(params int[] args) where T : GameEventComponent
		{
			int componentId = GameEventComponentsLookup.componentTypes.ToList().IndexOf(typeof(T));
			if (GameController.Instance != null && !GameController.Instance.IsOffline)
			{
				//Debug.Log("Create Online Event " + typeof(T).ToString());
				Contexts.sharedInstance.game.localPlayerEntity.player.PlayerObject.CmdCreateEvent(componentId, args);
			}
			else
			{
				//Debug.Log("Create Local Event " + typeof(T).ToString());
				CreateEventEntityAndDecode(componentId, args);
			}
		}

		public static GameEventEntity CreateEventEntityAndDecode(int componentId, params int[] args)
		{
			//create entity and component
			var entity = Contexts.sharedInstance.gameEvent.CreateEntity();
			IComponent component = entity.CreateComponent(componentId, GameEventComponentsLookup.componentTypes[componentId]);
			entity.AddComponent(componentId, component);

			//decode integer to component variable
			//by calling Decode(int...)
			if (args.Length > 0)
			{
				var decodeFn = GameEventComponentsLookup.componentTypes[componentId].GetMethods()
				.Where(m => m.Name == "Decode") //! GameEventComponent should have this method
				.Where(m => m.GetParameters().Count() == args.Length)
				.FirstOrDefault();

				if (decodeFn != null)
				{
					object[] param = args.Cast<object>().ToArray();
					decodeFn.Invoke((GameEventComponent)entity.GetComponent(componentId), param);
				}
			}

			return entity;
		}
	}
}
