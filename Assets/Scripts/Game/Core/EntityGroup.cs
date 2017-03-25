using Entitas;

public sealed partial class GameEntity
{
	private static GameContext Context
	{
		get { return Contexts.sharedInstance.game; }
	}

	public static GameEntity[] Player
	{
		get { return Context.GetEntities(GameMatcher.Player); }
	}

	public static GameEntity LocalPlayer
	{
		get { return Context.GetGroup(GameMatcher.LocalPlayer).GetSingleEntity(); }
	}

	public static GameEntity[] Character
	{
		get { return Context.GetEntities(GameMatcher.Character); }
	}

	public static GameEntity[] Card
	{
		get { return Context.GetEntities(GameMatcher.Card); }
	}

	public static GameEntity[] Tile
	{
		get { return Context.GetEntities(GameMatcher.Tile); }
	}
}