using UnityEngine;
using NUnit.Framework;
using Game;

namespace Test.System
{
	public class TestRoleOriginWinningSystem : ContextsTest
	{
		[Test]
		public void WhenAllInvaderDieAllOriginWin()
		{
			var system = new RoleOriginWinningSystem(_contexts);

			var iPlayer = _contexts.game.CreateEntity();
			iPlayer.AddRole(new RoleInvader(_contexts.game));

			var iChar = _contexts.game.CreateEntity();
			iChar.AddUnit(0, iPlayer);
			iChar.AddCharacter(Character.LastBoss);
			iChar.isDead = true;

			var oPlayer = _contexts.game.CreateEntity();
			oPlayer.AddRole(new RoleOrigin(_contexts.game));
			var oChar = _contexts.game.CreateEntity();
			oChar.AddUnit(1, oPlayer);
			oChar.AddCharacter(Character.LastBoss);

			system.Execute();

			Assert.IsTrue(oPlayer.isWin);
		}
	}
}
