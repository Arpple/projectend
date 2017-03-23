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
		public List<short> PlayerIdOrder;

		private int _turn;
		private int _round;

		public int CurrentPlayerId
		{
			get { return PlayerIdOrder[_turn - 1]; }
		}

		public void Initialize()
		{
			_turn = 1;
			_round = 1;
			Debug.Log("Current R:" + _round + " T:" + _turn);
		}

		/// <summary>
		/// Cycle the playing order
		/// </summary>
		/// <returns>next playing playerId</returns>
		public int NextPlayerId()
		{
			Assert.IsNotNull(PlayerIdOrder);
			Assert.IsTrue(PlayerIdOrder.Count > 0);

			//end round
			if(_turn == PlayerIdOrder.Count)
			{
				var first = PlayerIdOrder.First();
				PlayerIdOrder.RemoveAt(0);
				PlayerIdOrder.Add(first);

				_turn = 0;
				_round++;
			}

			_turn++;
			Assert.IsTrue(_turn > 0 && _turn <= PlayerIdOrder.Count);

			Debug.Log("Current R:" + _round + " T:" + _turn);

			return CurrentPlayerId;

		}

		public override string ToString()
		{
			return "R:" + _round + ", T:" + _turn;
		}
	}
}
