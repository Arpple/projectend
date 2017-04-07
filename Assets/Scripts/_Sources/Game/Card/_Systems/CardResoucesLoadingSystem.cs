using Entitas;
using Entitas.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.UI;

namespace Game
{
	public class CardResoucesLoadingSystem : ReactiveSystem<CardEntity>, IInitializeSystem, ITearDownSystem
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
			foreach(var e in _context.GetEntities(CardMatcher.GameResource))
			{
				if(Filter(e))
				{
					LoadResource(e);
				}
			}
		}

		protected override Collector<CardEntity> GetTrigger(IContext<CardEntity> context)
		{
			return context.CreateCollector(CardMatcher.GameResource);
		}

		protected override void Execute(List<CardEntity> entities)
		{
			foreach(var e in entities)
			{
				LoadResource(e);
			}
		}

		protected override bool Filter(CardEntity entity)
		{
			return entity.hasGameResource && !entity.hasGameView;
		}

		private void LoadResource(CardEntity entity)
		{
			var loader = new CardResourceLoader(entity, _setting);
			var sprite = loader.LoadSprite();
			var view = loader.LoadObject();
			view.SetAbilityImage(sprite);

			entity.AddGameView(view.gameObject);
			view.gameObject.Link(entity, _context);
			_linkedObjects.Add(view.gameObject);
		}

		public void TearDown()
		{
			_linkedObjects.ForEach(o => o.Unlink());
			_linkedObjects.Clear();
		}

		internal class CardResourceLoader
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
				var sprite = Resources.Load<Sprite>(_card.gameResource.SpritePath);
				if(sprite == null)
				{
					throw new MissingReferenceException(_card.gameResource.SpritePath);
				}

				return sprite;
			}

			public CardObject LoadObject()
			{
				var view = Object.Instantiate(_setting.CardObjectPrefabs) as CardObject;
				if(view == null)
				{
					throw new MissingReferenceException("Card Setting prefabs invalid");
				}

				return view;
			}
		}

	}

}
