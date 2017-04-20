using NUnit.Framework;

namespace Test.CardTest
{
	public class CardChargeRenderingSystemTest : ContextsTest
	{
		[SetUp]
		public void CardChargeRenderingSystem()
		{
			_systems.Add(new CardChargeRenderingSystem(_contexts));
		}

		[Test]
		public void Execute_AddCharge1_ViewChargeTextIs1()
		{
			var obj = TestHelper.CreateCardObject();
			var card = _contexts.card.CreateEntity();
			card.AddView(obj.gameObject);
			card.AddCharge(1);

			_systems.Execute();

			Assert.AreEqual("1", obj.CardChargeText.text);
		}
	}
}

