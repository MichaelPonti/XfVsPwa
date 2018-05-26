using System;
using System.Collections.Generic;
using System.Text;

namespace Mvb.Services.Favorites
{
	public class FavoriteRoute
	{
		public int Id { get; set; }
		public string RouteNo { get; set; }
		public string Name { get; set; }
		public string OperatingCompany { get; set; }


		public FavoriteRoute()
		{
		}


		public FavoriteRoute(int id, string routeNo, string name, string operatingCompany)
		{
			Id = id;
			RouteNo = routeNo;
			Name = name;
			OperatingCompany = operatingCompany;
		}
	}
}
