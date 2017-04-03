using Entitas;
using System.Collections.Generic;

namespace End.Game.UI
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
					context.GetGroup(GameMatcher.PlayerCard),
					context.GetGroup(GameMatcher.InBox),
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
			return entity.isDeckCard;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			var deckCardCount = _context.GetPlayerDeckCards(_context.localPlayerEntity)
				.Length;
			var boxCardCount = _context.GetPlayerBoxCards(_context.localPlayerEntity)
				.Length;

			_status.UpdateDeckCardCount(deckCardCount);
			_status.UpdateBoxCardCount(boxCardCount);
		}
	}

}