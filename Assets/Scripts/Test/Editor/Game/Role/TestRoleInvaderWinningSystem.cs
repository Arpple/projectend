using UnityEngine;
using NUnit.Framework;
using End.Game;

namespace End.Test.System
{
	public class TestRoleInvaderWinningSystem : ContextsTest
	{
		[Test]
		public void WhenAllInvaderDieAllOriginWin()
		{
			var system = new RoleInvaderWinningSystem(_contexts);

			var iPlayer = _contexts.game.CreateEntity();
			iPlayer.AddRole(new RoleInvader(_contexts.game));
			var iChar = _contexts.game.CreateEntity();
			iChar.AddUnit(0, iPlayer);
			iChar.AddCharacter(Character.LastBoss);

			var oPlayer = _contexts.game.CreateEntity();
			oPlayer.AddRole(new RoleOrigin(_contexts.game));
			var oChar = _contexts.game.CreateEntity();
			oChar.AddUnit(1, oPlayer);
			oChar.AddCharacter(Character.LastBoss);
			oChar.isDead = true;

			system.Execute();

			Assert.IsTrue(iPlayer.isWin);
		}
	}
}
