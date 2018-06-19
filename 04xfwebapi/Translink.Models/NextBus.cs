using System;
using System.Collections.Generic;
using System.Text;

namespace Translink.Models
{
	public class NextBus
	{
		public string RouteNo { get; set; }
		public string RouteName { get; set; }
		public string Direction { get; set; }
		public RouteMap RouteMap { get; set; }
		public List<Schedule> Schedules { get; set; }

	}
}
