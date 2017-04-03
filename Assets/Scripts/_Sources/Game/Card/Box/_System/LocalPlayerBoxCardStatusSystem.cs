using Entitas;
using System.Linq;
using System.Collections.Generic;

namespace End.Game.UI
{
	public class LocalPlayerBoxCardStatusSystem : ReactiveSystem<GameEntity>, IInitializeSystem
	{
		private readonly GameContext _context;
		private readonly PlayerUnitStatusPanel _localStatus;

		public LocalPlayerBoxCardStatusSystem(Contexts contexts, PlayerUnitStatusPanel localPlayerStatus) : base(contexts.game)
		{
			_context = contexts.game;
			_localStatus = localPlayerStatus;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.InBox, GroupEvent.AddedOrRemoved);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.playerCard.OwnerEntity.isLocalPlayer;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			UpdateCount();
		}

		public void Initialize()
		{
			UpdateCount();
		}

		private void UpdateCount()
		{
			var boxCardCount = _context.GetPlayerBoxCards(_context.localPlayerEntity);
			_localStatus.BoxCardCountText.text = boxCardCount.ToString();
		}
	}

}