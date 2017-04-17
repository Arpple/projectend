using Network;
using NUnit.Framework;
using UnityEngine;

namespace Test.CardTest.AbilityTest
{
	public class TestOnDeadAbilitySystem : ContextsTest
	{
		private GameEntity _ownerPlayer;
		private UnitEntity _unit;

		private class TestOnDeadAbility : Ability, IOnDeadAbility
		{
			public void OnDead(UnitEntity deadEntity)
			{
				
			}
		}

		[SetUp]
		public void Init()
		{
			_ownerPlayer = _contexts.game.CreateEntity();
			_ownerPlayer.AddPlayer(new GameObject().AddComponent<Player>());

			_unit = _contexts.unit.CreateEntity();
			_unit.AddOwner(_ownerPlayer);

			_systems.Add(new EventHpDepleteSystem(_contexts));
		}

		[Test]
		public void CallOnDeadAbilityFromBox()
		{
			_unit.AddHitpoint(0);

			var box = new GameObject().AddComponent<PlayerBox>();
			_ownerPlayer.AddPlayerBox(box);

			var card = _contexts.card.CreateEntity();
			card.AddDeckCard(DeckCard.Potion);
			card.AddOwner(_ownerPlayer);
			card.AddInBox(0);
			card.AddAbility(new TestOnDeadAbility());

			_systems.Execute();
			Assert.Pass();
		}
	}
}