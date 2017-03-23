using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace End.UI {
    public class SlideMenu: MonoBehaviour {
        #region Setting
        public GameObject SlideItemContainer;
        public SlideItem SlideItemPrefabs;
        public Text ShowText;

        private bool isMouseDown;
        private ScrollRect scrollrect;
        #endregion

        #region Variable
        public Vector2 ItemSize;
        public float ItemSpace;
        public float NonFocusIndexScale;
        private float _keyupTime;
		public int FocusingIndex;

		public delegate void FocusItemChangeCallback(SlideItem item);
		public FocusItemChangeCallback OnFocusItemChangedCallback;
        #endregion

        public Vector2 PanelSize {
            get{
                return this.GetComponent<RectTransform>().rect.size;
            }
        }

        public SlideItem[] SlideItems {
            get{
                return this.SlideItemContainer.GetComponentsInChildren<SlideItem>();
            }
        }

		public int ItemCount {
            get{
                return SlideItems.Length;
            }
        }

        public Vector2 PositionOfMiddleItem {
            get {
                int itemCount = this.ItemCount;
                Vector2 position = new Vector2(
                    (this.ItemSpace + this.ItemSize.x) + _extraPosition.x
                    ,0);
                return position;
            }
        }

        private Vector2 _extraPosition{
            get{
                float x = this.ItemCount % 2 == 0 ? -this.ItemSize.x / 2 : 0;
                return new Vector2(x,0f);
            }
        }

		private void Awake()
		{
			this.scrollrect = this.gameObject.GetComponent<ScrollRect>();
		}

		void Start() {
            foreach(SlideItem item in SlideItems) {
				InitSlideItem(item);
            }
            FocusIndex(0);
        }

        void Update() {
            ResizeItem();
            if( Mathf.Abs(this.scrollrect.velocity.x) <= 1f && !this.isMouseDown){
                this.FocusIndex(GetNearestItemIndex());
            }
        }

		private void InitSlideItem(SlideItem item)
		{
			item.SetSize(ItemSize.x, ItemSize.y);
			item.SetScale(1f);
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
            return new Vector2((this.ItemSpace + this.ItemSize.x) * -(index - ItemCount / 2) + _extraPosition.x,0);
        }

		public int GetNearestItemIndex() {
			//float contentPosition = this.SlideItemContainer.transform.localPosition.x;
			var items = SlideItems;
			if (items.Length == 0) return 0;

			return SlideItems.ToList().IndexOf(
				items.OrderBy(i => Mathf.Abs(i.transform.position.x - transform.position.x)).First()
			);
            //return (int)Mathf.Round((-((contentPosition-_extraPosition.x) / (this.ItemSpace + this.ItemSize.x)) + (ItemCount / 2)));
        }

        /// <summary>
        /// Force move Index to middle
        /// </summary>
        /// <param name="index"></param>
        public void FocusIndex(int index) {
            float newPosition = IndexToPosition(index).x;
            //Debug.Log("Focus Index -> ["+index+"/"+ItemCount+"] at position ["+newPosition+"]");
            this.SlideItemContainer.transform.localPosition = new Vector3(
                    newPosition
                    ,0
                    ,0
                );

			//focus index change
			if(index != FocusingIndex)
			{
				if (OnFocusItemChangedCallback != null) OnFocusItemChangedCallback(SlideItems[index]);
				FocusingIndex = index;
			}

            ShowDetail(index);
        }

        public void RandomFocus() {
            FocusIndex(UnityEngine.Random.Range(0, ItemCount));
        }

        public void ShowDetail(int index) {
            if(index >= 0 && index < ItemCount) this.ShowText.text = SlideItems[index].ShowText;
        }

		/// <summary>
		/// Create and add new SlideItem.
		/// </summary>
		/// <returns>created SlideItem</returns>
		public SlideItem AddItem() {
            SlideItem item = Instantiate(SlideItemPrefabs,SlideItemContainer.transform,false);
			InitSlideItem(item);
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
