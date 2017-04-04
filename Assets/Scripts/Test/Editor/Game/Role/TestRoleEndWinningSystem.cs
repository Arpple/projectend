using UnityEngine;
using NUnit.Framework;
using Game;

namespace Test.System
{
	public class TestRoleEndWinningSystem : ContextsTest
	{
		[Test]
		public void WhenAllInvaderDieAllOriginWin()
		{
			var system = new RoleEndWinningSystem(_contexts);

			var ePlayer = _contexts.game.CreateEntity();
			ePlayer.AddGameRole(new RoleEnd(_contexts.game));
			var eChar = _contexts.game.CreateEntity();
			eChar.AddGameUnit(0, ePlayer);
			eChar.isGameDead = true;

			system.Execute();

			Assert.IsTrue(ePlayer.isGameWin);
		}
	}
}
