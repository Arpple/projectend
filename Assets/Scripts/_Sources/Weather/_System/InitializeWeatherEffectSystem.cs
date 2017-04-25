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
            WeatherChangeEffect effect = null;
            GameObject view;

            effect = Object.Instantiate<WeatherChangeEffect>(data.WeatherEffect, _camera, false);
            view = effect.gameObject;
            view.name = data.Type + " effect ";
            view.SetActive(false);
            entity.AddWeatherEffect(data.Type,effect);
            entity.AddView(view);

        }
    }
}
