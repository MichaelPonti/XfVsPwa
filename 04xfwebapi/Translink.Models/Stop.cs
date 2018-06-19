using System;
using System.Collections.Generic;
using System.Text;

namespace Translink.Models
{
	public class Stop
	{
		public string StopNo { get; set; }
		public string Name { get; set; }
		public string BayNo { get; set; }
		public string City { get; set; }
		public string OnStreet { get; set; }
		public string AtStreet { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string WheelchairAccess { get; set; }
		public double Distance { get; set; }
		public string Routes { get; set; }
	}
}
