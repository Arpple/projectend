using Entitas;

public class PlayerDeckCreatingSystem : IInitializeSystem
{
	private readonly GameContext _context;
	private readonly PlayerDeckFactory _cardDecks;

	public PlayerDeckCreatingSystem(Contexts contexts, PlayerDeckFactory decks)
	{
		_context = contexts.game;
		_cardDecks = decks;
	}

	public void Initialize()
	{
		foreach (var player in _context.GetEntities(GameMatcher.Player))
		{
			var playerDeck = _cardDecks.CreateContainer(player.player.PlayerId);
			player.AddPlayerDeck(playerDeck);
		}
	}
}