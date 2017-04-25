using UnityEngine;
using Entitas;
using System.Collections.Generic;

public class InitializeWeatherEffectSystem: IInitializeSystem {
    private GameContext _gameContexts;
    private WeatherSetting _setting;
    private Transform _camera;

    

    public InitializeWeatherEffectSystem(Contexts contexts,WeatherSetting setting,Transform camera) {
        this._gameContexts = contexts.game;
        this._setting = setting;
        this._camera = camera;
    }

    public void Initialize() {
        Dictionary<Weather, WeatherDisplayEffect> _weatherEffect = new Dictionary<Weather, WeatherDisplayEffect>();
        foreach(WeatherData data in _setting.DataList) {
            WeatherDisplayEffect effect = Object.Instantiate<WeatherDisplayEffect>(data.WeatherEffect, _camera, false);
            effect.gameObject.SetActive(false);
            _weatherEffect.Add(data.Type,effect);
        }

        var entity = _gameContexts.CreateEntity();

        entity.AddWeatherEffect(Weather.Normal
            ,_weatherEffect[Weather.Normal]);
        entity.AddWeatherEffectDictionary(_weatherEffect);
    }

}
