using System.Linq;
using System.Collections.Generic;
using Entitas;

public class WeatherEffectSystem: GameReactiveSystem {
    public WeatherEffectSystem(Contexts contexts) : base(contexts) {
    }

    protected override void Execute(List<GameEntity> entities) {
        
        var weatherDic = _context.GetEntities(GameMatcher.WeatherDictionary)[0];
        var effects = _context.GetEntities(GameMatcher.WeatherEffect);

        foreach(var weather in entities) {
            foreach(var effect in effects) {
                //Remove current
                effect.weatherEffect.Effect.gameObject.SetActive(false);

                //reset new :3
                effect.weatherEffect.Type = weather.weather.Type;
                effect.weatherEffect.Effect = weatherDic.weatherDictionary.DataSet[weather.weather.Type].effect.Effect;
                effect.weatherEffect.Effect.gameObject.SetActive(true);
            }
        }

    }

    protected override bool Filter(GameEntity entity) {
        return true;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector<GameEntity>(GameMatcher.Weather,GroupEvent.AddedOrRemoved);
    }
}
