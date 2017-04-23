using Entitas;
using UnityEngine;
using System.Linq;

public class EventUseCardOnUnitSystem : EventSystem
{
	public EventUseCardOnUnitSystem(Contexts contexts) : base(contexts)
	{
	}

	protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
	{
		return context.CreateCollector(GameEventMatcher.EventUseCardOnUnit, GroupEvent.Added);
	}

	protected override bool Filter(GameEventEntity entity)
	{
		return entity.hasEventUseCardOnUnit;
	}

	protected override void Process(GameEventEntity entity)
	{
		var cardEvent = entity.eventUseCardOnUnit;
		var cardEntity = cardEvent.CardEntity;
		var ability = (ActiveAbility<UnitEntity>)cardEntity.ability.Ability;
		ability.OnTargetSelected(cardEvent.UserEntity, cardEvent.TargetEntity);

        if(cardEntity.hasAbilityEffect) {
            IAbilityAnimation animation = ability as IAbilityAnimation;
            if(animation == null) {

                var effect = Object.Instantiate(
                    cardEntity.abilityEffect.EffectObject,
                    cardEvent.TargetEntity.view.GameObject.transform, false
                ).GetComponent<AbilityEffect>();
                effect.PlayAnimation();

            } else {
                var effect = cardEntity.abilityEffect.EffectObject;
                animation.PlayAnimation(effect, cardEvent.UserEntity, cardEvent.TargetEntity);
            }
        }
        //if (cardEntity.hasAbilityEffect)
        //{

        //	var effect = Object.Instantiate(
        //		cardEntity.abilityEffect.EffectObject,
        //		cardEvent.TargetEntity.view.GameObject.transform, false
        //	).GetComponent<AbilityEffect>();

        //	effect.PlayAnimation();
        //}

        if (cardEntity.hasDeckCard)
			RemovePlayerCard(cardEntity);

		var msg = string.Format("{0} use {1}",
			cardEvent.UserEntity.owner.Entity.player,
			cardEntity.cardDescription.Name
		);
		
		if(cardEvent.TargetEntity != cardEvent.UserEntity)
		{
			msg += " to " + cardEvent.TargetEntity.owner.Entity.player;
		}

		EventLogger.ShowMessge(msg);
	}

	private void RemovePlayerCard(CardEntity card)
	{
		card.RemoveOwner();
		if (card.hasInBox) card.RemoveInBox();
	}
}
