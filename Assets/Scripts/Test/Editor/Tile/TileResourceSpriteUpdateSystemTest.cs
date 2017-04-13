using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Text;
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
			_entity.AddResource(Resource.Wood, _spriteEmpty);
			_entity.resource.SetOriginalSprite(_sprite);
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
