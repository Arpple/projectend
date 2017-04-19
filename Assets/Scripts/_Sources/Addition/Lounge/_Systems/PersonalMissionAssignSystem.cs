using System.Collections.Generic;
using Entitas;

namespace Lounge
{
	public class PersonalMissionAssignSystem : GameReactiveSystem
	{
		private PersonalMissionSetting _setting;

		public PersonalMissionAssignSystem(Contexts contexts, PersonalMissionSetting setting) : base(contexts)
		{
			_setting = setting;
		}

		protected override Collector<GameEntity> GetTrigger(IContext<GameEntity> context)
		{
			return context.CreateCollector(GameMatcher.Player);
		}

		protected override bool Filter(GameEntity entity)
		{
			return entity.hasPlayer;
		}

		protected override void Execute(List<GameEntity> entities)
		{
			var localPlayer = _context.localEntity.player.GetNetworkPlayer();
			var players = _context.GetEntities(GameMatcher.Player);
			var missions = _setting.DataList.ToArray();

			foreach (var e in entities)
			{
				localPlayer.CmdSetPersonalMission(e.player.PlayerId, (int)missions.GetRandom().Type, players.GetRandom().player.PlayerId);
			}
		}
	}
}
