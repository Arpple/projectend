using System.Linq;
using Entitas;
using UnityEngine;
using UnityEngine.Assertions;

[GameEvent]
public class EventMoveDeckCard : GameEventComponent
{
	public CardEntity CardEntity;
	public GameEntity TargetPlayerEntity;
	public bool IsInBox;

	private static void MoveCard(CardEntity cardEntity, GameEntity playerEntity, bool isMoveTobox)
	{
		Debug.Log("create event move card " + cardEntity.id.Id);
		GameEvent.CreateEvent<EventMoveDeckCard>(
			cardEntity.id.Id,
			playerEntity != null
				? playerEntity.player.PlayerId
				: 0,
			isMoveTobox
				? 1
				: 0
		);
	}

	public static void MoveCardToPlayer(CardEntity cardEntity, GameEntity playerEntity)
	{
		Assert.IsTrue(cardEntity.hasDeckCard);

		MoveCard(cardEntity, playerEntity, false);
	}

	public static void MoveCardInToBox(CardEntity cardEntity)
	{
		Assert.IsFalse(cardEntity.hasInBox);

		MoveCard(cardEntity, cardEntity.owner.Entity, true);
	}

	public static void MoveCardOutFromBox(CardEntity cardEntity)
	{
		Assert.IsTrue(cardEntity.hasInBox);

		MoveCard(cardEntity, cardEntity.owner.Entity, false);
	}

	public static void MoveCardToShareDeck(CardEntity cardEntity)
	{
		MoveCard(cardEntity, null, false);
	}

	public void Decode(int cardId, int playerId, int isInBox)
	{
		Debug.Log("decode event move card " + cardId);
		CardEntity = Contexts.sharedInstance.card.GetEntities(CardMatcher.Id)
			.First(c => c.id.Id == cardId);

		TargetPlayerEntity = playerId == 0
			? null
			: Contexts.sharedInstance.game.GetEntities(GameMatcher.Player)
				.Where(e => e.player.PlayerId == playerId)
				.First();

		IsInBox = isInBox != 0;
	}
}
