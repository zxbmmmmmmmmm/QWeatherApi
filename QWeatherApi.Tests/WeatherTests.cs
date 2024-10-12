using QWeatherApi.ApiContracts;
using QWeatherApi.Bases;

namespace QWeatherApi.Tests
{
    [TestClass]
    public partial class WeatherTests
    {
        [TestMethod]
        public async Task GridWeatherNowTest()
        {
            var handler = new QWeatherApiHandler();
            var option = new ApiHandlerOption
            {
                Domain = "devapi.qweather.com",
                Token = _devApiKey
            };
            var request = new QWeatherRequest(119.9, 28.4);
            var result = await handler.RequestAsync(QWeatherApis.GridWeatherNowApi, request, option);
            Assert.IsNotNull(result.WeatherNow.Temp);
        }
        [TestMethod]
        public async Task WeatherNowTest()
        {
            var handler = new QWeatherApiHandler();
            var option = new ApiHandlerOption
            {
                Domain = "devapi.qweather.com",
                Token = _devApiKey
            };
            var request = new QWeatherRequest(119.9, 28.4);
            
            var result = await handler.RequestAsync(QWeatherApis.WeatherNowApi, request, option);
            Assert.IsNotNull(result.WeatherNow.Temp);
        }

        [TestMethod]
        public async Task WeatherDailyTest()
        {
            var handler = new QWeatherApiHandler();
            var option = new ApiHandlerOption
            {
                Domain = "devapi.qweather.com",
                Token = _devApiKey
            };
            var request = new QWeatherRequest(119.9, 28.4);
            var result = await handler.RequestAsync(QWeatherApis.WeatherDailyApi, request, option);
            Assert.IsNotNull(result.DailyForecasts[0].Sunrise);
        }

        [TestMethod]
        public async Task WeatherDailyTest_Lang()
        {
            var handler = new QWeatherApiHandler();
            var option = new ApiHandlerOption
            {
                Domain = "devapi.qweather.com",
                Language = "fr",
                Token = _devApiKey
            };
            var request = new QWeatherRequest(119.9, 28.4);
            var result = await handler.RequestAsync(QWeatherApis.WeatherDailyApi, request, option);
            Assert.IsNotNull(result.DailyForecasts[0].Sunrise);
        }

        [TestMethod]
        public async Task WeatherDailyTest2()
        {
            var handler = new QWeatherApiHandler();
            var option = new ApiHandlerOption
            {
                Domain = "devapi.qweather.com",
                Token = _devApiKey
            };
            var request = new QWeatherRequest(-75.39, 43.04);
            var result = await handler.RequestAsync(QWeatherApis.WeatherDailyApi, request, option);
            Assert.IsNotNull(result.DailyForecasts[0].Sunrise);
        }

        [TestMethod]
        public async Task TyphoonTest()
        {
            var handler = new QWeatherApiHandler();
            var option = new ApiHandlerOption
            {
                Domain = "api.qweather.com",
                Token = _apiKey
            };
            var request = new QWeatherRequest(-75.39, 43.04);
            var list = await handler.RequestAsync(QWeatherApis.TyphoonListApi, request, option);
            if (list.Typhoons.Count is 0) return;
            Assert.IsNotNull(list.Typhoons[0]);
            var track = await handler.RequestAsync(QWeatherApis.TyphoonTrackApi, new TyphoonTrackRequest { TyphoonId = list.Typhoons[0].Id }, option);
            Assert.IsNotNull(track.Tracks[0]);
            var forecast = await handler.RequestAsync(QWeatherApis.TyphoonForecastApi, new TyphoonForecastRequest { TyphoonId = list.Typhoons[0].Id }, option);
            Assert.IsNotNull(forecast);

        }

        [TestMethod]
        public async Task WeatherDailyTest_NoKey_Code401()
        {
            var handler = new QWeatherApiHandler();
            var option = new ApiHandlerOption
            {
                Domain = "devapi.qweather.com",
            };
            var request = new QWeatherRequest(-75.39, 43.04);
            var result = await handler.RequestAsync(QWeatherApis.WeatherDailyApi, request, option);
            Assert.IsNotNull(result.Code == "401");
        }
    }
    
}