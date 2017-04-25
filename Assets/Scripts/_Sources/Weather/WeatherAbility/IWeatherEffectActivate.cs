public interface IWeatherEffectActivate {
    /// <summary>
    /// Active Clear Effect
    /// </summary>
    /// <param name="allplayers"></param>
    /// <param name="MVPPlayer">who pay hightest cost</param>
    void ActiveClearEffect(UnitEntity[] allplayers,UnitEntity MVPPlayer);

    /// <summary>
    /// Active Fail
    /// </summary>
    /// <param name="allplayers"></param>
    /// <param name="MVPPlayer">who pay lowest cost</param>
    void ActiveFailEffect(UnitEntity[] allplayers, UnitEntity MVPPlayer);
}
