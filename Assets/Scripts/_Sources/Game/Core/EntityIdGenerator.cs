using UnityEngine;
using System.Collections.Generic;
using Entitas;
using System;

namespace Game
{
	public class EntityIdGenerator
	{
		internal class ContextEntityIdGenerator
		{
			private int _id;
			private int _index;

			public ContextEntityIdGenerator(int componentIndex)
			{
				_id = 0;
				_index = componentIndex;
			}

			public void GenerateId(IEntity entity)
			{
				IdComponent component = entity.CreateComponent(_index, typeof(IdComponent)) as IdComponent;
				component.Id = _id++;

				entity.AddComponent(_index, component);
			}
		}

		private Dictionary<Type, ContextEntityIdGenerator> _generators;

		public EntityIdGenerator(Contexts contexts)
		{
			_generators = new Dictionary<Type, ContextEntityIdGenerator>();

			//! add this when create new context
			CreateGenerator<GameEntity>(contexts.game, GameComponentsLookup.GameId);
			CreateGenerator<TileEntity>(contexts.tile, TileComponentsLookup.GameId);
			CreateGenerator<CardEntity>(contexts.card, CardComponentsLookup.GameId);
			CreateGenerator<UnitEntity>(contexts.unit, UnitComponentsLookup.GameId);
		}

		private void CreateGenerator<TEntity>(IContext context, int idComponentIndex) where TEntity : class, IEntity, new()
		{
			_generators.Add(typeof(TEntity), new ContextEntityIdGenerator(idComponentIndex));
			context.OnEntityCreated += (c, e) => GenerateId<TEntity>(e);
		}

		private void GenerateId<TEntity>(IEntity entity) where TEntity : class, IEntity, new()
		{
			ContextEntityIdGenerator gen;
			_generators.TryGetValue(typeof(TEntity), out gen);
			gen.GenerateId(entity);
		}
	}
}
