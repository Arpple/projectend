using UnityEngine;
using NUnit.Framework;
using Entitas;
using End.Game;
using System;
using System.Reflection;

namespace End.Test
{
	public class TestLoadAbilitySystem
	{
		private Contexts _contexts;

		

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
		}

		[Test]
		public void AbilityCreate()
		{
			var system = new LoadAbilitySystem(_contexts);

			var e = _contexts.game.CreateEntity();
			e.AddAbility("End.Game.AbilityMove", null);

			system.Execute();

			Assert.IsNotNull(e.ability.Ability);
		}
	}
}

