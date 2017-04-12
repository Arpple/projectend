using Entitas;

public class PlayerBoxCreatingSystem : IInitializeSystem
{
	private GameContext _context;
	private PlayerBoxFactory _factory;

	public PlayerBoxCreatingSystem(Contexts contexts, PlayerBoxFactory boxFactory)
	{
		_context = contexts.game;
		_factory = boxFactory;
	}

	public void Initialize()
	{
		foreach (var player in _context.GetEntities(GameMatcher.Player))
		{
			var playerbox = _factory.CreateContainer(player.player.PlayerId);
			player.AddPlayerBox(playerbox);

			if (player.isLocal)
			{
				playerbox.gameObject.SetActive(true);
			}
		}
	}
}