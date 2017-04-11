using System;
using UnityEngine;
using UnityEngine.UI;

namespace MapEditor
{
	public class MapEditorFillTile : MonoBehaviour{
        public MapEditorToolkits toolKits;
        public MapEditorController mapEditor;

        public GameObject contentView;

        public InputField from_x, from_y, to_x, to_y;
        
        public void FillTile() {
            int from_x=Int32.Parse(this.from_x.text), from_y=Int32.Parse(this.from_y.text);
            int to_x=Int32.Parse(this.to_x.text),to_y=Int32.Parse(this.to_y.text);

            Tile tile = TileBrushSystem.TileBrush.TileType;

            for(int y = from_y; y <= to_y; y++) {
                for(int x = from_x; x <= to_x; x++) {
                    Debug.Log("Fill Tile ["+x+","+y+"] with ["+tile.ToString()+"]" );
                    mapEditor.LoadingMap.SetTile(x, y, tile);
                }
            }
        }

        public void Toogle() {
            this.contentView.SetActive(!this.contentView.gameObject.activeInHierarchy);
        }
    }
}
