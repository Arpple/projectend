using System;

public abstract class WeatherAbility: IWeatherEffectActivate {
    public abstract void ActiveClearEffect(UnitEntity[] allplayers, UnitEntity MVPPlayer);
    public abstract void ActiveFailEffect(UnitEntity[] allplayers, UnitEntity MVPPlayer);
}
