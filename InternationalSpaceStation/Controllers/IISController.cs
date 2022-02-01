using InternationalSpaceStation.Interfaces;
using InternationalSpaceStation.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternationalSpaceStation.Controllers
{
    [ApiController]
    [Route("/api/iis")]
    public class IISController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly IStatisticalService _statisticalService;

        public IISController(ILocationService locationService, IStatisticalService statisticalService)
        {
            _locationService = locationService;
            _statisticalService = statisticalService;
        }

        [HttpGet]
        [Route("location")]        
        public async Task<IActionResult> Location()
        {
            var currentLocation = await _locationService.GetCurrentIISLocation();
            var geocoded = await _locationService.GetReverseGeocode(currentLocation?.Position?.Latitude, currentLocation?.Position?.Longitude);
            var onWater = await _locationService.GetOnWater(currentLocation?.Position?.Latitude, currentLocation?.Position?.Longitude);
            var statistics = _statisticalService.GetAroundTheWorldStatistics();

            return Json(new CurrentLocationResponse 
                { 
                    GeoLocation = geocoded, 
                    OnWater = onWater?.Water, 
                    Statistics = statistics
            });
        }
    }
}
