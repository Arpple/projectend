using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

namespace End.Game.UI
{
	public class LocalPlayerStatusSetupSystem : IInitializeSystem
	{
		private readonly GameContext _context;
		private readonly PlayerStatusPanel _panel;

		public LocalPlayerStatusSetupSystem(Contexts contexts, PlayerStatusPanel panel)
		{
			_context = contexts.game;
			_panel = panel;
		}

		public void Initialize()
		{
			var localPlayer = _context.localPlayerEntity;
			_panel.SetPlayer(localPlayer);
		}
	}

}
