using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace End.Game.UI
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
			return context.CreateCollector(GameMatcher.SkillCard);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.isSkillCard;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				e.playerCard.OwnerEntity.playerSkillCardUI.ContainerObject.AddCard(e.view.GameObject);
			}
		}

		public void Initialize()
		{
			foreach(var p in _context.GetEntities(GameMatcher.Player))
			{
				var cont = _factory.CreateContainer(p.player.PlayerId);
				p.AddPlayerSkillCardUI(cont);
				if (p.isLocalPlayer) cont.gameObject.SetActive(true);
			}
		}
	}

}
