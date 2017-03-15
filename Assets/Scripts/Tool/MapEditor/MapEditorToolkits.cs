using End.Game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace End.MapEditor {
    public class MapEditorToolkits: MonoBehaviour {
        public Button ButtonPrefabs;
        public Camera camera;

        public GameObject TileButtonContent;
        public MapEditorController MapEditorController;

        // Use this for initialization
        void Start() {
            //TODO : SpawnButton :D
            var tiles = MapEditorController.Setting.MapSetting.TileSetting.TileBlueprints;
            var brush = TileBrushSystem.TileBrush;
            foreach(Tile tile in Enum.GetValues(typeof(Tile))) {
                //Debug.Log(tile.ToString());
                Tile buttonTile = tile;
                Button b = Instantiate<Button>(ButtonPrefabs,TileButtonContent.transform,false);
                b.onClick.RemoveAllListeners();
                b.onClick.AddListener(()=>{
                    TileButton(buttonTile);
                });
                b.GetComponentInChildren<Text>().text = tile.ToString();
                b.gameObject.SetActive(true);
            }
        }
        public void TileButton(Tile t) {
            Debug.Log("Tile "+t.ToString()+" Select ");
            TileBrushSystem.TileBrush.TileType = t;
        }

        void Update() {
            Zoom();
        }

        private void Zoom(){
            if(Input.GetAxis("Mouse ScrollWheel") > 0f) {
                if(this.camera.orthographicSize > 1) {
                    this.camera.orthographicSize--;
                }
            } else if(Input.GetAxis("Mouse ScrollWheel") < 0f){
                if(this.camera.orthographicSize < 30) {
                    this.camera.orthographicSize++;
                }
            }
        }
    }
}
