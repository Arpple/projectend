using UnityEngine;
using Entitas;
public class EventUseCardOnTileSystem : EventSystem
{
	public EventUseCardOnTileSystem(Contexts contexts) : base(contexts)
	{
	}

	protected override Collector<GameEventEntity> GetTrigger(IContext<GameEventEntity> context)
	{
		return context.CreateCollector(GameEventMatcher.EventUseCardOnTile, GroupEvent.Added);
	}

	protected override bool Filter(GameEventEntity entity)
	{
		return entity.hasEventUseCardOnTile;
	}

	protected override void Process(GameEventEntity entity)
	{
		var cardEvent = entity.eventUseCardOnTile;
		var cardEntity = cardEvent.CardEntity;
		var ability = (ActiveAbility<TileEntity>)cardEntity.ability.Ability;
		ability.OnTargetSelected(cardEvent.UserEntity, cardEvent.TargetEntity);

		if (cardEntity.hasAbilityEffect)
		{
            IAbilityAnimation animation = ability as IAbilityAnimation;
            if(animation == null){

                var effect = Object.Instantiate(
                    cardEntity.abilityEffect.EffectObject,
                    cardEvent.TargetEntity.view.GameObject.transform, false
                ).GetComponent<AbilityEffect>();
                effect.PlayAnimation();

            } else {
                var effect = cardEntity.abilityEffect.EffectObject;
                animation.PlayAnimation(effect, cardEvent.UserEntity, cardEvent.TargetEntity.GetUnitOnTile());
            }
		}

		if (cardEntity.hasDeckCard)
			RemovePlayerCard(cardEntity);

		EventLogger.ShowMessge(string.Format("{0} use {1}",
			cardEvent.UserEntity.owner.Entity.player,
			cardEntity.cardDescription.Name
		));
	}

	private void RemovePlayerCard(CardEntity card)
	{
		card.RemoveOwner();
		if (card.hasInBox) card.RemoveInBox();
	}
}