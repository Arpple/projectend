using System.Linq;
using System.Collections.Generic;
using Entitas;
using Game.UI;
using UnityEngine.Assertions;

namespace Game
{
	public class PlayerBoxCardSystem : ReactiveSystem<GameEntity>
	{
		public PlayerBoxCardSystem(Contexts contexts) : base(contexts.game)
		{
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameInBox, GroupEvent.AddedOrRemoved);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasGameOwner;
		}

		protected override void Execute(List<GameEntity> entities)
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
