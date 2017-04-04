using UnityEngine;
using Entitas;

namespace Game.UI
{
	public class TurnPanelSetupSystem : IInitializeSystem
	{
		private readonly GameContext _context;
		private readonly TurnPanel _turnPanel;

		public TurnPanelSetupSystem(Contexts contexts, TurnPanel turnPanel)
		{
			_context = contexts.game;
			_turnPanel = turnPanel;
		}

		public void Initialize()
		{
			foreach(var player in _context.playingOrder.PlayerOrder)
			{
				var character = _context.GetCharacterFromPlayer(player);
				var turnNode = _turnPanel.CreateTurnNode();
				turnNode.SetPlayer(player);
				if(character.hasUnitIcon)
					turnNode.SetTurnIcon(character.unitIcon.IconSprite);
			}
		}
	}

}
