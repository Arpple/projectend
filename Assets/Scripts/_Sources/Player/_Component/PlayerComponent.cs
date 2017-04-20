using Entitas;
using Network;

[Game]
public class PlayerComponent : IComponent
{
	public IPlayer PlayerObject;

	public int PlayerId
	{
		get { return PlayerObject.GetId(); }
	}

	public Player GetNetworkPlayer()
	{
		return PlayerObject as Player;
	}

	public override string ToString()
	{
		return PlayerObject.GetName();
	}
}