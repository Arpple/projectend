using UnityEngine;

public interface IIndexData<TIndex>
{
	TIndex GetIndex();
	bool IsIndexEquals(TIndex index);
}