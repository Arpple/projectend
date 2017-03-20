using Entitas;
using Entitas.CodeGenerator.Api;
using System.Collections.Generic;

namespace End.Game
{
	[Game, Unique]
	public class PlayingOrderComponent : IComponent
	{
		public int[] PlayerIdOrder;

		private int _turn;
		private int _round;
	}
}
