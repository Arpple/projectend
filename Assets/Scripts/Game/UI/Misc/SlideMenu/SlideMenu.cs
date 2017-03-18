using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace End.UI {
    public class SlideMenu: MonoBehaviour {
        #region Setting
        public GameObject Content;
        public SlideItem SlideItemPrefabs;
        public Text ShowText;

        private bool isMouseDown;
        private ScrollRect scrollrect;
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
            //Debug.Log("Start");
            foreach(SlideItem item in transform.GetComponentsInChildren<SlideItem>()) {
                item.SetSize(ItemSize.x,ItemSize.y);
                item.SetScale(1f);
            }
            FocusIndex(0);
            this.scrollrect = this.gameObject.GetComponent<ScrollRect>();
        }

        void Update() {
            ResizeItem();
            if( Mathf.Abs(this.scrollrect.velocity.x) <= 1f && !this.isMouseDown){
                this.FocusIndex(GetNearestItemIndex());
            }
        }


        private void ResizeItem() {
            int nearestIndex = GetNearestItemIndex();
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

		private int GetNearestItemIndex() {
            float contentPosition = this.Content.transform.localPosition.x;
            return (int)Mathf.Round((-((contentPosition-extraPosition.x) / (this.ItemSpace + this.ItemSize.x)) + (ItemCount / 2)));
        }

        /// <summary>
        /// Force move Index to middle
        /// </summary>
        /// <param name="index"></param>
        private void FocusIndex(int index) {
            float newPosition = IndexToPosition(index).x;
            //Debug.Log("Focus Index -> ["+index+"/"+ItemCount+"] at position ["+newPosition+"]");
            this.Content.transform.localPosition = new Vector3(
                    newPosition
                    ,0
                    ,0
                );
            ShowDetail(index);
        }

        private void ShowDetail(int index) {
            if(index >= 0 && index < ItemCount) this.ShowText.text = SlideItems[index].ShowText;
        }

        public SlideItem AddUnit(GameEntity unitEntity) {
            SlideItem item = Instantiate(SlideItemPrefabs,Content.transform,false);
            return item;
        }

        public void OnMouseDown() {
            isMouseDown = true;
        }

        public void OnMouseUp() {
            isMouseDown = false;
        }
    }

}
