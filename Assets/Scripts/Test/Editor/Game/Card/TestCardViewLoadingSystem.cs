using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Game;

namespace Test.System
{
	public class TestCardViewLoadingSystem : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new CardViewLoadingSystem(_contexts, TestHelper.GetGameSetting().CardSetting));
		}

		[Test]
		public void Initialize()
		{
			var card = _contexts.card.CreateCard(Card.Move);
			card.AddGameResource("Test/Editor/Sprite", "");

			_systems.Initialize();

			Assert.IsTrue(card.hasGameView);
		}

		[Test]
		public void Execute()
		{
			var card = _contexts.card.CreateCard(Card.Move);
			card.AddGameResource("Test/Editor/Sprite", "");

			_systems.Execute();

			Assert.IsTrue(card.hasGameView);
		}

		[TearDown]
		public void After()
		{
			_systems.TearDown();
		}
	}
}
