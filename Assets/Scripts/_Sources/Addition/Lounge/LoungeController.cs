using System.Collections.Generic;
using System.Linq;
using Entitas.Unity;
using Network;
using UI;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using Zenject;

namespace Lounge
{
	public abstract class LoungeController : MonoBehaviour
	{

		public static LoungeController Instance;	

		public UnitStatusPanel UnitStatus;
		public UnitSkillPanel UnitSkill;

		public GameObject CharacterContent,PlayerListContent;
		public SlideMenu CharacterSelectSlideMenu;
		public Button LockButton;
		public LoungePlayer CharacterSelectPlayerPrefabs;

        [Header("MissionBook")]
        public MissionBookController MissionBook;

		protected Setting _setting;
		protected Character _focusingCharacter;
		protected Player _localPlayer;

		[Inject]
		public void Construct(Setting setting)
		{
			_setting = setting;	
		}

		protected void Awake()
		{
			Instance = this;

			Assert.IsNotNull(UnitStatus);
			Assert.IsNotNull(UnitSkill);
			Assert.IsNotNull(CharacterContent);
			Assert.IsNotNull(CharacterSelectSlideMenu);
			Assert.IsNotNull(LockButton);
			Assert.IsNotNull(CharacterSelectPlayerPrefabs);
			Assert.IsNotNull(_setting);
		}

		public abstract List<Player> GetAllPlayers();
		public abstract Player GetLocalPlayer();
		protected abstract void LockFocusingCharacter();

		protected virtual void Start()
		{
			MissionBook.LoadData(_setting.MissionSetting);
			UnitSkill.Initialize(_setting.CardSetting.SkillCardSetting);

			foreach (var player in GetAllPlayers())
			{
				AddPlayer(player);
			}

			SetLocalPlayer(GetLocalPlayer());

			LockButton.onClick.AddListener(LockFocusingCharacter);
			CharacterSelectSlideMenu.OnFocusItemChangedCallback += FocusCharacterIcon;
		}

		private void FocusCharacterIcon(SlideItem characterIcon)
		{
			var entity = (UnitEntity)characterIcon.gameObject.GetEntityLink().entity;
			_focusingCharacter = entity.character.Type;

			ShowUnitInformationUnit(entity);
		}

		/// <summary>
		/// Show Unit Info 
		/// </summary>
		public void ShowUnitInformationUnit(UnitEntity unit) {
			UnitStatus.SetUnit(unit);
			UnitSkill.SetUnit(unit);
		}

		
		private void AddPlayer(Player player)
		{
			LoungePlayer charPlayer = Instantiate(CharacterSelectPlayerPrefabs,PlayerListContent.transform,false);
			charPlayer.SetPlayer(player);

			player.OnSelectedCharacterChangedCallback += DisableCharacterIcon;
			player.OnPlayerMissionChangedCallback = MissionBook.SetLocalPlayerMission;
			player.OnPlayerMissionTargetIdChangedCallback = MissionBook.SetLocalPlayerTarget;
		}

		public virtual void SetLocalPlayer(Player player)
		{
			_localPlayer = player;
			_localPlayer.OnSelectedCharacterChangedCallback += OnLocalPlayerCharacterSelected;

			MissionBook.SetLocalMainMission((MainMission)player.MainMissionId);
		}

		/// <summary>
		/// Called when player is assigned character
		/// </summary>
		/// <param name="characterId">The character identifier.</param>
		public void OnLocalPlayerCharacterSelected(int characterId)
		{
			StartCoroutine(Ready());
			LockButton.interactable = false;
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
				var entity = (UnitEntity)i.gameObject.GetEntityLink().entity;
				return entity.character.Type == character;
			});

			//TODO: disable 'item'
			Debug.Log("disable " + item);
		}

		/// <summary>
		/// Moves to game. (Server)
		/// </summary>
		public void LoadGameScene()
		{
			var netCon = NetworkController.Instance;
			netCon.ServerChangeScene(GameScene.Game.ToString());
		}
	}
}
