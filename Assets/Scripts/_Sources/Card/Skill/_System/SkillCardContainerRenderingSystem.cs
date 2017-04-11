using System.Collections.Generic;
using Entitas;

public class SkillCardContainerRenderingSystem : ReactiveSystem<CardEntity>, IInitializeSystem
{
	private GameContext _gameContext;
	private PlayerSkillFactory _factory;

	public SkillCardContainerRenderingSystem(Contexts contexts, PlayerSkillFactory factory) : base(contexts.card)
	{
		_gameContext = contexts.game;
		_factory = factory;
	}

	protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
	{
		return context.CreateCollector(CardMatcher.SkillCard);
	}

	protected override bool Filter(CardEntity entity)
	{
		return entity.isSkillCard;
	}

	protected override void Execute(List<CardEntity> entities)
	{
		foreach (var e in entities)
		{
			e.owner.Entity.skillCardContainer.ContainerObject.AddCard(e.view.GameObject);
		}
	}

	public void Initialize()
	{
		foreach (var p in _gameContext.GetEntities(GameMatcher.Player))
		{
			var cont = _factory.CreateContainer(p.player.PlayerId);
			p.AddSkillCardContainer(cont);
			if (p.isLocal) cont.gameObject.SetActive(true);
		}
	}
}