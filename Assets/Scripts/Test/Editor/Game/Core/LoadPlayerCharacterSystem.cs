﻿using NUnit.Framework;
using UnityEngine;
using End.Game;
using Entitas;
using System.Linq;

namespace End.Test
{
	public class TestLoadPlayerCharacterSystem
	{
		private Contexts _contexts;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
		}

		[Test]
		public void EditorTest()
		{
			var player = new GameObject().AddComponent<Player>();
			player.SelectedCharacterId = 1;

			var system = new LoadPlayerCharacterSystem(_contexts);

			var tile = _contexts.game.CreateEntity();
			tile.AddSpawnpoint(1);
			tile.AddMapPosition(0, 0);

			var p = _contexts.game.CreateEntity();
			p.AddPlayer(player);

			system.Execute();

			var character = _contexts.game.GetEntities(GameMatcher.Character).FirstOrDefault();
			Assert.IsNotNull(character);
			Assert.IsTrue(tile.mapPosition.IsEqual(character.mapPosition));
		}
	}
}
