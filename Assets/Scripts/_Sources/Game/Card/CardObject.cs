using System;
using UnityEngine;
using UnityEngine.UI;
using Entitas.Unity;

namespace Game.UI
{
	public class CardObject : MonoBehaviour
	{
		public Image MainImage;
        public Animator Animator;

		public CardEntity Entity
		{
			get { return (CardEntity)gameObject.GetEntityLink().entity; }
		}

		public void SetAbilityImage(Sprite sprite)
		{
			MainImage.sprite = sprite;
		}

		public void OnClick()
		{
			GameUI.Instance.OnCardClicked(this);
            this.ShowHighlight(); //! TEST
        }
        
        public void ShowHighlight() {
            this.Animator.Play("ShowHighlight");
        }

        public void HideHighlight() {
            this.Animator.Play("Idle");
        }
	}

}
