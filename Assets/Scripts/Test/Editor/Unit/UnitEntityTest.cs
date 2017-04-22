using NUnit.Framework;

namespace Test.UnitTest
{
	public class UnitEntityTest : ContextsTest
	{
		UnitEntity unit;

		[SetUp]
		public void Init()
		{
			unit = _contexts.unit.CreateEntity();
		}

		[Test]
		public void AddBuff_UnitNotHasBuffList_BuffListAdded()
		{
			var buff = _contexts.buff.CreateEntity();
			unit.AddBuff(buff);
			Assert.IsTrue(unit.hasBuffList);
		}

		[Test]
		public void AddBuff_UnitHasBuffList_BuffEntityAddToUnitBuffList_And_BuffTargetAdded()
		{
			var buff = _contexts.buff.CreateEntity();
			unit.AddBuff(buff);

			Assert.IsTrue(unit.buffList.List.Contains(buff));
			Assert.IsTrue(buff.hasBuffTarget);
			Assert.AreEqual(unit, buff.buffTarget.Entity);
		}
	}
}
