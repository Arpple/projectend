using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas.CodeGeneration.Attributes;


[Game, Unique]
public class PlayingOrderComponent : IComponent
{
	public List<GameEntity> PlayerOrder;

	public void ReOrder()
	{
		var first = PlayerOrder.First();
		PlayerOrder.RemoveAt(0);
		PlayerOrder.Add(first);
	}
}
