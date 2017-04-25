public interface IWeatherEffectActivate {
    /// <summary>
    /// Active Clear Effect
    /// </summary>
    /// <param name="allplayers"></param>
    /// <param name="MVPPlayer">who pay hightest cost</param>
    void ActiveClearEffect(GameEntity[] allplayers,GameEntity MVPPlayer);

    /// <summary>
    /// Active Fail
    /// </summary>
    /// <param name="allplayers"></param>
    /// <param name="MVPPlayer">who pay lowest cost</param>
    void ActiveFailEffect(GameEntity[] allplayers, GameEntity MVPPlayer);
}
