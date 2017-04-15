using System.Linq;
using Entitas;
using Network;
using NUnit.Framework;
using UnityEngine;

namespace Test.UnitTest.CharTest
{
	public class PlayerCharacterCreatingSystemTest : ContextsTest
	{
		[Test]
		public void CreateCharacter()
		{
			var player = new GameObject().AddComponent<Player>();
			player.PlayerId = 1;
			player.SelectedCharacterId = 1;

			var system = new PlayerCharacterCreatingSystem(_contexts);

			var tile = _contexts.tile.CreateEntity();
			tile.AddSpawnpoint(1);
			tile.AddMapPosition(0, 0);

			var p = _contexts.game.CreateEntity();
			p.AddPlayer(player);

			system.Initialize();

			var character = _contexts.unit.GetEntities(UnitMatcher.Character).FirstOrDefault();
			Assert.IsNotNull(character);
			Assert.IsTrue(tile.mapPosition.Equals(character.mapPosition));
		}
	}
}
