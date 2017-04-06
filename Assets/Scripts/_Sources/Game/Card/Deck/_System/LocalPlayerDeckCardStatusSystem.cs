using Entitas;
using System.Collections.Generic;

namespace Game.UI
{
	public class LocalPlayerDeckCardStatusSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;
		private readonly PlayerUnitStatusPanel _status;

		public LocalPlayerDeckCardStatusSystem(Contexts contexts, PlayerUnitStatusPanel status) : base(contexts.game)
		{
			_context = contexts.game;
			_status = status;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return new Collector<GameEntity>(
				new[]
				{
					context.GetGroup(GameMatcher.GameOwner),
					context.GetGroup(GameMatcher.GameInBox),
				},
				new[]
				{
					GroupEvent.AddedOrRemoved,
					GroupEvent.AddedOrRemoved
				}
			);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.isGameDeckCard;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			var deckCardCount = _context.GetPlayerDeckCards(_context.gameLocalPlayerEntity)
				.Length;
			var boxCardCount = _context.GetPlayerBoxCards(_context.gameLocalPlayerEntity)
				.Length;

			_status.UpdateDeckCardCount(deckCardCount);
			_status.UpdateBoxCardCount(boxCardCount);
		}
	}

}