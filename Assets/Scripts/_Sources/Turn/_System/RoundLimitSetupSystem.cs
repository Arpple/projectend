using System;
using Entitas;

public class RoundLimitSetupSystem : IInitializeSystem
{
	private GameContext _context;

	public RoundLimitSetupSystem(Contexts contexts)
	{
		_context = contexts.game;
	}

	public void Initialize()
	{
		var player = _context.localEntity.player.GetNetworkPlayer();
		var round = player.RoundLimit;
		if (round < 1) throw new RoundLimitInvalidException(round);
		_context.SetRoundLimit(player.RoundLimit);
	}

	public class RoundLimitInvalidException : Exception
	{
		public RoundLimitInvalidException(int number) : base("round " + number)
		{ }
	}
}