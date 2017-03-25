using Entitas;

namespace End.Game
{
	public static class EntityGroup
	{
		private static GameContext _game
		{
			get { return Contexts.sharedInstance.game; }
		}

		public static GameEntity[] Player
		{
			get { return _game.GetEntities(GameMatcher.Player); }
		}

		public static GameEntity LocalPlayer
		{
			get { return _game.GetGroup(GameMatcher.LocalPlayer).GetSingleEntity(); }
		}

		public static GameEntity[] Character
		{
			get { return _game.GetEntities(GameMatcher.Character); }
		}

		public static GameEntity[] Card
		{
			get { return _game.GetEntities(GameMatcher.Card); }
		}

		public static GameEntity[] Tile
		{
			get { return _game.GetEntities(GameMatcher.Tile); }
		}
	}

}
