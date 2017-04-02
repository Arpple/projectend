using Entitas;
using Entitas.CodeGenerator.Api;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;
using System.Linq;

namespace End.Game
{
	[Game, Unique]
	public class PlayingOrderComponent : IComponent
	{
		public List<short> PlayerOrder;

		private int _turn;
		private int _round;

		public int CurrentPlayerId
		{
			get { return PlayerOrder[_turn - 1]; }
		}

		public void Initialize()
		{
			_turn = 1;
			_round = 1;
		}

		/// <summary>
		/// Cycle the playing order and get player id
		/// </summary>
		/// <returns>next playing playerId</returns>
		public int GetNextPlayerId()
		{
			Assert.IsNotNull(PlayerOrder);
			Assert.IsTrue(PlayerOrder.Count > 0);

			//end round
			if(_turn == PlayerOrder.Count)
			{
				var first = PlayerOrder.First();
				PlayerOrder.RemoveAt(0);
				PlayerOrder.Add(first);

				_turn = 0;
				_round++;
			}

			_turn++;
			Assert.IsTrue(_turn > 0 && _turn <= PlayerOrder.Count);

			return CurrentPlayerId;

		}

		public override string ToString()
		{
			return "R:" + _round + ", T:" + _turn;
		}
	}
}
