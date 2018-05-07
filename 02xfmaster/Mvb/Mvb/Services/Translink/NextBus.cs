using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvb.Services.Translink
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
