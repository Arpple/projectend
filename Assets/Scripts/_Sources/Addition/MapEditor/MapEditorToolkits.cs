
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

		void Start() {
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

		public void ShowTileDetail(TileEntity tile) {
			//Debug.Log("Hover Tile >" + tile.View.GameObject.name);
			if(lastType != tile.tile.Type) {
				lastType = tile.tile.Type;
				TileImage.sprite = tile.sprite.Sprite;
			}
			TileName.text = tile.tile.Type.ToString();
			TilePosition.text = tile.mapPosition.ToString();
		}

		public void GodFillRectangle(int from_x,int from_y,int to_x,int to_y) {
			
		}
	}
}
