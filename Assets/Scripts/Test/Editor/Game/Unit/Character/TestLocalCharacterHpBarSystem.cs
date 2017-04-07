﻿using UnityEngine;
using NUnit.Framework;
using Game.UI;

namespace Test.System
{
	public class TestLocalCharacterHpBarSystem : ContextsTest
	{
		private HpBar _hp;

		[SetUp]
		public void Init()
		{
			PlayerUnitStatusPanel _panel = Object.Instantiate(Resources.Load<PlayerUnitStatusPanel>("Game/UI/_Prefabs/DisplayStatus/Player Status"));
			_hp = _panel.HpBar;
		}

		[Test]
		public void HpBarUpdated()
		{
			var system = new LocalCharacterHpBarSystem(_contexts, _hp);

			var player = TestHelper.CreatePlayerEntity(_contexts.game, 1);
			player.isGameLocal = true;

			var ch = _contexts.unit.CreateEntity();
			ch.AddGameOwner(player);
			ch.AddGameHitpoint(1);

			_hp.SetMaxValue(10);

			system.Execute();

			Assert.AreEqual("1/10", _hp.ValueText.text);
			Assert.AreEqual(0.1f, _hp.CurrentValueBarImage.transform.localScale.x);
		}
	}
}
