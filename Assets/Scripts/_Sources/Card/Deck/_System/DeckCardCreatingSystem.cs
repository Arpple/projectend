using Entitas;

/// <summary>
/// System for creating card entity from deck
/// </summary>
/// <seealso cref="Entitas.IInitializeSystem" />
public class DeckCardCreatingSystem : IInitializeSystem
{
	readonly CardContext _context;
	readonly DeckSetting _setting;

	public DeckCardCreatingSystem(Contexts contexts, DeckSetting setting)
	{
		_context = contexts.card;
		_setting = setting;
	}

	public void Initialize()
	{
		foreach (var data in _setting.DataList)
		{
			data.CreateCount.Loop(() =>
			{
				_context.CreateDeckCard(data.Type);
			});
		}
	}
}