using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
namespace End.Game.UI.CharactorSelection {
    public class UnitStatus : MonoBehaviour{
        public Text HitPoint, AttackPower, AttackRange, VisionRange, MoveSpeed
            ,UnitName;
        public Image UnitImage;

        /// <summary>
        /// show unit status by parameter
        /// </summary>
        /// <param name="charName"></param>
        /// <param name="hp"></param>
        /// <param name="ap"></param>
        /// <param name="ar"></param>
        /// <param name="vs"></param>
        /// <param name="ms"></param>
        public void setUnitStatus(string charName,Sprite charImage,int hp,int ap,int ar,int vs,int ms) {
            this.UnitName.text = charName;
            this.HitPoint.text = hp.ToString();
            this.AttackPower.text = ap.ToString();
            this.AttackRange.text = ar.ToString();
            this.VisionRange.text = vs.ToString();
            this.MoveSpeed.text = ms.ToString();
            this.UnitImage.sprite = charImage;
        }
    }
}
