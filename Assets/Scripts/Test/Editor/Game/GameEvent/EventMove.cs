using UnityEngine;
using NUnit.Framework;
using End.Game;
using System.Linq;

namespace End.Test
{
	public class TestEventMove
	{
		private Contexts _contexts;
		private Player _player;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
			Game.GameController.IsTest = true;
			_player = Resources.Load<Player>("Network/Player");
		}


		[Test]
		public void CreateEvent()
		{
			var charEntity = _contexts.game.CreateEntity();
			charEntity.AddCharacter(Character.CurseSword);
			charEntity.AddUnit(_player);
			charEntity.AddMapPosition(0, 0);

			var tile = _contexts.game.CreateEntity();
			tile.AddMapPosition(2, 2);

			EventMove.Create(charEntity, tile.mapPosition);

			var eventEntities = _contexts.gameEvent.GetEntities();

			Assert.AreEqual(1, eventEntities.Length);
			Assert.IsTrue(eventEntities[0].hasEventMove);

			var e = eventEntities[0].eventMove;
			Assert.AreEqual(charEntity, e.MovingEntity);
			Assert.AreEqual(2, e.x);
			Assert.AreEqual(2, e.y);
		}

		[Test]
		public void SystemReplacePosition()
		{
			var system = new EventMoveSystem(_contexts);

			var charEntity = _contexts.game.CreateEntity();
			charEntity.AddCharacter(Character.CurseSword);
			charEntity.AddUnit(_player);
			charEntity.AddMapPosition(0, 0);

			var tile = _contexts.game.CreateEntity();
			tile.AddMapPosition(2, 2);

			EventMove.Create(charEntity, tile.mapPosition);

			system.Execute();

			Assert.AreEqual(tile.mapPosition.x, charEntity.mapPosition.x);
			Assert.AreEqual(tile.mapPosition.y, charEntity.mapPosition.y);
		}
	}

}
