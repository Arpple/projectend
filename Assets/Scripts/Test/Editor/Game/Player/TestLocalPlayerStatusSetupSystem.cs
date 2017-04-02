using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;
using End.Game.UI;

namespace End.Test.System
{
	public class TestLocalPlayerStatusSetupSystem : ContextsTest
	{
		private PlayerStatusPanel _panel;

		[SetUp]
		public void Init()
		{
			_panel = new GameObject().AddComponent<PlayerStatusPanel>();
			_panel.PlayerNameText = new GameObject().AddComponent<UnityEngine.UI.Text>();
		}

		[Test]
		public void StatusPanelNameSet()
		{
			var player = TestHelper.CreatePlayerEntity(_contexts.game, 1);
			player.player.PlayerObject.PlayerName = "test";
			player.isLocalPlayer = true;

			var system = new LocalPlayerStatusSetupSystem(_contexts, _panel);

			system.Initialize();

			Assert.AreEqual(player.player.PlayerObject.PlayerName, _panel.PlayerNameText.text);
		}

	}
}
