using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;

public class RoundStartWeatherCreateSystem : GameReactiveSystem
{
	private WeatherSetter _setter;

	public RoundStartWeatherCreateSystem(Contexts contexts, WeatherSetting setting) : base(contexts)
	{
		_setter = new WeatherSetter(_context, setting);
	}

	protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Round);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasRound;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach(var e in entities)
		{
			_setter.CreateWeather();
		}
	}

	private class WeatherSetter
	{
		private WeatherSetting _setting;
		private GameContext _context;
		private WeigthRandomizer<int> _costRandomizer;

		public WeatherSetter(GameContext context, WeatherSetting setting)
		{
			_context = context;
			_setting = setting;
			_costRandomizer = new WeigthRandomizer<int>();
			InitRandom();
		}

		public void CreateWeather()
		{
			var weather = GetRandomWeather();
			var costType = _setting.GetData(weather).Cost;
			CreateWeatherCost(costType);

			_context.ReplaceWeather(weather);
		}

		private void InitRandom()
		{
			int i = 0;
			foreach(var weigth in _setting.CostCountWeigthList)
			{
				_costRandomizer.AddItem(i + 1, weigth);
				i++;
			}
		}

		private Weather GetRandomWeather()
		{
			return Enum.GetValues(typeof(Weather)).Cast<Weather>().ToArray().GetRandom();
		}

		private int GetRandomCost()
		{
			return _costRandomizer.GetRandomItem();
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
			_context.ReplaceWeatherCost(costMap);
		}
	}
}