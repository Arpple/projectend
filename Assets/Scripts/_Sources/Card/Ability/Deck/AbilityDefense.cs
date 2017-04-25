using System;

public class AbilityDefense: Ability, IBlockAttack {
    public int AfterBlockAttack(CardEntity cardAbility) {
        UnityEngine.Debug.Log("Remove Defense card");
        if(cardAbility.hasInBox){
            cardAbility.RemoveInBox();
        } else {
            cardAbility.RemoveOwner();
        }
        //EventMoveDeckCard.MoveCardToShareDeck(cardAbility);
        return 1;
    }
}
