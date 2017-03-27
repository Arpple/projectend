﻿using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using Entitas.Unity;
using End.UI;
using End.Game;

namespace End.CharacterSelect
{
    public class CharacterSelectController : MonoBehaviour{

		public static CharacterSelectController Instance;	

        public UnitStatus UnitStatus;
        public UnitSkill UnitSkill;

        public GameObject RoleContent,CharacterContent,PlayerListContent;
		public SlideMenu CharacterSelectSlideMenu;
		public Button LockButton;
		public CharacterSelectPlayer CharacterSelectPlayerPrefabs;

		private Character _focusingCharacter;
		private Player _localPlayer;

		private void Awake()
		{
			Instance = this;

			Assert.IsNotNull(UnitStatus);
			Assert.IsNotNull(UnitSkill);
			Assert.IsNotNull(RoleContent);
			Assert.IsNotNull(CharacterContent);
			Assert.IsNotNull(CharacterSelectSlideMenu);
			Assert.IsNotNull(LockButton);
			Assert.IsNotNull(CharacterSelectPlayerPrefabs);
		}

		void Start() {
            CharacterSelectSlideMenu.OnFocusItemChangedCallback += (item) => {
                var entity = (GameEntity)item.gameObject.GetEntityLink().entity;
                _focusingCharacter = entity.character.Type;

                //TODO: get description from entity and show
                ShowUnitInformationUnit(entity);
            };
			var netCon = NetworkController.Instance;
			netCon.OnLocalPlayerStartCallback += SetLocalPlayer;
			netCon.OnClientPlayerStartCallback += AddPlayer;
			netCon.OnAllPlayerReadyCallback += MoveToGame;
		}

		private void OnDestroy()
		{
			var netCon = NetworkController.Instance;
			netCon.OnLocalPlayerStartCallback -= SetLocalPlayer;
			netCon.OnClientPlayerStartCallback -= AddPlayer;
			netCon.OnAllPlayerReadyCallback -= MoveToGame;
		}

		/// <summary>
		/// Lock character selection
		/// </summary>
		public void Lock()
		{
			_localPlayer.CmdSetCharacterId((int)_focusingCharacter);
		}

        /// <summary>
        /// Show Unit Info 
        /// </summary>
        public void ShowUnitInformationUnit(GameEntity unit) {
            //TODO : Set Character Status
            //Debug.Log("Unit null right ?"+(unit==null));
            Sprite sprite = Resources.Load<Sprite>(unit.resource.SpritePath);
            UnitStatus.setUnitStatus(unit.unitStatus.Name,sprite
                ,unit.unitStatus.HitPoint
                ,unit.unitStatus.AttackPower
                ,unit.unitStatus.AttackRange
                ,unit.unitStatus.VisionRange
                ,unit.unitStatus.MoveSpeed);
            //TODO : Set Character Ability
            /*UnitSkill.SetAbility(
                unit.ability.Ability
                );*/
        }

        #region UI RoleContent
		[Header("Role")]
        public Text RoleTitle, RoleDesciption;
        public Image RoleImage;

        public void ToggleViewRole() {
            bool isActive = this.RoleContent.activeInHierarchy;
            this.RoleContent.SetActive(!isActive);
            //this.CharacterContent.SetActive(isActive);
        }

        public void GodRole() {
            RoleTitle.text = "- "+RoleAndDescription.GOD_NAME+" -";
            RoleDesciption.text = "Win Condition"+ Environment.NewLine
                + RoleAndDescription.GOD_WIN_CONDITION;
            RoleImage.sprite = Resources.Load<Sprite>(RoleAndDescription.ICON_PATH_GOD);
        }

        public void ApostleRole() {
            RoleTitle.text = "- " + RoleAndDescription.APOSTLE_NAME + " -";
            RoleDesciption.text = "Win Condition" + Environment.NewLine
                + RoleAndDescription.APOSTLE_WIN_CONDITION;
            RoleImage.sprite = Resources.Load<Sprite>(RoleAndDescription.ICON_PATH_APOSTLE);
        }

        public void PriestRole() {
            RoleTitle.text = "- " + RoleAndDescription.PRIEST_NAME + " -";
            RoleDesciption.text = "Win Condition" + Environment.NewLine
                + RoleAndDescription.PRIEST_WIN_CONDITION;
            RoleImage.sprite = Resources.Load<Sprite>(RoleAndDescription.ICON_PATH_PRIEST);
        }

        public void AtheistRole() {
            RoleTitle.text = "- " + RoleAndDescription.ATHEIST_NAME + " -";
            RoleDesciption.text = "Win Condition" + Environment.NewLine
                + RoleAndDescription.ATHEIST_WIN_CONDITION;
            RoleImage.sprite = Resources.Load<Sprite>(RoleAndDescription.ICON_PATH_ATHEIST);
        }
		#endregion

		private void AddPlayer(Player player)
		{
			CharacterSelectPlayer charPlayer = Instantiate(CharacterSelectPlayerPrefabs,PlayerListContent.transform,false);
			charPlayer.SetPlayer(player);

			player.OnSelectedCharacterChangedCallback += DisableCharacterIcon;
		}

		public void SetLocalPlayer(Player player)
		{
			_localPlayer = player;

			var netCon = NetworkController.Instance;
			_localPlayer.CmdSetName(netCon.LocalPlayerName);

			_localPlayer.OnSelectedCharacterChangedCallback += OnLocalPlayerCharacterSelected;
		}

		/// <summary>
		/// Called when player is assigned character
		/// </summary>
		/// <param name="characterId">The character identifier.</param>
		public void OnLocalPlayerCharacterSelected(int characterId)
		{
			StartCoroutine(Ready());
			LockButton.interactable = false;
			NetworkController.Instance.SelectedCharacter = (Character)characterId;
		}

		System.Collections.IEnumerator Ready()
		{
			yield return new WaitForEndOfFrame();
			_localPlayer.CmdSetReadyStatus(true);
		}

		/// <summary>
		/// Disables the character selection icon.
		/// </summary>
		/// <param name="charId">The character identifier.</param>
		public void DisableCharacterIcon(int charId)
		{
			var character = (Character)charId;
			Assert.AreNotEqual(Character.None, character);

			var item = CharacterSelectSlideMenu.SlideItems.First(i =>
			{
				var entity = (GameEntity)i.gameObject.GetEntityLink().entity;
				return entity.character.Type == character;
			});

			//TODO: disable 'item'
			Debug.Log("disable " + item);
		}

		/// <summary>
		/// Moves to game. (Server)
		/// </summary>
		public void MoveToGame()
		{
			var netCon = NetworkController.Instance;
			netCon.ServerChangeScene(Scene.Game.ToString());
			NetMessage.SendPlayerCount(netCon.ConnectionCount);
		}
	}
}