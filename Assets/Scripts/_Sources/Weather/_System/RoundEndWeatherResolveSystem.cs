using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public class RoundEndWeatherResolveSystem : GameReactiveSystem
{
	private Contexts _contexts;

	public RoundEndWeatherResolveSystem(Contexts contexts) : base(contexts)
	{
		_contexts = contexts;
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Round, GroupEvent.Removed);
	}

	protected override bool Filter(GameEntity entity)
	{
		return true;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach(var e in entities)
		{
			var costMan = new WeatherCardCostManager(_contexts);
			costMan.ResolveWeather();
			Debug.Log("pass : " + costMan.IsWeatherResolved());
		}
	}
	
	private class WeatherCardCostManager
	{
		private Contexts _contexts;
		private Dictionary<Resource, int> _costMap;
		private GameEntity[] _players;
		private Dictionary<GameEntity, PlayerResource> _playersResources;
		private bool _isPass;
		
		public WeatherCardCostManager(Contexts contexts)
		{
			_contexts = contexts;
			_costMap = _contexts.game.weatherCost.ResourcesCost;
			_players = _contexts.game.GetEntities(GameMatcher.Player)
				.Where(p => !p.isBossPlayer)
				.ToArray();

			_isPass = true;

			InitPayResource();
		}

		public void ResolveWeather()
		{
			foreach(var res in _costMap.Keys)
			{
				PayResource(res);
			}
		}

		public bool IsWeatherResolved()
		{
			return _isPass;
		}

		private void InitPayResource()
		{
			_playersResources = new Dictionary<GameEntity, PlayerResource>();
			
			foreach (var p in _players)
			{
				_playersResources.Add(p, new PlayerResource(_contexts.card, p));
			}
		}

		private void PayResource(Resource type)
		{
			var paySum = 0;
			foreach(var p in _players)
			{
				_playersResources[p].PayResources(type);
				paySum += _playersResources[p].GetResourcePayCount(type);
			}

			if(paySum < _costMap[type])
			{
				Debug.Log(type + ":" + paySum + "/" + _costMap[type]);
				_isPass = false;
			}
		}

		private class PlayerResource
		{
			private CardContext _context;
			private GameEntity _player;
			private Dictionary<Resource, int> _resourceCounts;

			public PlayerResource(CardContext context, GameEntity player)
			{
				_context = context;
				_player = player;
				_resourceCounts = new Dictionary<Resource, int>();
			}

			public void PayResources(Resource type)
			{
				var cards = GetPlayerResourceCard(type);
				_resourceCounts[type] = cards.Length;
				foreach (var card in cards)
				{
					card.MoveCardToDeck();
				}
			}

			public int GetResourcePayCount(Resource type)
			{
				return _resourceCounts[type];
			}

			private CardEntity[] GetPlayerResourceCard(Resource type)
			{
				return _context.GetEntities(CardMatcher.InBox)
					.Where(c => c.owner.Entity == _player
						&& c.hasResourceCard
						&& c.resourceCard.Type == type
					).ToArray();
			}
		}
	}
}