using System.Collections.Generic;
using NUnit.Framework;

namespace Test.BuffTest
{
	public class BuffExpireSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new BuffExpireSystem(_contexts));
		}

		[Test]
		public void Execute_BuffDurationZero_BuffEntityRemoveFromUnitBuffList()
		{
			var buff = _contexts.buff.CreateEntity();
			buff.AddBuffDuration(0);

			var unit = _contexts.unit.CreateEntity();
			unit.AddBuff(buff);

			_systems.Execute();

			Assert.IsFalse(unit.buffList.List.Contains(buff));
		}
	}
}
