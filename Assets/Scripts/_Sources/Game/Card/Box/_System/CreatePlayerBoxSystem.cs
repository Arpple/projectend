﻿using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace End.Game
{
	public class CreatePlayerBoxSystem : ReactiveSystem<GameEntity>
	{
		public CreatePlayerBoxSystem(Contexts contexts)
			: base(contexts.game)
		{

		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Player, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasPlayer;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var e in entities)
			{
				//TODO: replace temp gameobject with created playercard object
				var temp = new GameObject("box");
				e.AddPlayerBox(temp);
			}
		}
	}

}