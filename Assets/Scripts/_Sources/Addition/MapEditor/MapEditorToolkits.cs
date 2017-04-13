
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MapEditor {
	public class MapEditorToolkits : MonoBehaviour {
		public static MapEditorToolkits Instance {
			get; private set;
		}
		public Camera CameraObject;

		public MapEditorController MapEditorController;

		[Header("TileMenu")]
		public Button ButtonPrefabs;
		public GameObject TileButtonContent;

		private Button _activeTileBrushButton;
		private Color _defaultColor;
		readonly Color ACTIVE_BUTTON_COLOR = new Color(0, 1f, 0);

		[Header("Hover")]
        public Image TileImage;
        public Text TileName,TilePosition;

        private Tile lastType;

        void Awake() {
            MapEditorToolkits.Instance = this;
        }

        // Use this for initialization
        void Start() {
			//TODO : SpawnButton :D
			//var tiles = MapEditorController.Setting.MapSetting.TileSetting.TileBlueprints;
			//var brush = TileBrushSystem.TileBrush;
			//foreach(Tile tile in Enum.GetValues(typeof(Tile))) {
			//    //Debug.Log(tile.ToString());
			//    Tile buttonTile = tile;
			//    Button b = Instantiate<Button>(ButtonPrefabs,TileButtonContent.transform,false);
			//    b.onClick.RemoveAllListeners();
			//    b.onClick.AddListener(()=>{
			//        TileButton(buttonTile);
			//    });
			//    b.GetComponentInChildren<Text>().text = tile.ToString();
			//    b.gameObject.SetActive(true);
			//}
			_defaultColor = ButtonPrefabs.image.color;
        }

		public Button CreateButton(Tile tileType)
		{
			var button = Instantiate(ButtonPrefabs, TileButtonContent.transform, false);
			button.GetComponentInChildren<Text>().text = tileType.ToString();
			button.gameObject.SetActive(true);
			return button;
		}

		public void SetActiveTileBrushButton(Button button)
		{
			if(_activeTileBrushButton != null)
			{
				_activeTileBrushButton.image.color = _defaultColor;
			}

			button.image.color = ACTIVE_BUTTON_COLOR;
			_activeTileBrushButton = button;
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

        public static void ShowHoverTile(TileEntity tile) {
            Instance.ShowDetailHoverTile(tile);
        }

        public void ShowDetailHoverTile(TileEntity tile) {
            //Debug.Log("Hover Tile >" + tile.View.GameObject.name);
            if(Instance.lastType != tile.tile.Type) {
                Instance.lastType = tile.tile.Type;
                Instance.TileImage.sprite = tile.sprite.Sprite;
            }
            Instance.TileName.text = tile.tile.Type.ToString();
            Instance.TilePosition.text = "[ " + tile.mapPosition.x + " , " + tile.mapPosition.y + " ]";
        }

        public void GodFillRectangle(int from_x,int from_y,int to_x,int to_y) {
            
        }
    }
}
