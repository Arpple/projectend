using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public class RoundEndWeatherResolveSystem : GameReactiveSystem
{
	private Contexts _contexts;
    private WeatherResloveDisplayer _weatherResolveDisplayer;

	public RoundEndWeatherResolveSystem(Contexts contexts,WeatherResloveDisplayer displayer) : base(contexts)
	{
		_contexts = contexts;
        this._weatherResolveDisplayer = displayer;
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
            var pay = costMan.getPayResources();
            var cost = costMan.getCostResources();

            _weatherResolveDisplayer.ResloveWeather(
                cost.ContainsKey(Resource.Wood) ? cost[Resource.Wood] : 0,
                cost.ContainsKey(Resource.Water) ? cost[Resource.Water] : 0,
                cost.ContainsKey(Resource.Coal) ? cost[Resource.Coal] : 0,
                cost.ContainsKey(Resource.Wood) ? pay[Resource.Wood] : 0,
                cost.ContainsKey(Resource.Water) ? pay[Resource.Water] : 0,
                cost.ContainsKey(Resource.Coal) ? pay[Resource.Coal] : 0,
                costMan.getMVPPlayer().player.GetNetworkPlayer().PlayerName
            );

			Debug.Log("pass : " + costMan.IsWeatherResolved()
                +" MVP is -> " + costMan.getMVPPlayer().player.GetNetworkPlayer().PlayerName);
            if(!costMan.IsWeatherResolved()) {
                e.isWeatherResloveFail = true;
            }
		}
	}
	
	private class WeatherCardCostManager
	{
		private Contexts _contexts;
		private Dictionary<Resource, int> _costMap;
		private GameEntity[] _players;
		private Dictionary<GameEntity, PlayerResource> _playersResources;
		private bool _isPass;

        private int _lowestPay, _hightestPay;
        private GameEntity _lowestPayPlayer, _hightestPayPlayer;
		
		public WeatherCardCostManager(Contexts contexts)
		{
			_contexts = contexts;
			_costMap = _contexts.game.weatherCost.ResourcesCost;
			_players = _contexts.game.GetEntities(GameMatcher.Player)
				.Where(p => !p.isBossPlayer)
				.ToArray();

			_isPass = true;

			InitPayResource();
            InitMVPPlayer();
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

        public Dictionary<Resource,int> getCostResources() {
            return _costMap;
        }

        public Dictionary<Resource,int> getPayResources() {
            Dictionary<Resource, int> pay = new Dictionary<Resource, int>();
            foreach(var type in _costMap.Keys) {
                pay.Add(type, 0);
                foreach(var p in _players) {
                    pay[type] += _playersResources[p].GetResourcePayCount(type);
                }
            }
            return pay;
        }

        public GameEntity getMVPPlayer() {
            return IsWeatherResolved() ? _hightestPayPlayer : _lowestPayPlayer;
        }

		private void InitPayResource()
		{
			_playersResources = new Dictionary<GameEntity, PlayerResource>();
			
			foreach (var p in _players)
			{
				_playersResources.Add(p, new PlayerResource(_contexts.card, p));
			}
		}

        private void InitMVPPlayer() {
            this._hightestPayPlayer = _players[0];
            this._lowestPayPlayer = _players[0];
        }

		private void PayResource(Resource type)
		{
			var paySum = 0;
            var pay = 0;
            bool firstPlayer = true;
			foreach(var p in _players)
			{
				_playersResources[p].PayResources(type);
				pay = _playersResources[p].GetResourcePayCount(type);
                paySum += pay;

                //set low/hi pay player
                if(pay > _hightestPay || firstPlayer) {
                    _hightestPayPlayer = p;
                    _hightestPay = pay;
                    firstPlayer = false;
                }
                if(pay < _lowestPay || firstPlayer) {
                    _lowestPayPlayer = p;
                    _lowestPay = pay;
                    firstPlayer = false;
                }
			}

			var costRequire = _costMap[type];
			if (paySum < costRequire)
			{
				Debug.Log(type + ":" + paySum + "/" + costRequire);
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
				_resourceCounts[type] = cards.Sum(c => c.charge.Count);
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