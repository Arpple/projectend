using System.Linq;
using UnityEngine.Assertions;

[GameEvent]
public class EventUseCardOnUnit : GameEventComponent
{
	public UnitEntity UserEntity;
	public CardEntity CardEntity;
	public UnitEntity TargetEntity;

	public static void Create(UnitEntity userEntity, CardEntity cardEntity, UnitEntity targetEntity)
	{
		Assert.IsTrue(cardEntity.hasCard);

		GameEvent.CreateEvent<EventUseCardOnUnit>(userEntity.id.Id, cardEntity.id.Id, targetEntity.id.Id);
	}

	public void Decode(int userUnitId, int cardId, int targetUnitId)
	{
		UserEntity = Contexts.sharedInstance.unit.GetEntitiesWithId(userUnitId)
			.First();

		CardEntity = Contexts.sharedInstance.card.GetEntitiesWithId(cardId)
			.First();

		TargetEntity = Contexts.sharedInstance.unit.GetEntitiesWithId(targetUnitId)
			.First();
	}
}
