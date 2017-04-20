using System.Linq;
using Entitas;
using Network;

public class PlayerMissionSetupSystem : IInitializeSystem
{
	private GameContext _context;

	public PlayerMissionSetupSystem(Contexts contexts)
	{
		_context = contexts.game;
	}

	public void Initialize()
	{
		foreach(var e in _context.GetEntities(GameMatcher.Player))
		{
			var missionAssigner = new MissionAssigner(_context, e);
			missionAssigner.AddPlayerMission();
			missionAssigner.AddPlayerMissionTarget();
		}
	}

	private class MissionAssigner
	{
		private GameContext _context;
		private Player _player;
		private GameEntity _entity;

		public MissionAssigner(GameContext context, GameEntity playerEntity)
		{
			_context = context;
			_entity = playerEntity;
			_player = playerEntity.player.GetNetworkPlayer();
		}

		public void AddPlayerMission()
		{
			_entity.AddPlayerMission((PlayerMission)_player.PlayerMissionId);
		}

		public void AddPlayerMissionTarget()
		{
			var targetId = _player.PlayerMissionTarget;
			if(targetId > 0)
			{
				_entity.AddPlayerMissionTarget(GetTargetEntity(targetId));
			}
		}

		private GameEntity GetTargetEntity(int targetId)
		{
			return _context.GetEntities(GameMatcher.Player)
				.First(p => p.player.PlayerId == targetId);
		}
	}
}