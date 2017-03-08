using UnityEditor;
using UnityEngine;
using System.Linq;

namespace End.MapEditor
{
	[CustomEditor(typeof(MapEditorController))]
	public class MapEditorInspector : Editor
	{
		public override void OnInspectorGUI ()
		{
			DrawDefaultInspector();

			MapEditorController mapEditor = (MapEditorController)target;

			EditorGUILayout.LabelField("Map Editor Brush", EditorStyles.boldLabel);
			var brush = TileBrushSystem.TileBrush;
			if (brush != null)
			{
				brush.TileType = (Tile)EditorGUILayout.EnumPopup("Tile Type", brush.TileType);
				brush.Action = (BrushAction)EditorGUILayout.EnumPopup("Brush Action", brush.Action);
			}

			if (Application.isPlaying)
			{
				EditorGUILayout.Space();
				if (GUILayout.Button("Save"))
				{
					var map = MapEditorController.EdittingMap;

					foreach (var tileEntity in Contexts.sharedInstance.game.GetGroup(GameMatcher.Tile).GetEntities())
					{
						map.SetTile(tileEntity.mapPosition, tileEntity.tile.Type);
					}

					ProjectWindowUtil.CreateAsset(map, "Assets/Resources/Game/Map/NewMap.asset");
				}
			}
		}
	}

}
