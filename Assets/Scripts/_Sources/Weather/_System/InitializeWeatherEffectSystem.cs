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
        Dictionary<Weather, WeatherDataComponent> _weatherDic = new Dictionary<Weather, WeatherDataComponent>();
        foreach(WeatherData data in _setting.DataList) {
            WeatherDisplayEffect effect = Object.Instantiate<WeatherDisplayEffect>(data.WeatherEffect, _camera, false);
            effect.gameObject.SetActive(false);

            var dataCom = new WeatherDataComponent();
            dataCom.ability = new WeatherAbilityComponent();
            dataCom.effect = new WeatherEffectComponent();
            dataCom.ability.Ability = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(data.WeatherAbility) as WeatherAbility;
            dataCom.effect.Effect = effect;
            _weatherDic.Add(data.Type,dataCom);

        }

        var entity = _gameContexts.CreateEntity();

        entity.AddWeatherEffect(Weather.Normal
            ,_weatherDic[Weather.Normal].effect.Effect);
        entity.AddWeatherDictionary(_weatherDic);
    }

}
