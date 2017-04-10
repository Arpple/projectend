using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game
{
	/// <summary>
	/// Abstract GameEvent class.
	/// more detail is commented in class
	/// </summary>
	public abstract class GameEventComponent : IComponent
	{
		// to send data across network
		// we will encode class variable into integer
		// should create a static method like this
		//! public static CreateThisClassEvent(ClassT1 arg1, ClassT2 arg2, ...)
		// {
		//     GameEvent.CreateEvent<ThisType>((int)arg1, (int)arg2, ...)
		// }

		// to received data from network
		// we will decode integer paramter into class variable
		// with method name `Decode` which will be called  by reflection
		//! public method Decode(int...)
		// { assigned int into class variable }
	}
}