namespace QWeatherApi.ApiContracts;

public class GridWeatherNowApi:WeatherNowApi
{
    public override string Path => ApiConstants.Weather.GridNow;
}
