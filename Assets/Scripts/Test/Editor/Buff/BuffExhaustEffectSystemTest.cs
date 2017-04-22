using NUnit.Framework;

namespace Test.BuffTest
{
	public class BuffExhaustEffectSystemTest : ContextsTest
	{
		UnitEntity unit;
		BuffEntity buff;
		BuffSetting _setting;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().BuffSetting;
			_systems.Add(new BuffExhaustEffectSystem(_contexts, _setting));

			unit = _contexts.unit.CreateEntity();
			unit.AddUnitStatus(0, 2, 0, 0, 0);
			buff = _contexts.buff.CreateEntity();
			buff.isBuffExhaust = true;
			unit.AddBuff(buff);
		}

		[Test]
		public void Execute_UnitAttack2GotExhaust_UnitAttackReduce()
		{
			_systems.Execute();
			Assert.AreEqual(2 - _setting.ExhaustDamageReduceAmount, unit.unitStatus.AttackPower);
		}

		[Test]
		public void Execute_UnitAttack2RemoveExhaust_UnitAttackIncrease()
		{
			buff.isBuffExhaust = false;
			_systems.Execute();
			Assert.AreEqual(2 + _setting.ExhaustDamageReduceAmount, unit.unitStatus.AttackPower);
		}
	}
}
