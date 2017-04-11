using UI;
using System;
using UnityEngine;
using UnityEngine.UI;

using Entitas;
using System.Linq;
using Network;

namespace Lounge
{
	/// <summary>
	/// Player instance for CharacterSelect scene
	/// </summary>
	/// <seealso cref="UnityEngine.MonoBehaviour" />
	public class LoungePlayer : MonoBehaviour
	{
		private Player _player;
        public Icon CharactorIcon;
        public Image SignLockImage;

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
		/// <param name="characterTypeId">The character identifier.</param>
		public void SetCharacter(int characterTypeId)
		{
			var character = GetCharacterEntity(characterTypeId);
            this.CharactorIcon.SetImage(character.unitIcon.IconSprite);
            this.SignLockImage.color = Color.green;
        }
        
        public void OnPlayerFocus() {
			//Debug.Log("Focus player with char ID "+_player.SelectedCharacterId);
			var character = GetCharacterEntity(_player.SelectedCharacterId);
            LoungeController.Instance.ShowUnitInformationUnit(character);

            //TODO : need to fix show role. ?
            FocusedPlayerStatusController.Instance.SetFocusPlayer(this._player.PlayerName,
                (this._player.SelectedCharacterId!=0),
                "-Unknow-", 
                character.unitIcon.IconSprite);

        }

		private UnitEntity GetCharacterEntity(int characterTypeId)
		{
			return Contexts.sharedInstance.unit.GetEntities(UnitMatcher.Character)
				.Where(c => (int)c.character.Type == characterTypeId)
				.First();
		}
	}

}
