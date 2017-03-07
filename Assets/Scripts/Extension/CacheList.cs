using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CacheList<TIndex, TItem>
{
	private Dictionary<TIndex, TItem> _cache;

	public CacheList()
	{
		_cache = new Dictionary<TIndex, TItem>();
	}

	/// <summary>
	/// callback function for getting item that not in cache
	/// </summary>
	/// <returns>item</returns>
	/// <param name="index">index of cache</param>
	public delegate TItem GetItemCallback(TIndex index);

	/// <summary>
	/// Get the item from cache. or do callback and store if not found
	/// </summary>
	/// <param name="index">Index.</param>
	/// <param name="callback">Callback.</param>
	public TItem Get(TIndex index, GetItemCallback callback)
	{
		if(!_cache.ContainsKey(index))
		{
			_cache.Add(index, callback(index));
		}
	
		TItem result = default(TItem);
		_cache.TryGetValue(index, out  result);

		return result;
	}
}
