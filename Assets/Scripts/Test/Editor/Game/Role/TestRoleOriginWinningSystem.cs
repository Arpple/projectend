using NUnit.Framework;


namespace Test.GameTest.RoleTest
{
	public class TestRoleOriginWinningSystem : ContextsTest
	{
		[Test]
		public void WhenAllInvaderDieAllOriginWin()
		{
			var system = new RoleOriginWinningSystem(_contexts);

			var iPlayer = _contexts.game.CreateEntity();
			iPlayer.AddRole(new RoleInvader(_contexts.game));

			var iChar = _contexts.unit.CreateEntity();
			iChar.AddOwner(iPlayer);
			iChar.AddCharacter(Character.LastBoss);
			iChar.isDead = true;

			var oPlayer = _contexts.game.CreateEntity();
			oPlayer.AddRole(new RoleOrigin(_contexts.game));
			var oChar = _contexts.unit.CreateEntity();
			oChar.AddOwner(oPlayer);
			oChar.AddCharacter(Character.LastBoss);

			system.Execute();

			Assert.IsTrue(oPlayer.isWinner);
		}
	}
}
