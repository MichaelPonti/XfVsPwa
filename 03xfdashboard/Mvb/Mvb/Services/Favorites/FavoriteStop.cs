using System;
using System.Collections.Generic;
using System.Text;

namespace Mvb.Services.Favorites
{
	public class FavoriteStop
	{
		public int Id { get; set; }
		public string StopNo { get; set; }
		public string Name { get; set; }
		public string OnStreet { get; set; }
		public string AtStreet { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }



		public FavoriteStop()
		{
		}

		public FavoriteStop(int id, string stopNo, string name, string onStreet, string atStreet, double latitude, double longitude)
		{
			Id = id;
			StopNo = stopNo;
			Name = name;
			OnStreet = onStreet;
			AtStreet = atStreet;
			Latitude = latitude;
			Longitude = longitude;
		}
	}
}
