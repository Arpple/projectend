using NUnit.Framework;
using UnityEngine;
using End.Game;
using Entitas;
using System.Linq;

namespace End.Test.System
{
	public class TestCreatePlayerCharacterSystem : ContextsTest
	{
		[Test]
		public void CreateCharacter()
		{
			var player = new GameObject().AddComponent<Player>();
			player.PlayerId = 1;
			player.SelectedCharacterId = 1;

			var system = new CreatePlayerCharacterSystem(_contexts);

			var tile = _contexts.game.CreateEntity();
			tile.AddSpawnpoint(1);
			tile.AddMapPosition(0, 0);

			var p = _contexts.game.CreateEntity();
			p.AddPlayer(player);

			system.Initialize();

			var character = _contexts.game.GetEntities(GameMatcher.Character).FirstOrDefault();
			Assert.IsNotNull(character);
			Assert.IsTrue(tile.mapPosition.Equals(character.mapPosition));
		}
	}
}
