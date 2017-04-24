using System.Linq;
using Entitas;
using Network;
using UI;
using UnityEngine;
using UnityEngine.UI;

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
			_player.CharacterUpdateAction += SetCharacter;
		}

		/// <summary>
		/// change display for player to selected character
		/// </summary>
		/// <param name="type">The character identifier.</param>
		public void SetCharacter(Character type)
		{
			var character = GetCharacterEntity(type);
            this.CharactorIcon.SetImage(character.unitIcon.IconSprite);
            this.SignLockImage.color = Color.green;
        }
        
        public void OnPlayerFocus() {
			//Debug.Log("Focus player with char ID "+_player.SelectedCharacterId);
			var character = GetCharacterEntity((Character)_player.SelectedCharacterId);
            LoungeController.Instance.ShowUnitInformationUnit(character);

            //TODO : need to fix show role. ?
            FocusedPlayerStatusController.Instance.SetFocusPlayer(this._player.PlayerName,
                (this._player.SelectedCharacterId!=0),
                "-Unknow-", 
                character.unitIcon.IconSprite);

        }

		private UnitEntity GetCharacterEntity(Character character)
		{
			return Contexts.sharedInstance.unit.GetEntities(UnitMatcher.Character)
				.Where(c => c.character.Type == character)
				.First();
		}
	}

}
