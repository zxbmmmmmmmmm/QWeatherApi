using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using QWeatherApi.Bases;

namespace QWeatherApi.ApiContracts;

public class WeatherDailyApi:QApiContractBase<WeatherDailyResponse>
{
    public override HttpMethod Method => HttpMethod.Get;
    public override string Path => ApiConstants.Weather.DailyForecast30D;
    public override async Task<HttpRequestMessage> GenerateRequestMessageAsync(ApiHandlerOption option)
    {
        var res = await base.GenerateRequestMessageAsync(option);
        return res;
    }
}

public sealed class WeatherDailyResponse : QWeatherResponseBase
{
    [JsonPropertyName("daily")]
    public List<DailyForecastItem> DailyForecasts { get; set; }
    public class DailyForecastItem
    {
        [JsonPropertyName("fxDate")]
        public DateTime FxDate { get; set; }
        
        [JsonPropertyName("sunrise")]
        public DateTime? Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public DateTime? Sunset { get; set; }

        [JsonPropertyName("moonrise")]
        public DateTime? Moonrise { get; set; }

        [JsonPropertyName("moonset")]
        public DateTime? Moonset { get; set; }

        [JsonPropertyName("moonPhase")]
        public string MoonPhase { get; set; }

        [JsonPropertyName("moonPhaseIcon")]
        public string MoonPhaseIcon { get; set; }
         
        [JsonPropertyName("tempMax")]
        public int TempMax { get; set; }

        [JsonPropertyName("tempMin")]
        public int TempMin { get; set; }

        [JsonPropertyName("iconDay")]
        public string IconDay { get; set; }

        [JsonPropertyName("textDay")]
        public string TextDay { get; set; }

        [JsonPropertyName("iconNight")]
        public string IconNight { get; set; }

        [JsonPropertyName("textNight")]
        public string TextNight { get; set; }

        [JsonPropertyName("wind360Day")]
        public string Wind360Day { get; set; }

        [JsonPropertyName("windDirDay")]
        public string WindDirDay { get; set; }

        [JsonPropertyName("windScaleDay")]
        public string WindScaleDay { get; set; }

        [JsonPropertyName("windSpeedDay")]
        public int WindSpeedDay { get; set; }

        [JsonPropertyName("wind360Night")]
        public int Wind360Night { get; set; }

        [JsonPropertyName("windDirNight")]
        public string WindDirNight { get; set; }

        [JsonPropertyName("windScaleNight")]
        public string WindScaleNight { get; set; }

        [JsonPropertyName("windSpeedNight")]
        public int WindSpeedNight { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("precip")]
        public double Precipitation { get; set; }

        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        [JsonPropertyName("vis")]
        public int Vis { get; set; }

        [JsonPropertyName("cloud")]
        public int? Cloud { get; set; }

        [JsonPropertyName("uvIndex")]
        public int UvIndex { get; set; }
    }
}