using System.Linq;
using UnityEngine.Assertions;

[GameEvent]
public class EventSyncBoxCard : GameEventComponent
{
	public CardEntity Card;
	public int BoxIndex;

	public static void SetCardIndex(CardEntity entity, int boxIndex)
	{
		Assert.IsTrue(entity.hasInBox);

		GameEvent.CreateEvent<EventSyncBoxCard>(entity.id.Id, boxIndex);
	}

	public void Decode(int cardId, int boxIndex)
	{
		Card = Contexts.sharedInstance.card.GetEntitiesWithId(cardId).First();

		BoxIndex = boxIndex;
	}
}