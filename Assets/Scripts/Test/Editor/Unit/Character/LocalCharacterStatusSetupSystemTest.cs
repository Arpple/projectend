using NUnit.Framework;
using UnityEngine;

namespace Test.UnitTest.CharTest
{
	public class LocalCharacterStatusSetupSystemTest : ContextsTest
	{
		PlayerUnitStatusPanel _panel;

		[SetUp]
		public void Init()
		{
			_panel = Object.Instantiate(Resources.Load<PlayerUnitStatusPanel>("Game/UI/_Prefabs/DisplayStatus/Player Status"));
			_systems.Add(new LocalCharacterStatusSetupSystem(_contexts, _panel));
		}

		[Test]
		public void Initialize_LocalFlagAddToCharacterEntity_PanelUpdate()
		{
			var icon = Resources.Load<Sprite>("Test/Editor/Sprite");

			var player = CreatePlayerEntity(1);
			player.player.PlayerObject.PlayerName = "test";
			player.isLocal = true;

			var character = _contexts.unit.CreateEntity();
			character.AddUnitIcon(icon);
			character.AddOwner(player);
			character.AddCharacter(Character.LastBoss);
			character.AddUnitStatus(1, 1, 1, 1, 1);
			character.AddHitpoint(1);
			character.isLocal = true;

			_systems.Execute();

			Assert.AreEqual("test", _panel.PlayerNameText.text);
			Assert.AreEqual(icon, _panel.CharacterIcon.IconImage.sprite);
			Assert.AreEqual("1", _panel.AttackPowerText.text);
			Assert.AreEqual("1", _panel.AttackRangeText.text);
			Assert.AreEqual("1", _panel.MoveSpeedText.text);
			Assert.AreEqual("1", _panel.VisionRangeText.text);
			Assert.AreEqual("1/1", _panel.HpBar.ValueText.text);

			_systems.ClearReactiveSystems();
		}
	}
}
