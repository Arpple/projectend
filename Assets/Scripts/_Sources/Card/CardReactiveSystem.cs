using Entitas;

public abstract class CardReactiveSystem : ReactiveSystem<CardEntity>
{
	protected CardContext _context;

	public CardReactiveSystem(Contexts contexts) : base(contexts.card)
	{
		_context = contexts.card;
	}
}
