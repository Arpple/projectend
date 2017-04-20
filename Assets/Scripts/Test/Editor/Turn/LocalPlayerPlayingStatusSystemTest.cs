using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Test.TurnTest
{
	public class LocalPlayerPlayingStatusSystemTest : ContextsTest
	{
		PlayerUnitStatusPanel _panel;

		[SetUp]
		public void Init()
		{
			_panel = new GameObject().AddComponent<PlayerUnitStatusPanel>();
			_panel.PlayingTurnImage = new GameObject().AddComponent<Image>();

			_systems.Add(new LocalPlayerPlayingStatusSystem(_contexts, _panel));
		}

		[Test]
		public void Execute_IsPlaying_PanelPlayingImageEnable()
		{
			var p = _contexts.game.CreateEntity();
			p.isLocal = true;
			p.isPlaying = true;

			_systems.Execute();

			Assert.IsTrue(_panel.PlayingTurnImage.gameObject.activeSelf);
		}

		[Test]
		public void Execute_PlayingFlagRemoved_PanelPlayingImageDisable()
		{
			var p = _contexts.game.CreateEntity();
			p.isLocal = true;
			p.isPlaying = true;
			p.isPlaying = false;

			_systems.Execute();

			Assert.IsFalse(_panel.PlayingTurnImage.gameObject.activeSelf);
		}
	}
}
