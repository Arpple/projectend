using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace End.Game.CharacterSelect
{
	/// <summary>
	/// Player instance for CharacterSelect scene
	/// </summary>
	/// <seealso cref="UnityEngine.MonoBehaviour" />
	public class CharacterSelectPlayer : MonoBehaviour
	{
		private Player _player;

		public void SetPlayer(Player player)
		{
			_player = player;

			_player.OnSelectedCharacterChangedCallback += SetCharacter;
		}

		private void OnDestroy()
		{
			if (_player == null) return;

			_player.OnSelectedCharacterChangedCallback -= SetCharacter;
		}

		/// <summary>
		/// change display for player to selected character
		/// </summary>
		/// <param name="characterId">The character identifier.</param>
		public void SetCharacter(int characterId)
		{
			//TODO: change display icon
		}
	}

}
