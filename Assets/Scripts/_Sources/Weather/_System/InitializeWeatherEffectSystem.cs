using UnityEngine;
using Entitas;

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
        foreach(WeatherData data in _setting.DataList) {
            var entity = _gameContexts.CreateEntity();
            WeatherChangeEffect effect = Object.Instantiate<WeatherChangeEffect>(data.WeatherEffect, _camera, false);
            GameObject view = effect.gameObject;
            view.SetActive(false);
            entity.AddWeatherEffect(data.Type,effect);
            entity.AddView(view);

        }
    }
}
