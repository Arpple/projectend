using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestChangeImage : MonoBehaviour {
    public string ImagePath;
    public GameObject gOImage;

    public Image Image;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeByPrefabs() {
        GameObject g = Instantiate<GameObject>(gOImage,Image.transform,false);
    }

    public void ChangeByImage() {
        this.Image.sprite = Resources.Load<Sprite>(ImagePath);
    }
}
