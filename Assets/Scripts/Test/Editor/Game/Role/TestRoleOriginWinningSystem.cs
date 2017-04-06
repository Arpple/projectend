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
			iPlayer.AddGameRole(new RoleInvader(_contexts.game));

			var iChar = _contexts.unit.CreateEntity();
			iChar.AddGameOwner(iPlayer);
			iChar.AddGameCharacter(Character.LastBoss);
			iChar.isGameDead = true;

			var oPlayer = _contexts.game.CreateEntity();
			oPlayer.AddGameRole(new RoleOrigin(_contexts.game));
			var oChar = _contexts.unit.CreateEntity();
			oChar.AddGameOwner(oPlayer);
			oChar.AddGameCharacter(Character.LastBoss);

			system.Execute();

			Assert.IsTrue(oPlayer.isGameWin);
		}
	}
}
