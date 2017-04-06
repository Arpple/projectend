using Entitas;
using Entitas.CodeGenerator.Api;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;
using System.Linq;

namespace Game
{
	[Game, Unique]
	public class PlayingOrderComponent : IComponent
	{
		public List<GameEntity> PlayerOrder;

		private int _turn;
		private int _round;

		public GameEntity CurrentPlayer
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
		public GameEntity GetNextPlayerEntity()
		{
			Assert.IsNotNull(PlayerOrder);
			Assert.IsTrue(PlayerOrder.Count > 0);

			if(IsRoundEnd())
			{
				EndRound();
			}
			_turn++;

			Assert.IsTrue(_turn > 0 && _turn <= PlayerOrder.Count);

			return CurrentPlayer;
		}

		public override string ToString()
		{
			return "R:" + _round + ", T:" + _turn + ", P:" + CurrentPlayer.gamePlayer.PlayerId;
		}

		private bool IsRoundEnd()
		{
			return _turn == PlayerOrder.Count;
		}

		private void EndRound()
		{
			var first = PlayerOrder.First();
			PlayerOrder.RemoveAt(0);
			PlayerOrder.Add(first);

			_turn = 0;
			_round++;
		}
	}
}
