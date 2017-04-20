using System.Linq;
using NUnit.Framework;

namespace Test.WeatherTest
{
	public class WeatherStatusPanelSetupSystemTest : ContextsTest
	{
		private ResourceCardSetting _setting;
		private WeatherStatusPanel _panel;

		[SetUp]
		public void Init()
		{
			_setting = TestHelper.GetGameSetting().CardSetting.ResourceCardSetting;
			_panel = TestHelper.CreateWeatherPanel();
			_systems.Add(new WeatherStatusPanelSetupSystem(_contexts, _setting, _panel));
		}

		[Test]
		public void Initialize_CanSetCostForAllResourceType()
		{
			_systems.Initialize();

			foreach (var res in _setting.DataList.Select(d => d.Type))
			{
				_panel.SetCost(res, 0);
			}
		}
	}
}
