using Entitas;

public class TurnPanelSetupSystem : IInitializeSystem
{
	private readonly GameContext _gameContext;
	private readonly UnitContext _unitContext;
	private readonly TurnPanel _turnPanel;

	public TurnPanelSetupSystem(Contexts contexts, TurnPanel turnPanel)
	{
		_gameContext = contexts.game;
		_unitContext = contexts.unit;
		_turnPanel = turnPanel;
	}

	public void Initialize()
	{
		foreach (var player in _gameContext.playingOrder.PlayerOrder)
		{
			var character = _unitContext.GetCharacterFromPlayer(player);
			var turnNode = _turnPanel.CreateTurnNode();
			turnNode.SetCharacter(character);
			if (character.hasUnitIcon)
				turnNode.SetTurnIcon(character.unitIcon.IconSprite);
		}
	}
}