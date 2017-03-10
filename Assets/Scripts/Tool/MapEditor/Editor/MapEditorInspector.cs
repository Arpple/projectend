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
				brush.Action = (BrushAction)EditorGUILayout.EnumPopup("Brush Action", brush.Action);
				if (brush.Action == BrushAction.Tile)
				{
					brush.TileType = (Tile)EditorGUILayout.EnumPopup("Tile Type", brush.TileType);
				}
				else if(brush.Action == BrushAction.Spawnpoint)
				{
					brush.SpawnpointIndex = EditorGUILayout.IntField("Spawnpoint Index", brush.SpawnpointIndex);
					if (brush.SpawnpointIndex < 0 || brush.SpawnpointIndex > Player.MAX_PLAYER)
					{
						brush.SpawnpointIndex = 0;
						Debug.LogWarning("spawn point index should be player id (1-" + Player.MAX_PLAYER + ")");
					}
				}
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
						if(tileEntity.hasSpawnpoint)
						{
							map.SetSpawnPoint(tileEntity.spawnpoint.index, tileEntity.mapPosition);
						}
					}
					map.Save();
					ProjectWindowUtil.CreateAsset(map, "Assets/Resources/Game/Map/NewMap.asset");
				}
			}
		}
	}

}
