using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

public class Skill_RabbitFilch: ActiveAbility<UnitEntity> {
    private UnitEntity _caster, _target;

    public override UnitEntity GetTargetFromSelectedTile(UnitEntity caster, TileEntity tile) {
        var target = GetEnemyUnitFromTile(caster, tile);
        return target;
        //var hand = Contexts.sharedInstance.card.GetPlayerDeckCardsIncludeBox(target.owner.Entity);
        //var res = Contexts.sharedInstance.card.GetPlayerResourceCards(target.owner.Entity);
        //int cardCount = (hand != null ? hand.Length : 0)
        //    + (res != null ? res.Length : 0);
        //if(cardCount > 0) {
        //    return target;
        //} else {
        //    return null;
        //}

    }

    public override TileEntity[] GetTilesArea(UnitEntity caster) {
        return TileAreaSelector.GetAllInRange(caster.GetTileOfUnit(), caster.unitStatus.VisionRange);
    }

    
    public override void OnTargetSelected(UnitEntity caster, UnitEntity target) {
        this._caster = caster;
        this._target = target;
        target.AddAbilityAggressiveEvent(target,1,rabbitFilch);
    }

    private void rabbitFilch() {
        UnityEngine.Debug.Log("Cast Rabbit Filch");
        var deckcards = Contexts.sharedInstance.card.GetPlayerDeckCardsIncludeBox(_target.owner.Entity);

        List<CardEntity> cards = new List<CardEntity>();
        foreach(var card in deckcards) {
            cards.Add(card);
        }
        foreach(var card in Contexts.sharedInstance.card.GetPlayerResourceCardsIncludeBox(_target.owner.Entity)) {
            cards.Add(card);
        }

        if(cards.Count > 0) {
            var stealedCard = cards[UnityEngine.Random.Range(0, Math.Max(0, cards.Count - 1))];
            if(stealedCard != null)
                stealedCard.ReplaceOwner(_caster.owner.Entity);
        }
        //EventMoveDeckCard.MoveCardToPlayer(stealedCard, _caster.owner.Entity);
    }
}