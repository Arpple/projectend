using System;
using System.Collections.Generic;
using System.Linq;

public abstract class IndexDataList<TIndex, TData>
	where TData : IIndexData<TIndex>
{
	public List<TData> DataList;
	protected CacheList<TIndex, TData> _cacheData;

	public IndexDataList()
	{
		_cacheData = new CacheList<TIndex, TData>();
	}

	public TData GetData(TIndex index)
	{
		var data = _cacheData.Get(index, (i) => DataList.FirstOrDefault(d => d.IsIndexEquals(i)));
		if (data == null) throw new DataNotFoundException(index);
		return data;
	}

	public class DataNotFoundException : Exception
	{
		public DataNotFoundException(TIndex index)
			: base("Data not found at " + index.ToString())
		{ }
	}
}