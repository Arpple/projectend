using System.Collections.Generic;
using Entitas;


namespace End.Game
{
	public class PlayerSystem : Feature
	{
		public PlayerSystem(Contexts contexts, List<Player> players) : base("Player System")
		{
			Add(new LoadPlayerSystem(contexts, players));
			Add(new SetupLocalPlayerSystem(contexts));
			Add(new CreatePlayerCharacterSystem(contexts));
		}
		
	}

}
