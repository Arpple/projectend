using System.Linq;
using UnityEngine.Assertions;

[GameEvent]
public class EventSyncBoxCard : GameEventComponent
{
	public CardEntity Card;
	public int BoxIndex;

	public static void SyncBoxIndex(CardEntity entity)
	{
		Assert.IsTrue(entity.hasInBox);

		var cardIndex = entity.view.GameObject.transform.GetSiblingIndex();

		GameEvent.CreateEvent<EventSyncBoxCard>(entity.id.Id, cardIndex);
	}

	public void Decode(int cardId, int boxIndex)
	{
		Card = Contexts.sharedInstance.card.GetEntitiesWithId(cardId).First();

		BoxIndex = boxIndex;
	}
}