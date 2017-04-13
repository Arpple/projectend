using UnityEditor;
using UnityEngine;


namespace MapEditor
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
					if (brush.SpawnpointIndex < 0 || brush.SpawnpointIndex > 8)//Player.MAX_PLAYER)
					{
						brush.SpawnpointIndex = 1;
						Debug.LogWarning("spawn point index should be player id (1-" + 8 + ")");
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

					foreach (var tile in Contexts.sharedInstance.tile.GetGroup(TileMatcher.Tile).GetEntities())
					{
						map.SetTile(tile.mapPosition, tile.tile.Type);
						if(tile.hasSpawnpoint)
						{
							map.SetSpawnPoint(tile.spawnpoint.index, tile.mapPosition);
							spawnpointCount++;
						}
					}
					if(spawnpointCount < 8)//Player.MAX_PLAYER)
					{
						Debug.LogWarning("Spawnpoint is less than maximum player (" + spawnpointCount + "/" + 8 + ")");
					}

					map.Save();

                    //TODO : Have map?
                    string path = "Assets/Resources/Tile/Map/" + mapEditor.MapName + ".asset";
                    Map saveFile = AssetDatabase.LoadMainAssetAtPath(path) as Map;
                    if(saveFile==null) {
                        //TODO : New File
                        //ProjectWindowUtil.CreateAsset(map, "Assets/Resources/Game/Map/NewMap.asset");
                        AssetDatabase.CreateAsset(map, path);
                    } else {
                        //Overwrite..
                        EditorUtility.CopySerialized(map, saveFile);
                        AssetDatabase.SaveAssets();
                    }
                    

                }
            }
		}
	}

}
