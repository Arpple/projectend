using UnityEngine;

public class WeatherSummer: WeatherAbility {
    public override void ActiveClearEffect(GameEntity[] allplayers, GameEntity MVPPlayer) {
        Debug.Log("Win weaher...");
        foreach(var player in allplayers) {
            //var playerStat = Contexts.sharedInstance.unit;
            //player.ReplaceHitpoint(player.hitpoint.Value+1);
        }
        //MVPPlayer.ReplaceHitpoint(MVPPlayer.hitpoint.Value+1) ;
    }

    public override void ActiveFailEffect(GameEntity[] allplayers, GameEntity MVPPlayer) {
        Debug.Log("Fail weaher...");
        foreach(var player in allplayers) {
        //    player.ReplaceHitpoint(player.hitpoint.Value - 1);
        }
        //MVPPlayer.ReplaceHitpoint(MVPPlayer.hitpoint.Value -1);
    }
}
