using System.Collections.Generic;
using Entitas;

public class WeatherEffectDictionaryComponent : IComponent{
    public Dictionary<Weather, WeatherDisplayEffect> DataSet;
}
