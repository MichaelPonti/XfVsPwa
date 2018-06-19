using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Translink.Models
{
	public interface ITranslinkService
	{
		Task<Stop> GetStopAsync(string id);
		Task<List<Stop>> GetStopsAsync(double latitude, double longitude, int radius = 500, string routeNo = null);



		Task<List<NextBus>> GetNextBusEstimatesAsync(string stopId, int count = 6, int timeFrame = 1440, string routeNo = null);


		Task<Bus> GetBusDetailsAsync(string busId);
		Task<List<Bus>> GetBusesForStopAsync(string stopNo);
		Task<List<Bus>> GetBusesForRouteAsync(string routeNo);
		Task<List<Bus>> GetBusesForRouteAndStopAsync(string stopNo, string routeNo);


		Task<Route> GetRouteInformationAsync(string routeNo);
	}
}
