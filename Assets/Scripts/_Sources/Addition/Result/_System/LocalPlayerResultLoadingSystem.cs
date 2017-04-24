using System.Collections.Generic;
using Entitas;

namespace Result
{
	public class LocalPlayerResultLoadingSystem : GameReactiveSystem
	{
		public LocalPlayerResultLoadingSystem(Contexts contexts) : base(contexts)
		{
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Player);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasPlayer && entity.isLocal;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			foreach(var player in entities)
			{
				var np = player.player.GetNetworkPlayer();
				player.isMainMissionCompleted = np.MainMissionComplete;
				player.isPlayerMissionCompleted = np.PlayerMissionComplete;
			}
		}
	}
}