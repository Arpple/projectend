using System;
using System.Collections.Generic;

public class TwoWayObjectSelector<TItem>
{
	private List<TItem> _items;
	private int _index;

	public TwoWayObjectSelector()
	{
		_items = new List<TItem>();
		_index = -1;
	}

	public void AddItem(TItem item)
	{
		_items.Add(item);
	}

	public TItem GetCurrentITem()
	{
		if (_index == -1)
			throw new ItemNotFoundException();
		return _items[_index];
	}

	public void MoveIndexDown()
	{
		if (_index == 0)
			throw new IndexOutOfRangeException();
		_index -= 1;
	}

	public void MoveIndexUp()
	{
		if (_index == _items.Count - 1)
			throw new IndexOutOfRangeException();
		_index += 1;
	}

	public void SetIndex(int index)
	{
		if (index < 0 || index >= _items.Count)
			throw new IndexOutOfRangeException();
		_index = index;
	}

	public void SetSelectedItem(TItem item)
	{
		_index = _items.IndexOf(item);
	}

	public bool CanMoveDown()
	{
		return _index > 0;
	}

	public bool CanMoveUp()
	{
		return _index < _items.Count - 1;
	}

	public bool IsEmpty()
	{
		return _items.Count == 0;
	}

	public class IndexOutOfRangeException : Exception
	{}

	public class ItemNotFoundException : Exception
	{}
}