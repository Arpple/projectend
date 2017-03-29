using System.Linq;
using Entitas;
using End.Game.UI;

namespace End.Game
{
	[Game]
	public class PlayerBoxComponent : IComponent
	{
		public PlayerBox BoxObject;

		public GameEntity[] GetBoxCards<T>(GameEntity playerEntity)
		{
			return GameEntity.Context.GetEntities(GameMatcher.InBox)
				.Where(boxCard => boxCard.playerCard.CurrentOwnerId == playerEntity.player.PlayerId)
				.Where(boxCard => boxCard.ability.Ability is T)
				.ToArray();
		}
	}
}
