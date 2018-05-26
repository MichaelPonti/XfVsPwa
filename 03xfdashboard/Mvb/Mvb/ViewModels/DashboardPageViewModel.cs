using Mvb.Services.Favorites;
using MyXamarinUtils.ViewModels;
using Prism.Commands;
using Prism.Logging;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mvb.ViewModels
{
	public class DashboardPageViewModel : BaseViewModel, INavigationAware
	{
		private INavigationService _navigationService = null;
		private IFavoriteService _favoriteService = null;
		private ILoggerFacade _logService = null;


		public DashboardPageViewModel(INavigationService navigationService, IFavoriteService favoriteService, ILoggerFacade logService)
		{
			_navigationService = navigationService;
			_favoriteService = favoriteService;
			_logService = logService;
		}


		private bool _isBusy = false;
		public bool IsBusy
		{
			get => _isBusy;
			set => SetProperty<bool>(ref _isBusy, value);
		}


		private ObservableCollection<FavoriteRouteViewModel> _routes = new ObservableCollection<FavoriteRouteViewModel>();
		public ObservableCollection<FavoriteRouteViewModel> Routes
		{
			get => _routes;
			set => SetProperty<ObservableCollection<FavoriteRouteViewModel>>(ref _routes, value);
		}


		private ObservableCollection<FavoriteStopViewModel> _stops = new ObservableCollection<FavoriteStopViewModel>();
		public ObservableCollection<FavoriteStopViewModel> Stops
		{
			get => _stops;
			set => SetProperty<ObservableCollection<FavoriteStopViewModel>>(ref _stops, value);
		}



		private DelegateCommand<FavoriteStopViewModel> _commandGoToStop = null;
		public DelegateCommand<FavoriteStopViewModel> CommandGoToStop
		{
			get
			{
				return _commandGoToStop ??
					(_commandGoToStop = new DelegateCommand<FavoriteStopViewModel>((stop) =>
					{
						_logService.Log($"Would like to navigate to stop {stop.StopNo}/{stop.Name}", Category.Debug, Priority.None);
					}));
			}
		}


		private DelegateCommand<FavoriteRouteViewModel> _commandGoToRoute = null;
		public DelegateCommand<FavoriteRouteViewModel> CommandGoToRoute
		{
			get
			{
				return _commandGoToRoute ??
					(_commandGoToRoute = new DelegateCommand<FavoriteRouteViewModel>((route) =>
					{
						_logService.Log($"Would like to navigate to route {route.RouteNo}/{route.Name}", Category.Debug, Priority.None);
					}));
			}
		}

		public void OnNavigatedFrom(INavigationParameters parameters)
		{
			// nothing doing here
		}

		public async void OnNavigatedTo(INavigationParameters parameters)
		{
			IsBusy = true;

			_logService.Log("DashboardPageViewModel.OnNavigatedTo", Category.Info, Priority.None);

			try
			{
				_logService.Log("loading favorite stops", Category.Debug, Priority.None);
				var favstops = await _favoriteService.GetFavoriteStopsAsync();
				if (favstops != null && favstops.Count > 0)
				{
					ObservableCollection<FavoriteStopViewModel> stops = new ObservableCollection<FavoriteStopViewModel>();
					foreach (var stop in favstops)
						stops.Add(new FavoriteStopViewModel(stop.StopNo, stop.Name, null, null, stop.OnStreet, stop.AtStreet, stop.Latitude, stop.Longitude, null));
					Stops = stops;
				}
				else
				{
					_logService.Log("There were no favorite stops", Category.Debug, Priority.None);
					/// no stops returned, just make sure that the list is cleared.
					if (Stops != null)
						Stops.Clear();
				}

				_logService.Log("Loading favorite routes", Category.Debug, Priority.None);
				var favroutes = await _favoriteService.GetFavoriteRoutesAsync();
				if (favroutes != null && favroutes.Count > 0)
				{
					ObservableCollection<FavoriteRouteViewModel> routes = new ObservableCollection<FavoriteRouteViewModel>();
					foreach (var r in favroutes)
						routes.Add(new FavoriteRouteViewModel(r.RouteNo, r.Name, r.OperatingCompany));

					Routes = routes;
				}
				else
				{
					_logService.Log("There were no favorite routes", Category.Debug, Priority.None);
					if (Routes != null)
						Routes.Clear();
				}

				_logService.Log("DashboardPageViewModel.OnNavigatedTo successfully ended", Category.Debug, Priority.None);
			}
			catch (Exception e)
			{
				_logService.Log("There was an exception: " + e.Message, Category.Exception, Priority.High);
				_logService.Log(e.ToString(), Category.Exception, Priority.High);
			}

			_logService.Log("Exiting DashboardPageViewModel.OnNavigatedTo", Category.Debug, Priority.None);

			IsBusy = false;
		}

		public void OnNavigatingTo(INavigationParameters parameters)
		{
			// nothing happening here
		}
	}
}
