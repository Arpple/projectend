using System.Collections.Generic;
using Entitas;
using Network;

namespace Result
{
	public class PlayerResultObjectCreatingSystem : GameReactiveSystem
	{
		private ResultUIController _ui;
		private Setting _setting;

		public PlayerResultObjectCreatingSystem(Contexts contexts, Setting setting, ResultUIController ui) : base(contexts)
		{
			_ui = ui;
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
			foreach (var e in entities)
			{
				var obj = _ui.CreatePlayerResult(e);
				var setter = new PlayerResultSetter(e, obj, _setting);
				setter.SetPlayerData();
			}
		}

		private class PlayerResultSetter
		{
			private GameEntity _player;
			private Player _netPlayer;
			private PlayerResultObject _object;
			private Setting _setting;

			public PlayerResultSetter(GameEntity player, PlayerResultObject obj, Setting setting)
			{
				_player = player;
				_netPlayer = player.player.GetNetworkPlayer();
				_object = obj;
				_setting = setting;
			}

			public void SetPlayerData()
			{
				SetPlayerName();
				SetPlayerIcon();
				SetCharacterName();
				SetMissionName();
				SetMissionStatus();
			}

			private void SetPlayerName()
			{
				_object.SetPlayerName(_player.player.ToString());
			}

			private void SetPlayerIcon()
			{
				var icon = _setting.PlayerIconSetting.GetData((PlayerIcon)_netPlayer.PlayerIconId).Icon;
				_object.SetPlayerIcon(icon);
			}

			private void SetCharacterName()
			{
				var name = _setting.UnitSetting.CharacterSetting.GetData((Character)_netPlayer.SelectedCharacterId).Name;
				_object.SetCharacterName(name);
			}

			private void SetMissionName()
			{
				var name = _setting.MissionSetting.PlayerMission.GetData((PlayerMission)_netPlayer.PlayerMissionId).Name;
				_object.SetPlayerMissionName(name);
			}

			private void SetMissionStatus()
			{
				var isComplete = _netPlayer.PlayerMissionComplete;
				if(isComplete)
				{
					_object.DisplayMissionComplete();
				}
				else
				{
					_object.DisplayMissionFail();
				}
			}
		}
	} 
}
