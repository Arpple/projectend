using NUnit.Framework;
using UnityEngine;


namespace Test.UnitTest
{
	public class LocalCharacterStatusRenderingSystemTest : ContextsTest
	{
		PlayerUnitStatusPanel _panel;

		[SetUp]
		public void Init()
		{
			_panel = Object.Instantiate(Resources.Load<PlayerUnitStatusPanel>("Game/UI/_Prefabs/DisplayStatus/Player Status"));
			_systems.Add(new LocalCharacterStatusRenderingSystem(_contexts, _panel));
		}

		[Test]
		public void Execute_UnitStatusAdded_PanelUpdate()
		{
			var character = _contexts.unit.CreateEntity();
			character.AddUnitStatus(1, 1, 1, 1, 1);
			character.isLocal = true;

			_systems.Execute();

			Assert.AreEqual("1", _panel.AttackPowerText.text);
			Assert.AreEqual("1", _panel.AttackRangeText.text);
			Assert.AreEqual("1", _panel.MoveSpeedText.text);
			Assert.AreEqual("1", _panel.VisionRangeText.text);
			Assert.AreEqual("0/1", _panel.HpBar.ValueText.text);

			_systems.ClearReactiveSystems();
		}
	}
}
