using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Lounge {
    public class MissionListItem : MonoBehaviour{
        [Header("UI")]
        public Text missionName;
        public Image Background;

        [Header("Attribute")]
        public bool isWorldMission;
        public string Description;
        public string target;
        public Action<MissionListItem> ClickAction;

        public void OnFocus() {
            Background.color = new Color(1f,227f / 255f, 0f,1f);
        }

        public void OnUnfocus() {
            Background.color = new Color(69f / 255f, 69f / 255f, 0f, 1f);
        }

        public void OnClick() {
            ClickAction(this);
        }
    }
}
