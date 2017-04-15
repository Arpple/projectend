using System.Collections.Generic;
using System.Linq;
using Entitas;
using Entitas.CodeGeneration.Attributes;


[Game, Unique]
public class PlayingOrderComponent : IComponent
{
	public List<GameEntity> PlayerOrder;
}
