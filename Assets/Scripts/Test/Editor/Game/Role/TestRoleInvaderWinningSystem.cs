using UnityEngine;
using NUnit.Framework;
using Game;

namespace Test.System
{
	public class TestRoleInvaderWinningSystem : ContextsTest
	{
		[Test]
		public void WhenAllInvaderDieAllOriginWin()
		{
			var system = new RoleInvaderWinningSystem(_contexts);

			var iPlayer = _contexts.game.CreateEntity();
			iPlayer.AddGameRole(new RoleInvader(_contexts.game));
			var iChar = _contexts.unit.CreateEntity();
			iChar.AddGameUnit(0, iPlayer);
			iChar.AddGameCharacter(Character.LastBoss);

			var oPlayer = _contexts.game.CreateEntity();
			oPlayer.AddGameRole(new RoleOrigin(_contexts.game));
			var oChar = _contexts.unit.CreateEntity();
			oChar.AddGameUnit(1, oPlayer);
			oChar.AddGameCharacter(Character.LastBoss);
			oChar.isGameDead = true;

			system.Execute();

			Assert.IsTrue(iPlayer.isGameWin);
		}
	}
}
