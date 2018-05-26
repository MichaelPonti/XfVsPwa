using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvb.Services.Translink
{
	public class Pattern
	{
		public string PatternNo { get; set; }
		public string Destination { get; set; }
		public RouteMap RouteMap { get; set; }
		public string Direction { get; set; }
	}
}
