public class WeatherSystems : Feature
{
	public WeatherSystems(Contexts contexts, Setting setting, GameUI ui) : base("Weather System")
	{
		Add(new WeatherStatusPanelSetupSystem(contexts, setting.CardSetting.ResourceCardSetting, ui.WeatherStatus));
		Add(new RoundEndWeatherResolveSystem(contexts,ui.WeatherResloveDisplayer));
		Add(new RoundStartWeatherCreateSystem(contexts, setting.WeatherSetting));
		Add(new EventCreateWeatherSystem(contexts));
		Add(new WeatherStatusNameDisplaySystem(contexts, setting.WeatherSetting, ui.WeatherStatus));
		Add(new WeatherStatusCostDisplaySystem(contexts, ui.WeatherStatus));
	}
}