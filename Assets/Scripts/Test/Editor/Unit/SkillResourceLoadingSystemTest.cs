using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using NUnit.Framework;

namespace Test.UnitTest
{
	public class SkillResourceLoadingSystemTest : ContextsTest
	{
		[SetUp]
		public void Init()
		{
			_systems.Add(new SkillResourceLoadingSystem(_contexts));
		}

		[Test]
		public void Execute_SkillResourceAdded_SkillCardCreatedForOwner()
		{
			var unit = _contexts.unit.CreateEntity();
			unit.AddCharacterSkillsResource(new List<SkillCard>() { SkillCard.Monolith_JudgementLight });

			var p = _contexts.game.CreateEntity();
			unit.AddOwner(p);

			_systems.Execute();

			var cards = _contexts.card.GetEntities(CardMatcher.SkillCard)
				.Where(c => c.owner.Entity == p)
				.ToArray();

			Assert.AreEqual(1, cards.Length);

			var card = cards[0];
			Assert.AreEqual(p, card.owner.Entity);
			Assert.AreEqual(SkillCard.Monolith_JudgementLight, card.skillCard.Type);
		}
	}
}
