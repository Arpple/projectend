using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game.UI
{
	public class PlayerSkillCardUISystem : ReactiveSystem<GameEntity>, IInitializeSystem
	{
		private GameContext _context;
		private PlayerSkillFactory _factory;

		public PlayerSkillCardUISystem(Contexts contexts, PlayerSkillFactory factory) : base(contexts.game)
		{
			_context = contexts.game;
			_factory = factory;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameSkillCard);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.isGameSkillCard;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				e.gamePlayerCard.OwnerEntity.gameUIPlayerSkillCardUI.ContainerObject.AddCard(e.gameView.GameObject);
			}
		}

		public void Initialize()
		{
			foreach(var p in _context.GetEntities(GameMatcher.GamePlayer))
			{
				var cont = _factory.CreateContainer(p.gamePlayer.PlayerId);
				p.AddGameUIPlayerSkillCardUI(cont);
				if (p.isGameLocalPlayer) cont.gameObject.SetActive(true);
			}
		}
	}

}
