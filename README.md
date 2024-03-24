# QWeatherApi
QWeather client for .NET

***
## Getting started

```
var handler = new QWeatherApiHandler();
var option = new ApiHandlerOption
{
    Domain = "devapi.qweather.com",
    Token = "YOUR_KEY"
};
```



## Get current weather

Obtain the current weather with longitude of 39.9 and latitude of 116.3

```
var request = new QWeatherRequest(39.9,116.3);
var result = await handler.RequestAsync(QWeatherApis.WeatherNowApi, request, option);
Console.WriteLine(result.WeatherNow.Temp);
```
