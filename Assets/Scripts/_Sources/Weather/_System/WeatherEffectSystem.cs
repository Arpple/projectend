using System.Linq;
using System.Collections.Generic;
using Entitas;

public class WeatherEffectSystem: GameReactiveSystem {
    public WeatherEffectSystem(Contexts contexts) : base(contexts) {
    }

    protected override void Execute(List<GameEntity> entities) {
        var weatherEffect = _context.GetEntities(GameMatcher.WeatherEffect);
        //UnityEngine.Debug.Log("WeatherEffect = "+weatherEffect.Length);
        foreach(var effect in weatherEffect) {
            foreach(var weather in entities) {
                effect.weatherEffect.Effect.gameObject.SetActive(effect.weatherEffect.Type == weather.weather.Type);
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
