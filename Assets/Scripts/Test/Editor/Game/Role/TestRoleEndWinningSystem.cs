using NUnit.Framework;


namespace Test.GameTest.RoleTest
{
	public class TestRoleEndWinningSystem : ContextsTest
	{
		[Test]
		public void WhenAllInvaderDieAllOriginWin()
		{
			var system = new RoleEndWinningSystem(_contexts);

			var ePlayer = _contexts.game.CreateEntity();
			ePlayer.AddRole(new RoleEnd(_contexts.game));
			var eChar = _contexts.unit.CreateEntity();
			eChar.AddOwner(ePlayer);
			eChar.isDead = true;

			system.Execute();

			Assert.IsTrue(ePlayer.isWinner);
		}
	}
}
