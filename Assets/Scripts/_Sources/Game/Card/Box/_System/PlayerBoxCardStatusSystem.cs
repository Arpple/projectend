using Entitas;
using System.Linq;
using System.Collections.Generic;
using End.Game.UI;
using System;

namespace End.Game
{
	public class PlayerBoxCardStatusSystem : ReactiveSystem<GameEntity>, IInitializeSystem
	{
		private readonly GameContext _context;
		private readonly PlayerStatusPanel _localStatus;

		public PlayerBoxCardStatusSystem(Contexts contexts, PlayerStatusPanel localPlayerStatus) : base(contexts.game)
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
			return true;
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
			var boxCardCount = _context.GetEntities(GameMatcher.InBox)
				.Where(e => e.playerCard.CurrentOwnerId == _context.localPlayerEntity.player.PlayerId)
				.Count();

			_localStatus.BoxCardCountText.text = boxCardCount.ToString();
		}
	}

}