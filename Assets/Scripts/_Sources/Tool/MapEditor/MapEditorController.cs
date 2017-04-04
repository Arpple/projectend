using Entitas;
using System;
using UnityEngine;
using UnityEngine.Assertions;
using Game;

namespace MapEditor
{
	public class MapEditorController : MonoBehaviour
	{
		[Serializable]
		public class MapInfo
		{
			public int Width;
			public int Heigth;
			public Tile DefaultTileType = Tile.Grass;
		}

		public static MapEditorController Instance;
		public static Map EdittingMap;

		[Header("Load Map")]
		public Map LoadingMap;
		
		[Header("New Map")]
		public bool IsCreatingNewMap;
        public string MapName;
		public MapInfo CreatingMap;

		[Header("Setting")]
		public MapEditorSetting Setting;

		private Systems _systems;
		private Contexts _contexts;

		void Awake()
		{
			Instance = this;
		}

		void Start()
		{
			_contexts = Contexts.sharedInstance;
			_systems = CreateSystems(_contexts);
			_systems.Initialize();
		}

		void Update()
		{
			Assert.IsTrue(_systems != null);

			_systems.Execute();
			_systems.Cleanup();
		}

		void OnDestory()
		{
			Assert.IsTrue(_systems != null);

			_systems.TearDown();
		}

		Systems CreateSystems(Contexts contexts)
		{
			EdittingMap = InitMap();

			return new Feature("Systems")
				.Add(new CreateMapTileSystem(contexts, EdittingMap, Setting.MapSetting))
				.Add(new CreateTileGraphSystem(contexts))
			
				.Add(new LoadResourceSystem(contexts))
                .Add(new TileHoverActionSystem(contexts))
                
				.Add(new RenderMapPositionSystem(contexts))
				.Add(new TileBrushSystem(contexts, Setting.MapSetting.TileSetting))
                .Add(new TileDetailSystem(contexts))

                .Add(new CameraSystem(contexts))
				.Add(new CameraKeyboardSystem(contexts));

		}

		Map InitMap()
		{
			//create new map
			if(IsCreatingNewMap)
			{
				if(CreatingMap.Width > 0 && CreatingMap.Heigth > 0)
				{
					Debug.Log("Creating New Map w:" + CreatingMap.Width +" h:" + CreatingMap.Heigth + " t:" + CreatingMap.DefaultTileType.ToString());
					return ScriptableObject.CreateInstance<Map>().SetMap(CreatingMap.Width, CreatingMap.Heigth, CreatingMap.DefaultTileType);
				}
				else
				{
					Debug.LogError("map size invalid");
				}
			}

			//load from old map
			else
			{
				if(LoadingMap != null)
				{
					Debug.Log("Load Map : " + LoadingMap.name);
					return LoadingMap.Load();
				}
			}

			//default
			Debug.Log("Create Default Map");
			return ScriptableObject.CreateInstance<Map>().SetMap(5, 5, Tile.Grass);
		}
	}

}

