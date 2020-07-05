# Backend

Backend of this Weather Sample project, includes only WebAPI service and some logic for interaction with database through linq2db and with interaction with 3rd patry weather provider service.

Done:
- Simple controller with alone get request method. (for fetching data from client)
- Caching requested weather to database.
- Auto fetching new weather data and updating cached data in database.

Used:
- ASP.NET Core 3.1.
- Linq2db for working with database (first time tried use it this =)).
- Newtonsoft JSON for parsing json.
- RestSharp for making request to 3rd party service.
- Beautiful weather provider: https://rapidapi.com/community/api/open-weather-map, but :( I have only 100 requests per day.

As database used:
- MySQL version 5.7.

*Requested by reviewer sql script for deploying database placed in `WeatherSample/WeatherSample.Scripts`*.
