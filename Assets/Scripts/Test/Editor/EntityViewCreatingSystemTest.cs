using NUnit.Framework;

namespace Test
{
	public abstract class EntityViewCreatingSystemTest : ContextsTest
	{
		[TearDown]
		public void Teardown()
		{
			_systems.TearDown();
		}
	}
}
