using Entitas;
using System.Linq;

namespace Game
{
	public enum Character
	{
		None,

		SharpShooter,
		WhiteRabbit,
		Mimic,
		//CurseSword,
		LastBoss,
	}
}

public sealed partial class UnitContext : Context<UnitEntity>
{
	public UnitEntity GetCharacterFromPlayer(GameEntity playerEntity)
	{
		return this.GetEntities(UnitMatcher.GameCharacter)
				.Where(c => c.gameOwner.Entity == playerEntity)
				.FirstOrDefault();
	}
}