using UnityEngine;

namespace End
{
	public interface ICustomView
	{
		/// <summary>
		/// modify entity view object
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="sprite"></param>
		/// <returns>view object</returns>
		GameObject CreateView(GameEntity entity, Sprite sprite);
	}
}
