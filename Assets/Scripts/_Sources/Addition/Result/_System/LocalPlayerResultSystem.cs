using System.Collections.Generic;
using Entitas;

namespace Result
{
	public class LocalPlayerResultSystem : GameReactiveSystem
	{
		private ResultUIController _ui;

		public LocalPlayerResultSystem(Contexts contexts, ResultUIController ui) : base(contexts)
		{
			_ui = ui;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Player);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.isLocal;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var e in entities)
			{
				if(IsPlayerVictory(e))
				{
					_ui.SetResultTextVictory();
				}
				else
				{
					_ui.SetResultTextDefeat();
				}
			}
		}

		private bool IsPlayerVictory(GameEntity player)
		{
			return player.isMainMissionCompleted && player.isPlayerMissionCompleted;
		}

	} 
}