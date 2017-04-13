using NUnit.Framework;
using UnityEngine;

namespace Test.TileTest
{
	public class TileSpriteUpdateSystemTest : ContextsTest
	{
		private Sprite _sprite;
		private TileController _tileCon;

		[SetUp]
		public void Init()
		{
			_systems.Add(new TileSpriteUpdateSystem(_contexts));
			_sprite = Resources.Load<Sprite>("Test/Editor/Sprite");
			_tileCon = new GameObject().AddComponent<TileController>();
			_tileCon.TileSprite = _tileCon.gameObject.AddComponent<SpriteRenderer>();
		}

		[Test]
		public void Execute_NoViewTileSpriteReplace_Nothing()
		{
			var entity = _contexts.tile.CreateEntity();
			entity.AddSprite(_sprite);

			_systems.Execute();
		}

		[Test]
		public void Execute_TileSpriteReplace_TileControllerSpriteUpdated()
		{
			var entity = _contexts.tile.CreateEntity();
			entity.AddSprite(_sprite);
			entity.AddView(_tileCon.gameObject);

			_systems.Execute();

			Assert.AreEqual(_sprite, _tileCon.TileSprite.sprite);
		}
	}
}
