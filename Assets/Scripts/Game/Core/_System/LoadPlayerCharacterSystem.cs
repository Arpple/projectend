using Entitas;
using System.Collections.Generic;
using UnityEngine.Assertions;
using System.Linq;

namespace End.Game
{
	public class LoadPlayerCharacterSystem : ReactiveSystem<GameEntity>
	{
		readonly GameContext _context;

		public LoadPlayerCharacterSystem(Contexts contexts)
			: base(contexts.game)
		{
			_context = contexts.game;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Player, GroupEvent.Added);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasPlayer && entity.player.PlayerObject.SelectedCharacterId != (int)Character.None;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			var spawnpoints = _context.GetEntities(GameMatcher.Spawnpoint);
			Assert.IsTrue(spawnpoints.Length >= entities.Count);

			foreach (var player in entities.Select(e => e.player))
			{
				var sp = spawnpoints[player.PlayerId];

				//create character
				var character = _context.CreateEntity();
				character.AddUnit(player.PlayerObject);
				character.AddCharacter((Character)player.PlayerObject.SelectedCharacterId);
				character.AddMapPosition(sp.mapPosition.x, sp.mapPosition.y);
			}
		}
	}

}
