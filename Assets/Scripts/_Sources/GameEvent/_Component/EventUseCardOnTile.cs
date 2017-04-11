using System.Linq;
using UnityEngine.Assertions;

[GameEvent]
public class EventUseCardOnTile : GameEventComponent
{
	public UnitEntity UserEntity;
	public CardEntity CardEnttiy;
	public TileEntity TargetEnttiy;

	public static void Create(UnitEntity userEntity, CardEntity cardEntity, TileEntity tileEntity)
	{
		Assert.IsTrue(cardEntity.hasCard);
		Assert.IsTrue(tileEntity.hasTile);

		GameEvent.CreateEvent<EventUseCardOnTile>(userEntity.id.Id, cardEntity.id.Id, tileEntity.mapPosition.x, tileEntity.mapPosition.y);
	}

	public void Decode(int userUnitId, int cardId, int x, int y)
	{
		UserEntity = Contexts.sharedInstance.unit.GetEntitiesWithId(userUnitId)
			.First();

		CardEnttiy = Contexts.sharedInstance.card.GetEntitiesWithId(cardId)
			.First();

		TargetEnttiy = Contexts.sharedInstance.tile.GetEntitiesWithMapPosition(new Position(x, y))
			.First();
	}
}
