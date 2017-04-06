﻿using UnityEngine;
using System.Collections;
using Entitas;

namespace Game
{
	public class EntityIdGenerator
	{
		internal class ContextEntityIdGenerator
		{
			private int _id;

			public ContextEntityIdGenerator()
			{
				_id = 0;
			}

			public int GenerateId()
			{
				return _id++;
			}
		}

		private ContextEntityIdGenerator _gameGen;
		private ContextEntityIdGenerator _tileGen;
		private ContextEntityIdGenerator _cardGen;

		public EntityIdGenerator(Contexts contexts)
		{
			_gameGen = new ContextEntityIdGenerator();
			_tileGen = new ContextEntityIdGenerator();
			_cardGen = new ContextEntityIdGenerator();

			contexts.game.OnEntityCreated += GenerateGameId;
			contexts.tile.OnEntityCreated += GenerateTileId;
			contexts.card.OnEntityCreated += GenerateCardId;
		}

		public void GenerateGameId(IContext context, IEntity entity)
		{
			var e = (GameEntity)entity;
			e.AddGameId(_gameGen.GenerateId());
		}

		public void GenerateTileId(IContext context, IEntity entity)
		{
			var e = (TileEntity)entity;
			e.AddGameId(_tileGen.GenerateId());
		}

		public void GenerateCardId(IContext context, IEntity entity)
		{
			var e = (CardEntity)entity;
			e.AddGameId(_cardGen.GenerateId());
		}
	}
}
