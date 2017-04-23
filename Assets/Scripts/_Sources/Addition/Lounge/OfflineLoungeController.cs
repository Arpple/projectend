using System.Collections.Generic;
using System.Linq;
using Network;
using UnityEngine;

namespace Lounge
{
	public class OfflineLoungeController : LoungeController
	{
		public Transform PlayerParent;

		public override List<Player> GetAllPlayers()
		{
			return PlayerParent.GetComponentsInChildren<Player>(true).ToList();
		}

		public override Player GetLocalPlayer()
		{
			return PlayerParent.GetChild(0).GetComponent<Player>();
		}

		protected override void LockFocusingCharacter()
		{
			_localPlayer.SelectedCharacterId = (int)_focusingCharacter;
		}

		public override void SetLocalPlayer(Player player)
		{
			base.SetLocalPlayer(player);
			MissionBook.SetLocalPlayerMission((PlayerMission)player.PlayerMissionId);
			MissionBook.SetLocalPlayerTarget(player.PlayerMissionTarget);
		}
	}
}
