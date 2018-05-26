using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvb.Services.Translink
{
	public class Route
	{
		public string RouteNo { get; set; }
		public string Name { get; set; }
		public string OperatingCompany { get; set; }
		public List<Pattern> Patterns { get; set; }
	}
}
