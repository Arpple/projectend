using UnityEngine;

namespace Game
{
	public interface IEntityView<TEntity> where TEntity : Entitas.Entity
	{
		/// <summary>
		/// modify entity view object
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="sprite"></param>
		/// <returns>view object</returns>
		GameObject CreateView(TEntity entity, Sprite sprite);
	}
}
