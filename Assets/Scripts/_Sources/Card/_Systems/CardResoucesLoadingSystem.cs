using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public partial class CardResoucesLoadingSystem : ReactiveSystem<CardEntity>, IInitializeSystem, ITearDownSystem
{
	private CardContext _context;
	private CardSetting _setting;
	private List<GameObject> _linkedObjects;

	public CardResoucesLoadingSystem(Contexts contexts, CardSetting setting) : base(contexts.card)
	{
		_context = contexts.card;
		_setting = setting;
		_linkedObjects = new List<GameObject>();
	}

	public void Initialize()
	{
		foreach (var e in _context.GetEntities(CardMatcher.Resource))
		{
			if (Filter(e))
			{
				LoadResource(e);
			}
		}
	}

	protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
	{
		return context.CreateCollector(CardMatcher.Resource);
	}

	protected override void Execute(List<CardEntity> entities)
	{
		foreach (var e in entities)
		{
			LoadResource(e);
		}
	}

	protected override bool Filter(CardEntity entity)
	{
		return entity.hasResource && !entity.hasView;
	}

	private void LoadResource(CardEntity entity)
	{
		var loader = new CardResourceLoader(entity, _setting);
		var sprite = loader.LoadSprite();
		var view = loader.LoadObject();
		view.SetAbilityImage(sprite);

		entity.AddView(view.gameObject);
		view.gameObject.Link(entity, _context);
		_linkedObjects.Add(view.gameObject);
	}

	public void TearDown()
	{
		_linkedObjects.ForEach(o => o.Unlink());
		_linkedObjects.Clear();
	}
}