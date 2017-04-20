using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace Test.TurnTest
{
	public class TargetPlayerPlayingStatusSystemTest : ContextsTest
	{
		PlayerUnitStatusPanel _panel;
		GameEntity _player;

		[SetUp]
		public void Init()
		{
			_panel = new GameObject().AddComponent<PlayerUnitStatusPanel>();
			_panel.PlayingTurnImage = new GameObject().AddComponent<Image>();

			_player = _contexts.game.CreateEntity();

			var u = _contexts.unit.CreateEntity();
			u.AddOwner(_player);

			_panel.ShowingCharacter = u;

			_systems.Add(new TargetPlayerPlayingStatusSystem(_contexts, _panel));
		}

		[Test]
		public void Execute_IsPlaying_PanelPlayingImageEnable()
		{
			_player.isPlaying = true;

			_systems.Execute();

			Assert.IsTrue(_panel.PlayingTurnImage.gameObject.activeSelf);
		}

		[Test]
		public void Execute_PlayingFlagRemoved_PanelPlayingImageDisable()
		{
			_player.isPlaying = true;
			_player.isPlaying = false;

			_systems.Execute();

			Assert.IsFalse(_panel.PlayingTurnImage.gameObject.activeSelf);
		}
	}
}
