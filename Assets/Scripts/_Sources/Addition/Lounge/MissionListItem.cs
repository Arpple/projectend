using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Lounge {
    public class MissionListItem : MonoBehaviour
	{
        [Header("UI")]
        public Text MissionNameText;
        public Image Background;

        [Header("Attribute")]
        public bool isWorldMission;
        public string Description;
        public string Target;
        public Action<MissionListItem> ClickAction;
		public Color FocusColor = new Color(1f, 227f / 255f, 0f, 1f);
		public Color NonFocusColor = new Color(69f / 255f, 69f / 255f, 0f, 1f);

        public void OnFocus() {
            Background.color = FocusColor;
        }

        public void OnUnfocus() {
			Background.color = NonFocusColor;
        }

        public void OnClick() {
            ClickAction(this);
        }
    }
}
