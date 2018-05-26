using MyXamarinUtils.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mvb.ViewModels
{
	public class FavoriteRouteViewModel : BaseItemViewModel
	{
		public FavoriteRouteViewModel()
		{
		}

		public FavoriteRouteViewModel(string routeNo, string name, string operatingCompany)
		{
			_routeNo = routeNo;
			_name = name;
			_operatingCompany = operatingCompany;
		}



		private string _routeNo = null;
		public string RouteNo { get => _routeNo; set => SetProperty<string>(ref _routeNo, value); }


		private string _name = null;
		public string Name { get => _name; set => SetProperty<string>(ref _name, value); }

		private string _operatingCompany = null;
		public string OperatingCompany { get => _operatingCompany; set => SetProperty<string>(ref _operatingCompany, value); }
	}
}
