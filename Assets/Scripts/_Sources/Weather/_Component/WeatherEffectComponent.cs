using Entitas;

[Game]
public class WeatherEffectComponent : IComponent{
    public Weather Type;
    public WeatherChangeEffect Effect;
}
