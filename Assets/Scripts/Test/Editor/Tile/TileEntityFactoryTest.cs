using NUnit.Framework;
using UnityEngine;


namespace Test.TileTest
{
	public class TileEntityFactoryTest : ContextsTest
	{
		private TileData _data;
		private TileEntityFactory _factory;

		[SetUp]
		public void Init()
		{
			_data = ScriptableObject.CreateInstance<TileData>();
			_factory = new TileEntityFactory(_contexts.tile);
		}

		[Test]
		public void CreateEntity_SpriteDataNull_NoSpriteComponent()
		{
			var entity = _factory.CreateEntityWithComponents(_data);

			Assert.IsFalse(entity.hasSprite);
		}

		[Test]
		public void CreateEntity_SpriteDataDefinedAndExist_SpriteComponentAdded()
		{
			_data.Sprite = Resources.Load<Sprite>("Test/Editor/Sprite");

			var entity = _factory.CreateEntityWithComponents(_data);

			Assert.IsTrue(entity.hasSprite);
			Assert.AreEqual(_data.Sprite, entity.sprite.Sprite);
		}

		//[Test]
		//public void CreateEntity_SpriteDataNotFound_ThrowError()
		//{
			
		//}

		[Test]
		public void CreateEntity_IsWalkableOnTrue_IsMovableComponentAdded()
		{
			_data.IsWalkableOn = true;
			var entity = _factory.CreateEntityWithComponents(_data);

			Assert.IsTrue(entity.isTileMovable);
		}

		[Test]
		public void CreateEntity_IsWalkableOnFalse_NoIsMovableComponent()
		{
			_data.IsWalkableOn = false;
			var entity = _factory.CreateEntityWithComponents(_data);

			Assert.IsFalse(entity.isTileMovable);
		}
	}
}
