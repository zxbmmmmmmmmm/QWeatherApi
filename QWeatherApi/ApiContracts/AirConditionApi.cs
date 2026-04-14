using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using QWeatherApi.Bases;
using QWeatherApi.Helpers;

namespace QWeatherApi.ApiContracts
{
    public sealed class AirConditionApi : QApiContractBase<AirConditionResponse>
    {
        public override HttpMethod Method => HttpMethod.Get;

        public override string Path => ApiConstants.Weather.AirCondition;

        public override Task<HttpRequestMessage> GenerateRequestMessageAsync(ApiHandlerOption option)
        {
            var latitude = Request.Lat.ToString("0.##", CultureInfo.InvariantCulture);
            var longitude = Request.Lon.ToString("0.##", CultureInfo.InvariantCulture);
            var sb = new StringBuilder("https://");
            sb.Append(option.Domain).Append(Path).Append('/').Append(latitude).Append('/').Append(longitude);

            var query = GenerateQuery(option);

            if (option.PublicId is not "" && option.PublicId is not null)
            {
                query.Remove("key");
                query.Remove("sign");
                query.Add("t", DateTime.UtcNow.GetTimeStamp());
                query.Add("publicid", option.PublicId);
                query = query.Sort();
                var param = HttpUtility.UrlDecode(query.ToString());
                param += option.Token;
                var sign = param.MD5Encrypt32().ToLower();
                var queryString = HttpUtility.UrlDecode(query.ToString());
                if (!string.IsNullOrEmpty(queryString))
                    sb.Append('?').Append(queryString).Append("&sign=").Append(sign);
            }
            else
            {
                if (option.Token is not null)
                    query.Add("key", option.Token);

                var queryString = query.Sort().ToString();
                if (!string.IsNullOrEmpty(queryString))
                    sb.Append('?').Append(queryString);
            }

            var requestMessage = new HttpRequestMessage(Method, sb.ToString());

            var cookies = option.Cookies.ToDictionary(t => t.Key, t => t.Value);
            foreach (var keyValuePair in Cookies)
            {
                cookies[keyValuePair.Key] = keyValuePair.Value;
            }

            if (cookies.Count > 0)
                requestMessage.Headers.Add("Cookie", string.Join("; ", cookies.Select(c => $"{c.Key}={c.Value}")));

            return Task.FromResult(requestMessage);
        }

        protected override NameValueCollection GenerateQuery(ApiHandlerOption option)
        {
            var queryCollection = HttpUtility.ParseQueryString(string.Empty);
            if (option.Language is not null)
                queryCollection.Add("lang", option.Language);
            return queryCollection;
        }
    }

    public sealed class AirConditionResponse : QWeatherResponseBase
    {
        [JsonPropertyName("metadata")]
        public MetadataItem Metadata { get; set; }

        [JsonPropertyName("indexes")]
        public List<AirQualityIndexItem> Indexes { get; set; }

        [JsonPropertyName("pollutants")]
        public List<PollutantItem> Pollutants { get; set; }

        [JsonPropertyName("stations")]
        public List<StationItem> Stations { get; set; }

        public sealed class MetadataItem
        {
            [JsonPropertyName("tag")]
            public string Tag { get; set; }
        }

        public sealed class AirQualityIndexItem
        {
            [JsonPropertyName("code")]
            public string Code { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("aqi")]
            public double Aqi { get; set; }

            [JsonPropertyName("aqiDisplay")]
            public string AqiDisplay { get; set; }

            [JsonPropertyName("level")]
            public string Level { get; set; }

            [JsonPropertyName("category")]
            public string Category { get; set; }

            [JsonPropertyName("color")]
            public ColorItem Color { get; set; }

            [JsonPropertyName("primaryPollutant")]
            public NamedItem PrimaryPollutant { get; set; }

            [JsonPropertyName("health")]
            public HealthItem Health { get; set; }
        }

        public sealed class ColorItem
        {
            [JsonPropertyName("red")]
            public int Red { get; set; }

            [JsonPropertyName("green")]
            public int Green { get; set; }

            [JsonPropertyName("blue")]
            public int Blue { get; set; }

            [JsonPropertyName("alpha")]
            public double Alpha { get; set; }
        }

        public sealed class NamedItem
        {
            [JsonPropertyName("code")]
            public string Code { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("fullName")]
            public string FullName { get; set; }
        }

        public sealed class HealthItem
        {
            [JsonPropertyName("effect")]
            public string Effect { get; set; }

            [JsonPropertyName("advice")]
            public AdviceItem Advice { get; set; }
        }

        public sealed class AdviceItem
        {
            [JsonPropertyName("generalPopulation")]
            public string GeneralPopulation { get; set; }

            [JsonPropertyName("sensitivePopulation")]
            public string SensitivePopulation { get; set; }
        }

        public sealed class PollutantItem
        {
            [JsonPropertyName("code")]
            public string Code { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("fullName")]
            public string FullName { get; set; }

            [JsonPropertyName("concentration")]
            public ConcentrationItem Concentration { get; set; }

            [JsonPropertyName("subIndexes")]
            public List<SubIndexItem> SubIndexes { get; set; }
        }

        public sealed class ConcentrationItem
        {
            [JsonPropertyName("value")]
            public double Value { get; set; }

            [JsonPropertyName("unit")]
            public string Unit { get; set; }
        }

        public sealed class SubIndexItem
        {
            [JsonPropertyName("code")]
            public string Code { get; set; }

            [JsonPropertyName("aqi")]
            public double? Aqi { get; set; }

            [JsonPropertyName("aqiDisplay")]
            public string AqiDisplay { get; set; }
        }

        public sealed class StationItem
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }
        }
    }
}
