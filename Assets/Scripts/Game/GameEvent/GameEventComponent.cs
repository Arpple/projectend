using Entitas;
using Entitas.CodeGenerator.Api;
using UnityEngine;
using System.Linq;

namespace End.Game
{
	/// <summary>
	/// Abstract GameEvent class.
	/// more detail is commented in class
	/// </summary>
	[DontGenerate]
	public abstract class GameEventComponent : IComponent
	{
		// to send data across network
		// we will encode class variable into integer
		// should create a static method like this
		//! public static CreateThisClassEvent(ClassT1 arg1, ClassT2 arg2, ...)
		// {
		//     GameEventHelper.CreateEvent<ThisType>((int)arg1, (int)arg2, ...)
		// }

		// to received data from network
		// we will decode integer paramter into class variable
		// with method name `Decode` which will be called  by reflection
		//! public method Decode(int...)
		// { assigned int into class variable }
	}

	public static class GameEventHelper
	{
		public static void CreateEvent<T>(params int[] args) where T : GameEventComponent
		{
			int componentId = GameEventComponentsLookup.componentTypes.ToList().IndexOf(typeof(T));
			if(GameController.IsOffline)
			{
				CreateEventAndDecode(componentId, args);
			}
			else
			{
				GameController.LocalPlayer.CmdCreateEvent(componentId, args);
			}
		}

		public static GameEventEntity CreateEventAndDecode(int componentId, params int[] args)
		{
			//create entity and component
			var entity = Contexts.sharedInstance.gameEvent.CreateEntity();
			IComponent component = entity.CreateComponent(componentId, GameComponentsLookup.componentTypes[componentId]);
			entity.AddComponent(componentId, component);

			//decode integer to component variable
			//by calling Decode(int...)
			if (args.Length > 0)
			{
				var decodeFn = GameEventComponentsLookup.componentTypes[componentId].GetMethods()
				.Where(m => m.Name == "Decode")	//! GameEventComponent should have this method
				.Where(m => m.GetParameters().Count() == args.Length)
				.FirstOrDefault();

				if (decodeFn != null)
				{
					object[] param = args.Cast<object>().ToArray();
					decodeFn.Invoke(entity.GetComponent(componentId), param);
				}
			}

			return entity;
		}
	}
}