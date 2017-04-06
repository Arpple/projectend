using UI;
using System;
using UnityEngine;
using UnityEngine.UI;
using Game;
using Entitas;
using System.Linq;

namespace CharacterSelect
{
	/// <summary>
	/// Player instance for CharacterSelect scene
	/// </summary>
	/// <seealso cref="UnityEngine.MonoBehaviour" />
	public class CharacterSelectPlayer : MonoBehaviour
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
            this.CharactorIcon.SetImage(character.gameUnitIcon.IconSprite);
            this.SignLockImage.color = Color.green;
        }
        
        public void OnPlayerFocus() {
			//Debug.Log("Focus player with char ID "+_player.SelectedCharacterId);
			var character = GetCharacterEntity(_player.SelectedCharacterId);
            CharacterSelectController.Instance.ShowUnitInformationUnit(character);

            //TODO : need to fix show role. ?
            FocusPlayerStatus.Instance.SetFocusPlayer(this._player.PlayerName,
                (this._player.SelectedCharacterId!=0),
                "-Unknow-", 
                character.gameUnitIcon.IconSprite);

        }

		private UnitEntity GetCharacterEntity(int characterTypeId)
		{
			return Contexts.sharedInstance.unit.GetEntities(UnitMatcher.GameCharacter)
				.Where(c => (int)c.gameCharacter.Type == characterTypeId)
				.First();
		}
	}

}
