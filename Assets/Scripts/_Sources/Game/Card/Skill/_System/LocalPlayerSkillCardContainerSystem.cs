using UnityEngine;
using Entitas;
using System.Collections.Generic;

namespace Game.UI
{
	public class LocalPlayerSkillCardContainerSystem : ReactiveSystem<GameEntity>
	{
		public LocalPlayerSkillCardContainerSystem(Contexts contexts) : base(contexts.game)
		{
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.GameLocal, GroupEvent.AddedOrRemoved);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasGamePlayerSkillCardUI;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach (var e in entities)
			{
				e.gamePlayerSkillCardUI.ContainerObject.gameObject.SetActive(e.isGameLocal);
			}
		}
	}
}
