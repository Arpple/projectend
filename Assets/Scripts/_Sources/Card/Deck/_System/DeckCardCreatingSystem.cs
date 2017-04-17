using Entitas;

/// <summary>
/// System for creating card entity from deck
/// </summary>
/// <seealso cref="Entitas.IInitializeSystem" />
public class DeckCardCreatingSystem : IInitializeSystem
{
	readonly CardContext _context;
	readonly DeckData _deck;

	public DeckCardCreatingSystem(Contexts contexts, DeckData deck)
	{
		_context = contexts.card;
		_deck = deck;
	}

	public void Initialize()
	{
		var cardSetList = _deck.SettingList;
		foreach (var cardSet in cardSetList)
		{
			cardSet.Count.Loop(() =>
			{
				_context.CreateDeckCard(cardSet.Type);
			});
		}
	}
}