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

        public Vector2 PositionOfMiddleItem {
            get {
                int itemCount = this.ItemCount;
                int half = itemCount / 2 - (itemCount%2==0&&itemCount>0?1:0);//getMiddle index of Content...
                Vector2 position = new Vector2(
                    (this.ItemSpace + this.ItemSize.x) + extraPosition.x
                    ,0);
                return position;
            }
        }

        private Vector2 extraPosition{
            get{
                float x = this.ItemCount % 2 == 0 ? -this.ItemSize.x / 2 : 0;
                return new Vector2(x,0f);
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
            ResizeItem();
        }


        public void ResizeItem() {
            float contentPosition = this.Content.transform.localPosition.x;
            int nearestIndex = getNearestItemIndex();
            foreach(SlideItem item in this.transform.GetComponentsInChildren<SlideItem>()) {
                item.SetScale(NonFocusIndexScale);
            }

            if(nearestIndex >= 0 && nearestIndex<ItemCount) {
                this.SlideItems[nearestIndex].SetScale(1);
                ShowDetail(nearestIndex);
            }
        }

        public Vector2 IndexToPosition(int index) {
            return new Vector2((this.ItemSpace + this.ItemSize.x) * -(index - ItemCount / 2) + extraPosition.x,0);
        }

        public int getNearestItemIndex() {
            float contentPosition = this.Content.transform.localPosition.x;
            return (int)(-((contentPosition-extraPosition.x) / (this.ItemSpace + this.ItemSize.x)) + (ItemCount / 2));
        }

        /// <summary>
        /// Force move Index to middle
        /// </summary>
        /// <param name="index"></param>
        public void FocusIndex(int index) {
            this.gameObject.GetComponent<ScrollRect>().StopMovement();
            int halfIndex = ItemCount/2;
            float newPosition = IndexToPosition(index).x;
            Debug.Log("Focus Index -> ["+index+"/"+ItemCount+"] at position ["+newPosition+"]");
            this.Content.transform.localPosition = new Vector3(
                    newPosition
                    ,0
                    ,0
                );
            ShowDetail(index);
        }

        private void ShowDetail(int index) {
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
