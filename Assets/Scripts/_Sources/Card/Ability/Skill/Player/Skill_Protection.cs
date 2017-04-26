using System;

public class Skill_Protection: Ability, IProtectAggressiveAbility {
    public int AfterBlock(CardEntity card) {
        //DO NOTHING.
        return 100;
    }
}
