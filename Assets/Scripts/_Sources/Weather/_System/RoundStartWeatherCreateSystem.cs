using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;

public class RoundStartWeatherCreateSystem : GameReactiveSystem, IInitializeSystem
{
	private WeatherSetter _setter;
	private WeatherSetting _setting;

	public RoundStartWeatherCreateSystem(Contexts contexts, WeatherSetting setting) : base(contexts)
	{
		_setting = setting;
	}

	public void Initialize()
	{
		_setter = new WeatherSetter(_context, _setting);
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Round);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasRound && _context.localEntity.isPlaying;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		
		foreach(var e in entities)
		{
			_setter.CreateWeather();
			EventCreateWeather.Create(_setter.GetWeahter(), _setter.GetCostMap());
		}
	}

	private class WeatherSetter
	{
		private WeatherSetting _setting;
		private GameContext _context;
		private WeigthRandomizer<int> _costRandomizer;
		private int _playerCount;

		private Weather _weather;
		private Dictionary<Resource, int> _costMap;

		public WeatherSetter(GameContext context, WeatherSetting setting)
		{
			_context = context;
			_setting = setting;
			_costRandomizer = new WeigthRandomizer<int>();
			InitRandom();

			_playerCount = _context.GetEntities(GameMatcher.Player)
				.Count(e => !e.isBossPlayer);
		}

		public Weather GetWeahter()
		{
			return _weather;
		}

		public Dictionary<Resource, int> GetCostMap()
		{
			return _costMap;
		}

		private void InitRandom()
		{
			int i = 0;
			foreach (var weigth in _setting.CostCountWeigthList)
			{
				_costRandomizer.AddItem(i + 1, weigth);
				i++;
			}
		}

		public void CreateWeather()
		{
			_weather = GetRandomWeather();
			var costType = _setting.GetData(_weather).Cost;
			CreateWeatherCost(costType);
		}

		private Weather GetRandomWeather()
		{
			return Enum.GetValues(typeof(Weather)).Cast<Weather>().ToArray().GetRandom();
		}

		private void CreateWeatherCost(Resource costType)
		{
			var costMap = new Dictionary<Resource, int>();
			foreach(Resource res in Enum.GetValues(typeof(Resource)))
			{
				if(res == costType)
				{
					costMap.Add(res, GetRandomCost());
				}
				else
				{
					costMap.Add(res, 0);
				}
			}
			_costMap = costMap;
		}

		private int GetRandomCost()
		{
			return _costRandomizer.GetRandomItem() * _playerCount;
		}
	}
}