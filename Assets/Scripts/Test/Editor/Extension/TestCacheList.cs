using NUnit.Framework;

namespace Test
{
	public class TestCacheList
	{
		private class TestObject
		{
			public int Index;

			public TestObject(int index)
			{
				Index = index;
			}
		}

		[Test]
		public void StoreNewValueFromCallback()
		{
			var cache = new CacheList<int, TestObject>();
			var obj1 = cache.Get(0, (i) => new TestObject(i));

			Assert.IsNotNull(obj1);
		}

		[Test]
		public void ObjectIsCached()
		{
			var cache = new CacheList<int, TestObject>();
			var obj1 = cache.Get(0, (i) => new TestObject(1));
			var obj2 = cache.Get(0, (i) => new TestObject(2));

			Assert.AreEqual(obj1, obj2);
			Assert.AreEqual(1, obj2.Index);
		}
	}
}
