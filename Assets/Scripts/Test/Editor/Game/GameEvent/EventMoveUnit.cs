using UnityEngine;
using NUnit.Framework;
using End.Game;

namespace End.Test
{
	public class TestEventMoveUnit
	{
		private Contexts _contexts;
		private Player _player;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
			GameController.IsTest = true;
			_player = Resources.Load<Player>("Network/Player");
		}


		[Test]
		public void CreateEvent()
		{
			var charEntity = _contexts.game.CreateEntity();
			charEntity.AddCharacter(Character.CurseSword);
			//charEntity.AddUnit(0, _player);
			charEntity.AddMapPosition(0, 0);

			var tile = _contexts.game.CreateEntity();
			tile.AddMapPosition(2, 2);

			EventMoveUnit.Create(charEntity, tile.mapPosition);

			var eventEntities = _contexts.gameEvent.GetEntities();

			Assert.AreEqual(1, eventEntities.Length);
			Assert.IsTrue(eventEntities[0].hasEventMoveUnit);

			var e = eventEntities[0].eventMoveUnit;
			Assert.AreEqual(charEntity, e.MovingEntity);
			Assert.AreEqual(2, e.x);
			Assert.AreEqual(2, e.y);
		}

		[Test]
		public void SystemReplacePosition()
		{
			var system = new EventMoveUnitSystem(_contexts);

			var charEntity = _contexts.game.CreateEntity();
			charEntity.AddCharacter(Character.CurseSword);
			charEntity.AddUnit(0, _player);
			charEntity.AddMapPosition(0, 0);

			var tile = _contexts.game.CreateEntity();
			tile.AddMapPosition(2, 2);

			EventMoveUnit.Create(charEntity, tile.mapPosition);

			system.Execute();

			Assert.AreEqual(tile.mapPosition.x, charEntity.mapPosition.x);
			Assert.AreEqual(tile.mapPosition.y, charEntity.mapPosition.y);
		}
	}

}
