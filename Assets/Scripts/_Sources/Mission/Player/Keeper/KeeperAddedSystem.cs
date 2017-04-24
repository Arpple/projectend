using System.Collections.Generic;
using Entitas;

public class KeeperAddedSystem: ReactiveSystem<GameEntity> {

    private GameContext _context;
    public KeeperAddedSystem(Contexts contexts) : base(contexts.game) {

    }

    protected override void Execute(List<GameEntity> entities) {
       foreach(var player in entities) {
            //UnityEngine.Debug.Log("Keeper Added");
            player.isPlayerMissionCompleted = true;
        }
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasPlayerMission && entity.playerMission.MisisonType==PlayerMission.Keeper;
    }

    protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector<GameEntity>(GameMatcher.PlayerMission, GroupEvent.Added);
    }
}
