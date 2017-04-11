using NUnit.Framework;


namespace Test.GameTest.RoleTest
{
	public class TestRoleInvaderWinningSystem : ContextsTest
	{
		[Test]
		public void WhenAllInvaderDieAllOriginWin()
		{
			var system = new RoleInvaderWinningSystem(_contexts);

			var iPlayer = _contexts.game.CreateEntity();
			iPlayer.AddRole(new RoleInvader(_contexts.game));
			var iChar = _contexts.unit.CreateEntity();
			iChar.AddOwner(iPlayer);
			iChar.AddCharacter(Character.LastBoss);

			var oPlayer = _contexts.game.CreateEntity();
			oPlayer.AddRole(new RoleOrigin(_contexts.game));
			var oChar = _contexts.unit.CreateEntity();
			oChar.AddOwner(oPlayer);
			oChar.AddCharacter(Character.LastBoss);
			oChar.isDead = true;

			system.Execute();

			Assert.IsTrue(iPlayer.isWinner);
		}
	}
}
