using Game;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MapEditor {
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
            //var tiles = MapEditorController.Setting.MapSetting.TileSetting.TileBlueprints;
            //var brush = TileBrushSystem.TileBrush;
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
            //Debug.Log("Tile "+t.ToString()+" Select ");
            TileBrushSystem.TileBrush.TileType = t;
            Text text;
            var col = ButtonPrefabs.GetComponent<Button>().colors;
            var selectedCol = ButtonPrefabs.GetComponent<Button>().colors;

            selectedCol.normalColor = new Color(0,1f,0);

            foreach(Button button in Instance.TileButtonContent.GetComponentsInChildren<Button>()) {
                text = button.GetComponentInChildren<Text>();
                if(text.text.Equals(t.ToString())) {
                    button.colors = selectedCol;
                } else {
                    button.colors = col;
                }
            }
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
            //Debug.Log("Hover Tile >" + tile.gameView.GameObject.name);
            if(Instance.lastType != tile.gameTile.Type) {
                Instance.lastType = tile.gameTile.Type;
                Instance.TileImage.sprite = Resources.Load<Sprite>(tile.gameResource.SpritePath);
            }
            Instance.TileName.text = tile.gameTile.Type.ToString();
            Instance.TilePosition.text = "[ " + tile.gameMapPosition.x + " , " + tile.gameMapPosition.y + " ]";
        }

        public void GodFillRectangle(int from_x,int from_y,int to_x,int to_y) {
            
        }
    }
}
