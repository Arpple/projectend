using UnityEngine;

public class WeatherSummer: WeatherAbility {
    public override void ActiveClearEffect(GameEntity[] allplayers, GameEntity MVPPlayer) {
        Debug.Log("Win weaher...");
        UnitEntity p;
        foreach(var player in allplayers) {
            Debug.Log("Win weaher...");
            p = Contexts.sharedInstance.unit.GetEntityOwnedBy(player);
            p.RecoverHitpoint(1);
        }
        p = Contexts.sharedInstance.unit.GetEntityOwnedBy(MVPPlayer);
        p.RecoverHitpoint(1);
    }

    public override void ActiveFailEffect(GameEntity[] allplayers, GameEntity MVPPlayer) {
        UnitEntity p;
        foreach(var player in allplayers) {
            Debug.Log("Lost weaher...");
            p = Contexts.sharedInstance.unit.GetEntityOwnedBy(player);
            p.TakeFatalDamage(1);
        }
        p = Contexts.sharedInstance.unit.GetEntityOwnedBy(MVPPlayer);
        p.TakeFatalDamage(1);
    }
}
