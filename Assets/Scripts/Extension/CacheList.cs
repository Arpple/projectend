using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
		TItem result = default(TItem);
		if(!_cache.TryGetValue(index, out  result))
		{
			result = callback(index);
			_cache.Add(index, result);
		}

		return result;
	}
}
