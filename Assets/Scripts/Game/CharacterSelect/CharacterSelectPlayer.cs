using End.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace End.Game.CharacterSelect
{
	/// <summary>
	/// Player instance for CharacterSelect scene
	/// </summary>
	/// <seealso cref="UnityEngine.MonoBehaviour" />
	public class CharacterSelectPlayer : MonoBehaviour
	{
		private Player _player;
        public Icon charactorIcon;
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
            foreach(var entity in entities) {
                if(entity.character.Type == CharName) {
                    this.charactorIcon.SetImage(Resources.Load<Sprite>(LoadCharacterIconSystem.GetIconPath(entity.resource)));
                }
            }
            this.SignLockImage.color = Color.green;
        }
	}

}
