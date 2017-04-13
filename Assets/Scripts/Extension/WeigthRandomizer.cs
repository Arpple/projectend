using System;
using System.Collections.Generic;
using System.Linq;

public class WeigthRandomizer<TItem>
{
	private class RandomItem
	{
		public TItem Item;
		public int Weigth;

		public RandomItem(TItem item, int weigth)
		{
			Item = item;
			Weigth = weigth;
		}
	}

	private List<RandomItem> _items;

	public WeigthRandomizer()
	{
		_items = new List<RandomItem>();
	}

	public void AddItem(TItem item, int weigth)
	{
		_items.Add(new RandomItem(item, weigth));
	}

	public TItem GetRandomItem()
	{
		if(_items.Count == 0)
		{
			throw new Exception("Random item not added");
		}

		var sumWeigth = _items.Sum(i => i.Weigth);
		var randomIndex = UnityEngine.Random.Range(0, sumWeigth);
		var index = 0;
		foreach(var item in _items)
		{
			index += item.Weigth;
			if (index >= randomIndex)
				return item.Item;
		}

		return _items.First().Item;
	}
}