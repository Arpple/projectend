using UnityEngine;
using Entitas;

public interface IEntityCustomView<TEntity> where TEntity : class, IEntity, new()
{
	/// <summary>
	/// modify entity view object
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="sprite"></param>
	/// <returns>view object</returns>
	GameObject CreateView(TEntity entity, Sprite sprite);
}