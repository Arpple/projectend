using End.UI;
using System;
using UnityEngine;
using UnityEngine.UI;
using End.Game;

namespace End.CharacterSelect
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
		/// <param name="characterId">The character identifier.</param>
		public void SetCharacter(int characterId)
		{
            //TODO: change display icon
            GameEntity[] entities = Contexts.sharedInstance.game.GetEntities();
            Character CharName = (Character)Enum.Parse(typeof(Character),characterId.ToString());
            //this.CharactorIcon.SetImage(Resources.Load<Sprite>(LoadCharacterIconSystem.GetIconPath(Array.Find(entities, enity => enity.character.Type == CharName).resource)));
            this.SignLockImage.color = Color.green;
        }
        
        public void FocusPlayer() {
            //Debug.Log("Focus player with char ID "+_player.SelectedCharacterId);
            GameEntity[] entities = Contexts.sharedInstance.game.GetEntities();
            Character CharName = (Character)Enum.Parse(typeof(Character), _player.SelectedCharacterId.ToString());
            GameEntity unit = Array.Find(entities, enity => enity.character.Type == CharName);
            CharacterSelectController.Instance.ShowUnitInformationUnit(unit);

            //TODO : need to fix show role. ?
            FocusPlayerStatus.Instance.SetFocusPlayer(this._player.PlayerName,
                (this._player.SelectedCharacterId!=0),
                "-Unknow-", 
                unit.unitIcon.IconSprite);

        }
	}

}
