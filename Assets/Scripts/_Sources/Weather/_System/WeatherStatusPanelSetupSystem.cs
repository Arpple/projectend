using Entitas;

public class WeatherStatusPanelSetupSystem : IInitializeSystem
{
	private ResourceCardSetting _setting;
	private WeatherStatusPanel _panel;

	public WeatherStatusPanelSetupSystem(Contexts contexts, ResourceCardSetting setting, WeatherStatusPanel panel)
	{
		_setting = setting;
		_panel = panel;
	}

	public void Initialize()
	{
		foreach(var data in _setting.DataList)
		{
			_panel.AddCostType(data);
		}
	}
}