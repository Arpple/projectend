﻿using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game.UI
{
	public class SkillCardContainerRenderingSystem : ReactiveSystem<CardEntity>, IInitializeSystem
	{
		private GameContext _gameContext;
		private PlayerSkillFactory _factory;

		public SkillCardContainerRenderingSystem(Contexts contexts, PlayerSkillFactory factory) : base(contexts.card)
		{
			_gameContext = contexts.game;
			_factory = factory;
		}

		protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
		{
			return context.CreateCollector(CardMatcher.GameSkillCard);
		}

		protected override bool Filter(CardEntity entity)
		{
			return entity.isGameSkillCard;
		}

		protected override void Execute(List<CardEntity> entities)
		{
			foreach(var e in entities)
			{
				e.gameOwner.Entity.gameSkillCardContainer.ContainerObject.AddCard(e.gameView.GameObject);
			}
		}

		public void Initialize()
		{
			foreach(var p in _gameContext.GetEntities(GameMatcher.GamePlayer))
			{
				var cont = _factory.CreateContainer(p.gamePlayer.PlayerId);
				p.AddGameSkillCardContainer(cont);
				if (p.isGameLocal) cont.gameObject.SetActive(true);
			}
		}
	}

}