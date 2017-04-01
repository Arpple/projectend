using System.Linq;
using System.Collections.Generic;
using Entitas;
using End.Game.UI;
using UnityEngine.Assertions;

namespace End.Game
{
	public class PlayerBoxCardAddSystem : ReactiveSystem<GameEntity>
	{
		private GameContext _context;
		private CacheList<GameEntity, PlayerBox> _playerBoxCache;

		public PlayerBoxCardAddSystem(Contexts contexts)
			: base(contexts.game)
		{
			_context = contexts.game;
			_playerBoxCache = new CacheList<GameEntity, PlayerBox>();
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.InBox, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasInBox;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var e in entities)
			{
				Assert.IsTrue(e.hasPlayerCard);

				var box = _playerBoxCache.Get(e.playerCard.OwnerEntity, (playerEntity) =>
					_context.GetEntities(GameMatcher.PlayerBox)
						.Where(p => p == playerEntity)
						.First()
						.playerBox.BoxObject
				);

				box.AddCard(e.view.GameObject, e.inBox.Index);
			}
		}
	}

}
