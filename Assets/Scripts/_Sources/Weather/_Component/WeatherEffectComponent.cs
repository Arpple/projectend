using System.Collections.Generic;
using Entitas;

[Game]
public class WeatherEffectComponent : IComponent{
    public Weather Type;
    public WeatherDisplayEffect Effect;
}
