namespace Game.UI
{
	public class PlayerBoxFactory : CardContainerFactory<PlayerBox>
	{
		public PlayerBox CreateContainer(int playerId)
		{
			return base.CreateContainer("Box", playerId);
		}
	}
}