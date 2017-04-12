using Entitas;
using UnityEngine;

public class CharacterViewCreatingSystem : EntityViewCreatingSystem<UnitEntity>
{
	private GameObject _container;

	public CharacterViewCreatingSystem(Contexts contexts, GameObject container) : base(contexts.unit)
	{
		_container = container;
	}

	protected override Collector<UnitEntity> GetTrigger(IContext<UnitEntity> context)
	{
		return context.CreateCollector(UnitMatcher.Sprite);
	}

	protected override bool Filter(UnitEntity entity)
	{
		return entity.hasSprite;
	}

	protected override GameObject CreateViewObject(UnitEntity entity)
	{
		var obj = new GameObject(entity.character.Type.ToString());
		var spriteRenderer = obj.AddComponent<SpriteRenderer>();
		spriteRenderer.sprite = entity.sprite.Sprite;
		spriteRenderer.sortingLayerName = "Unit";
		obj.transform.SetParent(_container.transform, false);

		return obj;
	}

	protected override void AddViewObject(UnitEntity entity, GameObject viewObject)
	{
		entity.AddView(viewObject);
	}
}