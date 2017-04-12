using System;
using Entitas;
using UnityEngine;

public class CardViewCreatingSystem : EntityViewCreatingSystem<CardEntity>
{
	private CardSetting _setting;

	public CardViewCreatingSystem(Contexts contexts, CardSetting setting) : base(contexts.card)
	{
		_setting = setting;
	}

	protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
	{
		return context.CreateCollector(CardMatcher.Sprite);
	}

	protected override bool Filter(CardEntity entity)
	{
		return entity.hasSprite;
	}

	protected override GameObject CreateViewObject(CardEntity entity)
	{
		var view = UnityEngine.Object.Instantiate(_setting.CardObjectPrefabs) as CardObject;
		view.SetAbilityImage(entity.sprite.Sprite);
		return view.gameObject;
	}

	protected override void AddViewObject(CardEntity entity, GameObject viewObject)
	{
		entity.AddView(viewObject);
	}
}
