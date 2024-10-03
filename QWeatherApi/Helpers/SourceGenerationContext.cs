using QWeatherApi.ApiContracts;
using static QWeatherApi.ApiConstants;
using static QWeatherApi.ApiContracts.WeatherDailyResponse;
using static QWeatherApi.ApiContracts.WeatherHourlyResponse;
using System.Text.Json.Serialization;

namespace QWeatherApi.Helpers;
[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Metadata)]
[JsonSerializable(typeof(AirConditionResponse))]
[JsonSerializable(typeof(PrecipitationResponse))]
[JsonSerializable(typeof(QGeolocationResponse))]
[JsonSerializable(typeof(TyphoonForecastResponse))]
[JsonSerializable(typeof(TyphoonListResponse))]
[JsonSerializable(typeof(TyphoonTrackResponse))]
[JsonSerializable(typeof(WeatherDailyResponse))]
[JsonSerializable(typeof(WeatherHourlyResponse))]
[JsonSerializable(typeof(WeatherIndicesResponse))]
[JsonSerializable(typeof(WeatherNowResponse))]
[JsonSerializable(typeof(WeatherWarningResponse))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
    
}