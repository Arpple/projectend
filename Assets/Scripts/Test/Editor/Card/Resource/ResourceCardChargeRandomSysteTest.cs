using NUnit.Framework;

namespace Test.CardTest.ResourceTest
{
	public class ResourceCardChargeRandomSysteTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			var setting = TestHelper.GetGameSetting().CardSetting.ResourceCardSetting;
			_systems.Add(new ResourceCardChargeRandomSystem(_contexts, setting));
		}

		[Test]
		public void Execute_ResourceCard_RandomChargeAdded()
		{
			var card = _contexts.card.CreateEntity();
			card.AddResourceCard(Resource.Coal);

			_systems.Execute();

			Assert.IsTrue(card.hasCharge);
		}
	}
}
