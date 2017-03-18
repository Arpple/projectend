using UnityEngine;
using UnityEngine.UI;

namespace End.UI {

    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Mask))]
    /// <summary>
    /// Item slide is a frame of item in slidemenu only
    /// Content is a object that show graphic on screen
    /// </summary>
    public class SlideItem: MonoBehaviour {
        public GameObject Content;
        public string ShowText;
        
        /// <summary>
        /// Change Content scale Size
        /// </summary>
        /// <param name="scale">input percentage in format 0.5 = 50%</param>
        public void SetScale(float scale) {
            this.Content.gameObject.transform.localScale = new Vector3(scale, scale, scale);
        }

        /// <summary>
        /// Change Slide Item Size
        /// </summary>
        /// <param name="size"></param>
        public void SetSize(float x,float y) {
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(x, y);
        }

        public void SetText(string text) {
            this.ShowText = text;
        }
    }
}
