using UnityEngine;
using NUnit.Framework;
using End.Game;
using End.Game.UI;
using System.Linq;
using Entitas;
using System;

namespace End.Test.System
{
	public class TestOnDeadBoxSystem : ContextsTest
	{
		private GameEntity _ownerPlayer;
		private GameEntity _unit;

		private class TestOnDeadAbility : Ability, IOnDeadAbility
		{
			public override GameEntity GetTargetEntity(GameEntity caster, GameEntity targetTile)
			{
				throw new NotImplementedException();
			}

			public override GameEntity[] GetTilesArea(GameEntity caster)
			{
				throw new NotImplementedException();
			}

			public void OnDead(GameEntity deadEntity)
			{
				Assert.Pass();
			}

			public override void OnTargetSelected(GameEntity caster, GameEntity target)
			{
				throw new NotImplementedException();
			}
		}

		[SetUp]
		public void Init()
		{
			_ownerPlayer = _contexts.game.CreateEntity();
			_ownerPlayer.AddPlayer(new GameObject().AddComponent<Player>());

			_unit = _contexts.game.CreateEntity();
			_unit.AddUnit(0, _ownerPlayer);
		}

		[Test]
		public void CallOnDeadAbilityFromBox()
		{
			var system = new OnDeadBoxSystem(_contexts);
			_unit.AddHitpoint(0);

			var box = new GameObject().AddComponent<PlayerBox>();
			_ownerPlayer.AddPlayerBox(box);

			var card = _contexts.game.CreateEntity();
			card.AddCard(0, Card.Potion);
			card.AddPlayerCard(_ownerPlayer);
			card.AddInBox(0);
			card.AddAbility("", new TestOnDeadAbility());

			system.Execute();

			//fail if ability not called
			Assert.Fail();
		}
	}
}