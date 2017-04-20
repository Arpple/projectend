using NUnit.Framework;
using UnityEngine;

namespace Test.TurnTest
{
	public class TurnPanelRoundDisplaySystemTest : ContextsTest
	{
		private TurnPanel _panel;

		[SetUp]
		public void Init()
		{
			_panel = new GameObject().AddComponent<TurnPanel>();
			_panel.RoundText = _panel.gameObject.AddComponent<UnityEngine.UI.Text>();

			_systems.Add(new TurnPanelRoundDisplaySystem(_contexts, _panel));
		}

		[Test]
		public void Execute_HaveRound1_TextIsRound1()
		{
			_contexts.game.SetRound(1);
			_systems.Execute();

			Assert.AreEqual("Round 1", _panel.RoundText.text);
		}

		[Test]
		public void Execute_HaveRoundLimit1_TextIsRound0slash1()
		{
			_contexts.game.SetRoundLimit(1);
			_systems.Execute();

			Assert.AreEqual("Round 0/1", _panel.RoundText.text);
		}

		[Test]
		public void Execute_HaveRound1AndRoundLimit1_TextIsRound1slash1()
		{
			_contexts.game.SetRound(1);
			_contexts.game.SetRoundLimit(1);
			_systems.Execute();

			Assert.AreEqual("Round 1/1", _panel.RoundText.text);
		}
	}
}
