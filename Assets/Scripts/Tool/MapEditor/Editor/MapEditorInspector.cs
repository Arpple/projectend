using UnityEditor;
using UnityEngine;
using End.Game;

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
						brush.SpawnpointIndex = 1;
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
					var spawnpointCount = 0;

					foreach (var tileEntity in Contexts.sharedInstance.game.GetGroup(GameMatcher.Tile).GetEntities())
					{
						map.SetTile(tileEntity.mapPosition, tileEntity.tile.Type);
						if(tileEntity.hasSpawnpoint)
						{
							map.SetSpawnPoint(tileEntity.spawnpoint.index, tileEntity.mapPosition);
							spawnpointCount++;
						}
					}
					if(spawnpointCount < Player.MAX_PLAYER)
					{
						Debug.LogWarning("Spawnpoint is less than maximum player (" + spawnpointCount + "/" + Player.MAX_PLAYER + ")");
					}

					map.Save();
					ProjectWindowUtil.CreateAsset(map, "Assets/Resources/Game/Map/NewMap.asset");
				}
			}
		}
	}

}
