using Entitas;
using Network;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lounge {
    public class MissionBookController: MonoBehaviour {
        [Header("Setting")]
        public MissionSetting setting;

        [Header("World Mission")]
        public Text WorldMissionName;
        public Text WorldMissionDescription;
        public Text WorldMissionTarget;

        [Header("Personal Mission")]
        public Text MissionName;
        public Text MissionDescription;
        public Text MissionTarget;

        [Header("Book List")]
        public MissionListItem Item;
        public GameObject content;
        public GameObject SecondPage;
        public Text SelectedMissionName;
        public Text SelectedMissionTarget;
        public Text SelectedMissionDescription;
        private List<MissionListItem> Items = new List<MissionListItem>();


        public void Init(GameEntity playerEntity,MissionSetting setting) {
            this.setting = setting;
            CreateMissionItems();

            MainMissionData worldMission = setting.MainMission.DataList.Find(
                mission => (int)mission.Type == playerEntity.player.GetNetworkPlayer().MainMissionId
                );
            SetWorldMission(worldMission.Name
                , worldMission.Description
            );

            try {
                //TODO : Add target player Name.
                PlayerMissionData playerMission = setting.PlayerMission.DataList.Find(
                mission => (int)mission.Type == playerEntity.player.GetNetworkPlayer().PlayerMissionId
                );
                SetPersonalMission(playerMission.Name
                    , playerMission.Description
                    , NetworkController.Instance.AllPlayers.Find(player => player.PlayerId == playerEntity.player.GetNetworkPlayer().PlayerId).PlayerName
                    //playerEntity.playerMissionTarget.TargetEntity.player.GetNetworkPlayer().PlayerName
                );
            } catch(NullReferenceException e) {
                Debug.Log("Player or Player Mission is null");
            } catch(EntityDoesNotHaveComponentException e) {
                Debug.Log(e.ToString());
            }
        }

        private void CreateMissionItems() {
            //Create player mission
            foreach(PlayerMissionData mission in setting.PlayerMission.DataList) {
                Items.Add(
                    InstanctiateItem(false,mission.Name,mission.Description,mission.RandomPlayer)
                );
            }
            //Create world mission
            foreach(MainMissionData mission in setting.MainMission.DataList) {
                Items.Add(
                    InstanctiateItem(true,mission.Name, mission.Description, true)
                );
            }
        }

        private MissionListItem InstanctiateItem(bool isWorldMission,string missionName,string missionDescription,bool hasTarget) {
            MissionListItem item = Instantiate<MissionListItem>(Item,content.transform,false);
            item.isWorldMission = isWorldMission;
            item.missionName.text = missionName;
            item.Description = missionDescription;
            item.target = hasTarget ? "Yes" : "None" ;
            item.ClickAction = SelectItem;
            return item;
        }

        public void SetWorldMission(string name,string description) {
            this.WorldMissionName.text = name;
            this.WorldMissionDescription.text = description;
        }

        public void SetPersonalMission(string name,string description,string target) {
            this.MissionName.text = name;
            this.MissionDescription.text = description;
            this.MissionTarget.text = target;
        }

        public void ShowWorldMission() {
            SecondPage.SetActive(true);
            foreach(MissionListItem item in Items) {
                item.gameObject.SetActive(item.isWorldMission);
            }
        }

        public void ShowPersonalMisison() {
            SecondPage.SetActive(true);
            foreach(MissionListItem item in Items) {
                item.gameObject.SetActive(!item.isWorldMission);
            }
        }

        public void SelectItem(MissionListItem item) {
            this.SelectedMissionName.text = item.missionName.text;
            this.SelectedMissionDescription.text = item.Description;
            this.SelectedMissionTarget.text = item.target;
            
            //Show Highlight
            foreach(MissionListItem other in Items) {
                other.OnUnfocus();
            }

            item.OnFocus();
        }
    }
}
