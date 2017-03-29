using Entitas;
using System.Collections.Generic;
using UnityEngine.Assertions;
using System.Linq;

namespace End.Game
{
	public class CreatePlayerCharacterSystem : ReactiveSystem<GameEntity>
	{
		readonly GameContext _context;

		public CreatePlayerCharacterSystem(Contexts contexts)
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
			return entity.hasPlayer;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			var spawnpoints = _context.GetEntities(GameMatcher.Spawnpoint);
			Assert.IsTrue(spawnpoints.Length >= entities.Count);

            int indexSpawnPoint = 0;
			int id = 0;
			foreach (var playerEntity in entities.OrderBy(p => p.player.PlayerId))
			{
				var sp = spawnpoints[indexSpawnPoint];
                indexSpawnPoint++;

				var characterType = (Character)playerEntity.player.PlayerObject.SelectedCharacterId;
				Assert.IsTrue(characterType != Character.None);

				var character = _context.CreateEntity();
				character.AddUnit(id, playerEntity);
				character.AddCharacter(characterType);
				character.AddMapPosition(sp.mapPosition.x, sp.mapPosition.y);

				if (playerEntity.isLocalPlayer)
				{
					GameUtil.LocalPlayerCharacter = character;
				}
				id++;
			}
		}
	}

}
