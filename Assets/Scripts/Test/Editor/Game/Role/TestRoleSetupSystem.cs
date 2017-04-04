using UnityEngine;
using NUnit.Framework;
using Entitas;
using Game;
using System.Collections.Generic;
using System.Linq;

namespace Test.System
{
	public class TestRoleSetupSystem : ContextsTest
	{
		[Test]
		public void SetupComponent()
		{
			var rc = new RoleSetting.RolesCount(1, 1, 1, 1);

			var system = new RoleSetupSystem(_contexts, rc);

			4.Loop(() =>
			{
				var p = _contexts.game.CreateEntity();
				p.AddGamePlayer(new GameObject().AddComponent<Player>());
			});

			system.Initialize();

			var roles = _contexts.game.GetEntities(GameMatcher.GameRole);
			Assert.AreEqual(rc.Origin, roles.Where(r => r.gameRole.RoleObject is RoleOrigin).Count());
			Assert.AreEqual(rc.Invader, roles.Where(r => r.gameRole.RoleObject is RoleInvader).Count());
			Assert.AreEqual(rc.End, roles.Where(r => r.gameRole.RoleObject is RoleEnd).Count());
			Assert.AreEqual(rc.Seed, roles.Where(r => r.gameRole.RoleObject is RoleSeed).Count());
		}
	}

}
