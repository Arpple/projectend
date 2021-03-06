﻿using Network;

namespace Lounge
{
	public class OfflineLoungeController : LoungeController
	{
		protected override bool IsServer()
		{
			return false;
		}

		protected override void LockFocusingCharacter()
		{
			_localPlayer.SelectedCharacterId = (int)_focusingCharacter;
		}

		protected override void SetupLocalPlayer(Player player)
		{
			base.SetupLocalPlayer(player);
			MissionBook.SetLocalPlayerMission((PlayerMission)player.PlayerMissionId);
			MissionBook.SetLocalPlayerTarget(player.PlayerMissionTarget);
		}
	}
}