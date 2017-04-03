using System.Linq;
using System.Collections.Generic;
using Entitas;
using End.Game.UI;
using UnityEngine.Assertions;

namespace End.Game
{
	public class PlayerBoxCardSystem : ReactiveSystem<GameEntity>
	{
		public PlayerBoxCardSystem(Contexts contexts) : base(contexts.game)
		{
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.InBox, GroupEvent.AddedOrRemoved);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasPlayerCard;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var e in entities)
			{
				if(e.hasInBox)
				{
					e.playerCard.OwnerEntity.playerBox.BoxObject.AddCard(e.view.GameObject, e.inBox.Index);
				}
				else
				{
					e.playerCard.OwnerEntity.playerDeck.PlayerDeckObject.AddCard(e.view.GameObject);
				}
			}
		}
	}

}
