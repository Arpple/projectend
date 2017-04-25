using System;

public class WeatherSummer: WeatherAbility {
    public override void ActiveClearEffect(UnitEntity[] allplayers, UnitEntity MVPPlayer) {
        foreach(var player in allplayers) {
            player.ReplaceHitpoint(player.hitpoint.Value+1);
        }
        MVPPlayer.ReplaceHitpoint(MVPPlayer.hitpoint.Value+1) ;
    }

    public override void ActiveFailEffect(UnitEntity[] allplayers, UnitEntity MVPPlayer) {
        foreach(var player in allplayers) {
            player.ReplaceHitpoint(player.hitpoint.Value - 1);
        }
        MVPPlayer.ReplaceHitpoint(MVPPlayer.hitpoint.Value -1);
    }
}
