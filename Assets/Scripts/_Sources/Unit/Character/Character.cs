using Entitas;
using System.Linq;

public enum Character
{
	None,

	SharpShooter,
	WhiteRabbit,
	Mimic,
	LastBoss,
    TyrantKing,
    PyroKing,
    Alchemita,
    Orshura,
    BxBx,
    Nidhogg,
    PotatoKnight,
    //CurseSword,
}

public sealed partial class UnitContext : Context<UnitEntity>
{
	//public UnitEntity GetCharacterFromPlayer(GameEntity playerEntity)
	//{
	//	return this.GetEntities(UnitMatcher.Character)
	//			.Where(c => c.owner.Entity == playerEntity)
	//			.FirstOrDefault();
	//}

	public UnitEntity GetEntityOwnedBy(GameEntity playerEntity)
	{
		return GetEntities()
				.Where(c => c.owner.Entity == playerEntity)
				.FirstOrDefault();
	}
}