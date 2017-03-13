using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace End.UI {
    public class SlideMenu: MonoBehaviour {
        #region Setting
        public GameObject Content;
        public SlideItem PrefabsItem;
        public Text ShowText;
        #endregion

        #region Variable
        public Vector2 ItemSize;
        public float ItemSpace;
        public float NonFocusIndexScale;
        #endregion

        private Vector2 PanelSize {
            get{
                return this.GetComponent<RectTransform>().rect.size;
            }
        }

        private SlideItem[] SlideItems {
            get{
                return this.Content.GetComponentsInChildren<SlideItem>();
            }
        }

        private int ItemCount {
            get{
                return this.Content.transform.GetComponentsInChildren<SlideItem>().Length;
            }
        }

        void Start() {
            foreach(SlideItem item in transform.GetComponentsInChildren<SlideItem>()) {
                item.SetSize(ItemSize.x,ItemSize.y);
                item.SetScale(1f);
            }
            FocusIndex(0);
        }

        void Update() {
            Something();
        }

        public void Something() {
            float contentPosition = this.Content.transform.localPosition.x;
            int nearestIndex = getNearestItemIndex();
            Debug.Log("NearestIndex = "+nearestIndex);

            foreach(SlideItem item in this.transform.GetComponentsInChildren<SlideItem>()) {
                item.SetScale(this.NonFocusIndexScale);
            }

            if(nearestIndex >= 0 && nearestIndex<ItemCount) {
                this.SlideItems[nearestIndex].SetScale(1);
            }
        }

        public int getNearestItemIndex() {
            float contentPosition = this.Content.transform.localPosition.x;
            return (int)(-(contentPosition / (this.ItemSpace + this.ItemSize.x)) + (ItemCount / 2));

        }

        public void FocusIndex(int index) {
            this.gameObject.GetComponent<ScrollRect>().StopMovement();
            int halfIndex = ItemCount/2;
            float newPosition = (this.ItemSpace + this.ItemSize.x) * -(index - halfIndex);
            Debug.Log("Focus Index -> ["+index+"/"+ItemCount+"] at position ["+newPosition+"]");
            this.Content.transform.localPosition = new Vector3(
                    newPosition
                    ,0
                    ,0
                );

            this.ShowText.text = SlideItems[index].ShowText;
        }

        public SlideItem AddItem() {
            SlideItem item = Instantiate<SlideItem>(PrefabsItem,Content.transform,false);
            return item;
        }

        public void OnMouseDown() {

        }

        public void OnMouseUp() {
            this.FocusIndex(getNearestItemIndex());
        }
    }

}
