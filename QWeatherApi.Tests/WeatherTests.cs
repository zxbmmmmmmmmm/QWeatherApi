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
                Token = _key
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
                Token = _key
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
                Token = _key
            };
            var request = new QWeatherRequest(119.9, 28.4);
            var result = await handler.RequestAsync(QWeatherApis.WeatherDailyApi, request, option);
            Assert.IsNotNull(result.DailyForecasts[0].Sunrise);
        }
    }
    
}