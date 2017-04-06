using NUnit.Framework;
using UnityEngine;
using Game;
using Entitas;
using System.Linq;

namespace Test.System
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

			var tile = _contexts.tile.CreateEntity();
			tile.AddGameSpawnpoint(1);
			tile.AddGameMapPosition(0, 0);

			var p = _contexts.game.CreateEntity();
			p.AddGamePlayer(player);

			system.Initialize();

			var character = _contexts.unit.GetEntities(UnitMatcher.GameCharacter).FirstOrDefault();
			Assert.IsNotNull(character);
			Assert.IsTrue(tile.gameMapPosition.Equals(character.gameMapPosition));
		}
	}
}
