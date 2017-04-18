using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
		if (data == null) OnDataNotFound(index);
		return data;
	}

	protected virtual void OnDataNotFound(TIndex index)
	{
		throw new MissingReferenceException("Data not found : " + index.ToString());
	}
}