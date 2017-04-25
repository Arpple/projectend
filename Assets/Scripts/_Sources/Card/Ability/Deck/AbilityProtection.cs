using System;

public class AbilityProtection: Ability, IProtectAggressiveAbility{
    public int AfterBlock(CardEntity card) {
        UnityEngine.Debug.Log("Remove Defense card");
        if(card.hasInBox) {
            card.RemoveInBox();
        } else {
            card.RemoveOwner();
        }
        return 1;
    }
}
