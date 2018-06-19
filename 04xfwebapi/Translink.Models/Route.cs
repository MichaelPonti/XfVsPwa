using System;
using System.Collections.Generic;
using System.Text;

namespace Translink.Models
{
	public class Route
	{
		public string RouteNo { get; set; }
		public string Name { get; set; }
		public string OperatingCompany { get; set; }
		public List<Pattern> Patterns { get; set; }
	}
}
