using System;
using System.Collections.Generic;
using System.Text;

namespace Translink.Models
{
	public class Pattern
	{
		public string PatternNo { get; set; }
		public string Destination { get; set; }
		public RouteMap RouteMap { get; set; }
		public string Direction { get; set; }
	}
}
