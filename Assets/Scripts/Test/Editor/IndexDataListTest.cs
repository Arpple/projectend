using System.Linq;
using NUnit.Framework;

namespace Test
{
	public abstract class IndexDataListTest<TIndex, TData>
		where TData : IIndexData<TIndex>
	{
		protected IndexDataList<TIndex, TData> _data;

		[SetUp]
		public void SetupData()
		{
			_data = GetDataList();
		}

		protected abstract IndexDataList<TIndex, TData>GetDataList();

		[Test]
		public void CheckData_DataIndexNotDupplicate()
		{
			var count = _data.DataList.Count;
			Assert.AreEqual(count, _data.DataList.Select(d => d.GetIndex()).Distinct().Count());
		}
	}
}
