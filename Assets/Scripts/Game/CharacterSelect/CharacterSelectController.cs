using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using End.Game.UI.CharacterSelection;
using UnityEngine.UI;
using UnityEngine.Assertions;
using End.UI;
using Entitas.Unity;

namespace End.Game.CharacterSelect {
    public class CharacterSelectController : MonoBehaviour{

		public static CharacterSelectController Instance;

        public UnitStatus UnitStatus;
        public UnitSkill UnitSkill;

        public GameObject RoleContent,CharacterContent;
		public SlideMenu CharacterSelectSlideMenu;

		private void Awake()
		{
			Instance = this;

			Assert.IsNotNull(UnitStatus);
			Assert.IsNotNull(UnitSkill);
			Assert.IsNotNull(RoleContent);
			Assert.IsNotNull(CharacterContent);
			Assert.IsNotNull(CharacterSelectSlideMenu);
		}

		void Start() {
			CharacterSelectSlideMenu.OnFocusItemChangedCallback += (item) => {
				var entity = (GameEntity)item.gameObject.GetEntityLink().entity;
				Debug.Log(entity.character.Type);

				//TODO: get description from entity and show
				//ShowUnitInformationUnit(entity);
			};
        }

        public void SetPlayerInTheGame(List<object> players) {

        }

        /// <summary>
        /// Show Unit Info 
        /// </summary>
        public void ShowUnitInformationUnit(object unit) {
            //TODO : Set Character Status
            //UnitStatus.setCharacterStatus();
            
            //TODO : Set Character Ability
            //UnitSkill.SetAbility();
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
    }
}
