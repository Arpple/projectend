﻿using UnityEngine;
using NUnit.Framework;
using Entitas;
using End.Game;
using System.Collections.Generic;
using System.Linq;

namespace End.Test
{
	public class TestRoleSetupSystem
	{

		private Contexts _contexts;

		[SetUp]
		public void Init()
		{
			_contexts = TestHelper.CreateContexts();
		}

		[Test]
		public void SetupComponent()
		{
			var rc = new RoleSetting.RolesCount(1, 1, 1, 1);

			var system = new RoleSetupSystem(_contexts, rc);

			4.Loop(() =>
			{
				var p = _contexts.game.CreateEntity();
				p.AddPlayer(new GameObject().AddComponent<Player>());
			});

			system.Initialize();

			var roles = _contexts.game.GetEntities(GameMatcher.Role);
			Assert.AreEqual(rc.Origin, roles.Where(r => r.role.RoleObject is RoleOrigin).Count());
			Assert.AreEqual(rc.Invader, roles.Where(r => r.role.RoleObject is RoleInvader).Count());
			Assert.AreEqual(rc.End, roles.Where(r => r.role.RoleObject is RoleEnd).Count());
			Assert.AreEqual(rc.Seed, roles.Where(r => r.role.RoleObject is RoleSeed).Count());
		}
	}

}
