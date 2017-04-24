using System;

public class AbilityDefense: Ability, IBlockAttack {
    public int AfterBlockAttack(CardEntity cardAbility) {
        UnityEngine.Debug.Log("Remove Defense card");
        EventMoveDeckCard.MoveCardToShareDeck(cardAbility);
        return 1;
    }
}
