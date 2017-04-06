using System.Linq;
using System.Collections.Generic;
using Entitas;
using Game.UI;
using UnityEngine.Assertions;

namespace Game
{
	public class PlayerBoxCardSystem : ReactiveSystem<CardEntity>
	{
		public PlayerBoxCardSystem(Contexts contexts) : base(contexts.card)
		{
		}

		protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
		{
			return context.CreateCollector(CardMatcher.GameInBox, GroupEvent.AddedOrRemoved);
		}

		protected override bool Filter(CardEntity entity)
		{
			return entity.hasGameOwner;
		}

		protected override void Execute(List<CardEntity> entities)
		{
			foreach (var e in entities)
			{
				if(e.hasGameInBox)
				{
					e.gameOwner.Entity.gamePlayerBox.BoxObject.AddCard(e.gameView.GameObject, e.gameInBox.Index);
				}
				else
				{
					e.gameOwner.Entity.gamePlayerDeck.PlayerDeckObject.AddCard(e.gameView.GameObject);
				}
			}
		}
	}

}
