using Entitas;

public class PlayerBoxComponentCreatingSystem : IInitializeSystem
{
	private GameContext _context;
	private PlayerBoxFactory _boxContainer;

	public PlayerBoxComponentCreatingSystem(Contexts contexts, PlayerBoxFactory boxContainer)
	{
		_context = contexts.game;
		_boxContainer = boxContainer;
	}

	public void Initialize()
	{
		foreach (var player in _context.GetEntities(GameMatcher.Player))
		{
			var playerbox = _boxContainer.CreateContainer(player.player.PlayerId);
			player.AddPlayerBox(playerbox);

			if (player.isLocal)
			{
				playerbox.gameObject.SetActive(true);
			}
		}
	}
}