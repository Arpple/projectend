using Entitas;

namespace End.Game
{
	[Game]
	public class PlayerCardComponent : IComponent
	{
		/// <summary>
		/// The current id of player owning this card.
		/// 0 if none
		/// </summary>
		public int CurrentOwnerId;

		public void MoveToPlayer(Player player)
		{
			CurrentOwnerId = player.PlayerId;
		}

		public void MoveToDeck()
		{
			CurrentOwnerId = 0;
		}
	}

}
