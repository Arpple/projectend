﻿using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Entitas;
using UnityEngine.Assertions;

namespace End
{
	public class GameController : MonoBehaviour
	{
		public static GameController Instance;

		public static bool IsOffline
		{
			get { return Instance.IsOfflineMode; }
		}

		[Header("Test")]
		public bool IsOfflineMode = false;

		[Header("Config")]
		public GameSetting Setting;

		private Systems _systems;
		private Contexts _contexts;

		void Awake()
		{
			Instance = this;
		}

		void Start()
		{
			_contexts = Contexts.sharedInstance;
			_contexts.SetAllContexts();
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
			return new Feature("Systems")
				.Add(new LoadResourceSystem(contexts));
		}
	}
}
