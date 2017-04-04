﻿using NUnit.Framework;
using Game;

namespace Test.System
{
	public class TestLoadAbilitySystem : ContextsTest
	{
		[Test]
		public void AbilityCreate()
		{
			var system = new LoadAbilitySystem(_contexts);

			var e = _contexts.game.CreateEntity();
			e.AddAbility("Game.AbilityMove", null);

			system.Execute();

			Assert.IsNotNull(e.ability.Ability);
		}
	}
}

