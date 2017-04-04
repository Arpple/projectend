using Entitas;
using System.Collections.Generic;

namespace Game.UI
{
	public class TargetPlayerDeckCardStatusSystem : ReactiveSystem<GameEntity>
	{
		private readonly GameContext _context;
		private readonly PlayerUnitStatusPanel _status;

		public TargetPlayerDeckCardStatusSystem(Contexts contexts, PlayerUnitStatusPanel status) : base(contexts.game)
		{
			_context = contexts.game;
			_status = status;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return new Collector<GameEntity>(
				new[]
				{
					context.GetGroup(GameMatcher.GamePlayerCard),
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
			return _status.ShowingCharacter != null;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			var deckCardCount = _context.GetPlayerDeckCards(_status.ShowingCharacter.gameUnit.OwnerEntity)
				.Length;
			var boxCardCount = _context.GetPlayerBoxCards(_status.ShowingCharacter.gameUnit.OwnerEntity)
				.Length;

			_status.UpdateDeckCardCount(deckCardCount);
			_status.UpdateBoxCardCount(boxCardCount);
		}
	}

}