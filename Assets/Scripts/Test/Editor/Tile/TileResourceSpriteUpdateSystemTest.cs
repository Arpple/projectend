using NUnit.Framework;
using UnityEngine;

namespace Test.TileTest
{
	class TileResourceSpriteUpdateSystemTest : ContextsTest
	{
		private TileEntity _entity;
		private Sprite _sprite;
		private Sprite _spriteEmpty;

		[SetUp]
		public void Init()
		{
			_systems.Add(new TileResourceSpriteUpdateSystem(_contexts));
			_entity = _contexts.tile.CreateEntity();
			_sprite = Resources.Load<Sprite>("Test/Editor/Sprite");
			_spriteEmpty = Resources.Load<Sprite>("Test/Editor/Sprite2");
			_entity.AddSprite(null);
			_entity.AddTileResource(Resource.Wood, _spriteEmpty);
			_entity.tileResource.SetOriginalSprite(_sprite);
		}

		[Test]
		public void Execute_TileChargeNotEmpty_SpriteChangedToOriginalSprite()
		{
			_entity.AddCharge(1);
			_systems.Execute();

			Assert.AreEqual(_sprite, _entity.sprite.Sprite);
		}

		[Test]
		public void Execute_TileChargeEmpty_SpriteChangedToEmptySprite()
		{
			_entity.AddCharge(0);
			_systems.Execute();

			Assert.AreEqual(_spriteEmpty, _entity.sprite.Sprite);
		}
	}
}
