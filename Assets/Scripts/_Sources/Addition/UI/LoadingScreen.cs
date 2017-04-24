using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour{
    public Text LoadingText;
    private int count;
    private float startTime = 0;
    void Update() {
        if(Time.time > startTime+1f) {
            startTime = Time.time;
            this.LoadingText.text = "Loading" + (count == 0 ? "" : (count == 1 ? " ." : (count == 2 ? " .." : " ...")));
            count = (count + 1) % 4;
        }
    }
}
