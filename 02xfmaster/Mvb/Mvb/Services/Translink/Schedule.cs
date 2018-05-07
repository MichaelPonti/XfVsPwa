using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvb.Services.Translink
{
	public class Schedule
	{
		public string Pattern { get; set; }
		public string Destination { get; set; }
		public string ExpectedLeaveTime { get; set; }
		public string ExpectedCountdown { get; set; }
		public string ScheduleStatus { get; set; }
		public string CancelledTrip { get; set; }
		public string CancelledStop { get; set; }
		public string AddedTrip { get; set; }
		public string AddedStop { get; set; }
		public string LastUpdate { get; set; }
	}
}
