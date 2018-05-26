using MyXamarinUtils.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mvb.ViewModels
{
	public class FavoriteStopViewModel : BaseItemViewModel
	{
		public FavoriteStopViewModel()
		{
		}


		public FavoriteStopViewModel(string stopNo, string name, string bayNo, string city, string onStreet, string atStreet, double latitude, double longitude, string wheelchairAccess)
		{
			_stopNo = stopNo;
			_name = name;
			_bayNo = bayNo;
			_city = city;
			_onStreet = onStreet;
			_atStreet = atStreet;
			_latitude = latitude;
			_longitude = longitude;
			_wheelchairAccess = wheelchairAccess;
		}



		private string _stopNo = null;
		public string StopNo { get => _stopNo; set => SetProperty<string>(ref _stopNo, value); }

		private string _name = null;
		public string Name { get => _name; set => SetProperty<string>(ref _name, value); }

		private string _bayNo = null;
		public string BayNo { get => _bayNo; set => SetProperty<string>(ref _bayNo, value); }

		private string _city = null;
		public string City { get => _city; set => SetProperty<string>(ref _city, value); }

		private string _onStreet = null;
		public string OnStreet { get => _onStreet; set => SetProperty<string>(ref _onStreet, value); }

		private string _atStreet = null;
		public string AtStreet { get => _atStreet; set => SetProperty<string>(ref _atStreet, value); }

		private double _latitude = 0;
		public double Latitude { get => _latitude; set => SetProperty<double>(ref _latitude, value); }

		private double _longitude = 0;
		public double Longitude { get => _longitude; set => SetProperty<double>(ref _longitude, value); }

		private string _wheelchairAccess = null;
		public string WheelchairAccess { get => _wheelchairAccess; set => SetProperty<string>(ref _wheelchairAccess, value); }


		public string StreetLocation
		{
			get => $"{_onStreet} at {_atStreet}";
		}
	}
}
