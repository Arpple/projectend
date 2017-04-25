using System;

public class AbilityProtection: Ability, IProtectAggressiveAbility{
    public int AfterBlock(CardEntity card) {
        UnityEngine.Debug.Log("Remove Defense card");
        EventMoveDeckCard.MoveCardToShareDeck(card);
        return 1;
    }
}
