using System.Collections.Generic;
using NUnit.Framework;

namespace Test.TileTest
{
	public class TileResourceChargeSetupSystemTest : ContextsTest
	{
		[Test]
		public void Initialize_EntityWithTileCharge_ChrageCountInRandomRange()
		{
			var randomRange = new List<int>() { 1, 1, 1 };
			_systems.Add(new TileResourceChargeSetupSystem(_contexts, randomRange));

			var entity = _contexts.tile.CreateEntity();
			entity.AddResource(Resource.Coal);

			_systems.Initialize();

			Assert.IsTrue(entity.hasCharge);
			Assert.IsTrue(entity.charge.Count > 0 && entity.charge.Count <= 3);
		}
	}
}
