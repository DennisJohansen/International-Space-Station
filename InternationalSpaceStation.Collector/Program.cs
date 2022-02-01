using CsvHelper;
using CsvHelper.Configuration;
using InternationalSpaceStation.Models;
using System.Globalization;
using System.Net.Http.Json;

HttpClient client = new HttpClient();
client.DefaultRequestHeaders.Add("x-key", "verysecret");

var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

var timer = new System.Timers.Timer(10 * 1000);

timer.Elapsed += async (s, e) =>
{
    var data = await client.GetFromJsonAsync<CurrentLocationResponse>("http://localhost:5104/api/iis/location");

    using (var stream = File.Open(path + "/data.csv", FileMode.Append))
    using (var writer = new StreamWriter(stream))
    using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false }))
    {
        await csv.WriteRecordsAsync(new[] { new SnapshotStatistics {
                Timestamp = DateTime.Now.Ticks,
                Lat = data?.GeoLocation?.Latitude,
                Lon = data?.GeoLocation?.Longitude,
                Continent = data?.GeoLocation?.Continent,
                Country = data?.GeoLocation?.CountryName,
                OnWater = data?.OnWater} 
        });
    }

    Console.WriteLine($"Data scraped ({DateTime.Now})");
};

timer.Start();

Console.ReadKey();

