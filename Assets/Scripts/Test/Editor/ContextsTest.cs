using NUnit.Framework;

namespace Test
{
	public class ContextsTest
	{
		protected Contexts _contexts;

		[SetUp]
		public void SetupContexts()
		{
			_contexts = TestHelper.CreateContexts();
		}
	}
}
