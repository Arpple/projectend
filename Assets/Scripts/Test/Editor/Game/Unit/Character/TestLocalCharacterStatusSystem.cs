using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Game.UI;

namespace Test.System
{
	public class TestLocalCharacterStatusSystem : ContextsTest
	{
		PlayerUnitStatusPanel _panel;

		[SetUp]
		public void Init()
		{
			_panel = Object.Instantiate(Resources.Load<PlayerUnitStatusPanel>("Game/UI/_Prefabs/DisplayStatus/Player Status"));
		}

		[Test]
		public void SetLocalCharacter()
		{
			var system = new LocalCharacterStatusSystem(_contexts, _panel);

			var icon = Resources.Load<Sprite>("Test/Editor/Sprite");

			var player = TestHelper.CreatePlayerEntity(_contexts.game, 1);
			player.gamePlayer.PlayerObject.PlayerName = "test";
			player.isGameLocalPlayer = true;

			var character = _contexts.game.CreateEntity();
			character.AddGameUnitIcon(icon);
			character.AddGameUnit(1, player);
			character.AddGameCharacter(Game.Character.LastBoss);
			character.AddGameUnitStatus(1, 1, 1, 1, 1);
			character.AddGameHitpoint(1);

			system.Initialize();

			Assert.AreEqual("test", _panel.PlayerNameText.text);
			Assert.AreEqual(icon, _panel.CharacterIcon.IconImage.sprite);
			Assert.AreEqual("1", _panel.AttackPowerText.text);
			Assert.AreEqual("1", _panel.AttackRangeText.text);
			Assert.AreEqual("1", _panel.MoveSpeedText.text);
			Assert.AreEqual("1", _panel.VisionRangeText.text);
			Assert.AreEqual("1/1", _panel.HpBar.ValueText.text);
		}
	}
}
