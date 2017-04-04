﻿using UnityEngine;
using System.Collections;
using Entitas;
using System;
using System.Collections.Generic;

namespace Game
{
	public class WinSystem : ReactiveSystem<GameEntity>
	{
		public WinSystem(Contexts contexts) : base(contexts.game)
		{ }

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameWin, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.isGameWin;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			Debug.Log("Game End");
			foreach(var e in entities)
			{
				var player = e.gamePlayer.PlayerObject;
				Debug.Log(player.PlayerName + "(" + player.PlayerId + ") win");
			}
		}
	}

}
