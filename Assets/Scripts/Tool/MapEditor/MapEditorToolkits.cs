﻿using End.Game;
using Entitas.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace End.MapEditor {
    public class MapEditorToolkits: MonoBehaviour {
        public static MapEditorToolkits Instance{
            get;private set;
        }
        public Camera CameraObject;
        
        public MapEditorController MapEditorController;

        #region TileMenu
        public Button ButtonPrefabs;
        public GameObject TileButtonContent;
        #endregion

        #region Hover
        public Image TileImage;
        public Text TileName,TilePosition;
        private Tile lastType;
        #endregion

        void Awake() {
            MapEditorToolkits.Instance = this;
        }

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
                if(this.CameraObject.orthographicSize > 1) {
                    this.CameraObject.orthographicSize--;
                }
            } else if(Input.GetAxis("Mouse ScrollWheel") < 0f){
                if(this.CameraObject.orthographicSize < 30) {
                    this.CameraObject.orthographicSize++;
                }
            }
        }

        public static void ShowHoverTile(GameEntity tile) {
            Instance.ShowDetailHoverTile(tile);
        }

        public void ShowDetailHoverTile(GameEntity tile) {
            Debug.Log("Hover Tile >" + tile.view.GameObject.name);
            if(Instance.lastType != tile.tile.Type) {
                Instance.lastType = tile.tile.Type;
                Instance.TileImage.sprite = Resources.Load<Sprite>(tile.resource.SpritePath);
            }
            Instance.TileName.text = tile.tile.Type.ToString();
            Instance.TilePosition.text = "[ " + tile.mapPosition.x + " , " + tile.mapPosition.y + " ]";
        }
    }
}
