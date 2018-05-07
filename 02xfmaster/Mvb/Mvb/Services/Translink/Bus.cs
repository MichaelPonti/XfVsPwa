using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvb.Services.Translink
{
	public class Bus
	{
		public string VehicleNo { get; set; }
		public string TripId { get; set; }
		public string RouteNo { get; set; }
		public string Direction { get; set; }
		public string Destination { get; set; }
		public string Pattern { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string RecordedTime { get; set; }
		public RouteMap RouteMap { get; set; }
	}
}
