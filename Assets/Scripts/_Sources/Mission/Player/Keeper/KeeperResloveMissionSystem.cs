using System.Collections.Generic;
using Entitas;

public class KeeperResloveMissionSystem: ReactiveSystem<GameEntity> {

    private GameContext _gameContext;
    public KeeperResloveMissionSystem(Contexts contexts) : base(contexts.game) {
        this._gameContext = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities) {
       foreach(var player in _gameContext.GetEntitiesWithPlayerMission(PlayerMission.Keeper)){
            //UnityEngine.Debug.Log("Keeper Fail");
            player.isPlayerMissionCompleted = false;
        }
    }

    protected override bool Filter(GameEntity entity) {
        return entity.isWeatherResloveFail;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector<GameEntity>(GameMatcher.WeatherResloveFail, GroupEvent.Added);
    }
}
