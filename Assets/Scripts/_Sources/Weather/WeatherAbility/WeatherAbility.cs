using System;

public abstract class WeatherAbility: IWeatherEffectActivate {
    public abstract void ActiveClearEffect(GameEntity[] allplayers, GameEntity MVPPlayer);
    public abstract void ActiveFailEffect(GameEntity[] allplayers, GameEntity MVPPlayer);
}
