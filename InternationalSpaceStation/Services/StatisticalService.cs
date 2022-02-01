using CsvHelper;
using InternationalSpaceStation.Exceptions;
using InternationalSpaceStation.Interfaces;
using InternationalSpaceStation.Models;
using System.Globalization;

namespace InternationalSpaceStation.Services
{
    public class StatisticalService : IStatisticalService
    {
        /// <summary>
        /// Approximate calculations based on 10 sec sample intervals
        /// 
        ///  - Continent that the ISS spent more time over
        ///  - For how long the ISS spent over land and over sea
        ///  - Total time spent over each country
        ///  
        /// </summary>
        public object? GetAroundTheWorldStatistics()
        {
            var aroundTheWorldStaticData =  GetStatisticalDataFromCsv();

            var periodTicks = aroundTheWorldStaticData?.LastOrDefault()?.Timestamp - aroundTheWorldStaticData?.FirstOrDefault()?.Timestamp ?? 0;
            var samplingPeriodInSeconds = new TimeSpan(periodTicks).TotalSeconds;
            
            var hoveredContinents = aroundTheWorldStaticData?.DistinctBy(x => x.Continent).Where(x => !string.IsNullOrWhiteSpace(x.Continent));

            var overSeaInSeconds = aroundTheWorldStaticData?.Count(x => x.OnWater ?? false) * 10;
            var overLandInSeconds = aroundTheWorldStaticData?.Count(x => !x.OnWater ?? false) * 10;

            var timeOverCountries = aroundTheWorldStaticData?.Where(x => !string.IsNullOrWhiteSpace(x.Country)).GroupBy(x => x.Country).Select(x => new
            {
                countryName = x.Key,
                timeInSeconds = x.Count() * 10
            });

            return new
            {
                samplingPeriodInSeconds,
                hoveredContinents,
                overSeaInSeconds,
                overLandInSeconds,
                timeOverCountries
            };
        }

        private IEnumerable<SnapshotStatistics>? GetStatisticalDataFromCsv()
        {
            try
            {
                var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + $"/StatisticalData/data.csv";
                using (var reader = new StreamReader(path))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    return csv.GetRecords<SnapshotStatistics>().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new HistoricalDataException("Unable to read the Historical CSV file", ex);
            }
        }
    }
}
