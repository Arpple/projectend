using Entitas.Unity;
using NUnit.Framework;
using UnityEngine;
using System;
using End.Game;
using End.Game.CharacterSelect;

namespace End.Test
{
	public class LoadResourceSystem
	{
		private Contexts _contexts;
		private Game.CharacterSetting _setting;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
			_setting = TestHelper.GetGameSetting().UnitSetting.CharacterSetting;
		}

		[Test]
		public void EntityCreateCountMatchEnum()
		{
			var targetCount = Enum.GetNames(typeof(Character)).Length;

			var system = new LoadAllCharacterSystems(_contexts, _setting);
			system.Initialize();

			Assert.AreEqual(targetCount, _contexts.game.GetEntities().Length);
		}
	}

	
}

