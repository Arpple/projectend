using Entitas;
using UnityEngine;

public partial class CardResoucesLoadingSystem : ReactiveSystem<CardEntity>, IInitializeSystem, ITearDownSystem
{
	protected class CardResourceLoader
	{
		private CardEntity _card;
		private CardSetting _setting;

		public CardResourceLoader(CardEntity entity, CardSetting setting)
		{
			_card = entity;
			_setting = setting;
		}

		public Sprite LoadSprite()
		{
			var sprite = Resources.Load<Sprite>(_card.resource.SpritePath);
			if (sprite == null)
			{
				throw new MissingReferenceException(_card.resource.SpritePath);
			}

			return sprite;
		}

		public CardObject LoadObject()
		{
			var view = Object.Instantiate(_setting.CardObjectPrefabs) as CardObject;
			if (view == null)
			{
				throw new MissingReferenceException("Card Setting prefabs invalid");
			}

			return view;
		}
	}
}