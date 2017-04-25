using System.Collections.Generic;
using Entitas;

public class WeatherDictionaryComponent : IComponent{
    public Dictionary<Weather, WeatherDataComponent> DataSet;
}
