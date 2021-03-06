﻿using System;
using Entitas;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

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

		
		public GameObject SpawnpointPrefabs;
		public GameObject BossSpawnpointPrefabs;

		private Systems _systems;
		private Contexts _contexts;
		private Setting _setting;

		[Inject]
		public void Construct(Setting setting)
		{
			_setting = setting;
		}

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
				.Add(new TileMapCreatingSystem(contexts, EdittingMap))
				.Add(new TileGraphCreatingSystem(contexts))

				.Add(new TileDataLoadingSystem(contexts, _setting.TileSetting))
				.Add(new TileViewCreatingSystem(contexts, _setting.TileSetting, new GameObject("Tile")))
				.Add(new SpawnpointViewCreatingSystem(contexts, SpawnpointPrefabs, BossSpawnpointPrefabs))
				.Add(new SpawnpointViewDestroySystem(contexts))
				.Add(new TileSpriteUpdateSystem(contexts))
				
				.Add(new TileActionSystem(contexts))
				.Add(new TileHoverActionSystem(contexts))
				.Add(new TilePositionRenderingSystem(contexts))
				.Add(new TileDetailSystem(contexts, MapEditorToolkits.Instance))
				.Add(new TileBrushSystem(contexts))
				.Add(new ToolKitsButtonSetupSystem(_contexts, MapEditorToolkits.Instance))

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

