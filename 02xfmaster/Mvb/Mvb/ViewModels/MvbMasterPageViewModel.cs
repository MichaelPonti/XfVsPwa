using MyXamarinUtils.ViewModels;
using Prism.Commands;
using Prism.Events;
using Prism.Logging;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace Mvb.ViewModels
{
	public class MvbMasterPageViewModel : BaseViewModel
	{
		private ILoggerFacade _logService = null;
		private INavigationService _navigationService = null;

		public MvbMasterPageViewModel(IEventAggregator messageBus, ILoggerFacade logService, INavigationService navigationService)
			: base(messageBus)
		{
			_navigationService = navigationService;
			_logService = logService;
			InitalizeMenuItems();
		}



		private void InitalizeMenuItems()
		{
			_logService.Log("Constructing menu items", Category.Info, Priority.None);

			_menuItems.Add(new MenuItemViewModel("Dashboard", MenuItemType.Dashboard, $"{Pages.MyNavPage}/{Pages.Dashboard}"));
			_menuItems.Add(new MenuItemViewModel("Stops", MenuItemType.Stops, $"{Pages.MyNavPage}/{Pages.Stops}"));
			_menuItems.Add(new MenuItemViewModel("Route", MenuItemType.Route, $"{Pages.MyNavPage}/{Pages.Route}"));
			_menuItems.Add(new MenuItemViewModel("Donate", MenuItemType.Donate, $"{Pages.MyNavPage}/{Pages.Donate}"));
			_menuItems.Add(new MenuItemViewModel("Settings", MenuItemType.Settings, $"{Pages.MyNavPage}/{Pages.Settings}"));
			_menuItems.Add(new MenuItemViewModel("About", MenuItemType.About, $"{Pages.MyNavPage}/{Pages.About}"));
		}


		private ObservableCollection<MenuItemViewModel> _menuItems = new ObservableCollection<MenuItemViewModel>();
		public ObservableCollection<MenuItemViewModel> MenuItems
		{
			get => _menuItems;
			set => SetProperty<ObservableCollection<MenuItemViewModel>>(ref _menuItems, value);
		}



		private DelegateCommand<MenuItemViewModel> _commandNavigate = null;
		public DelegateCommand<MenuItemViewModel> CommandNavigate
		{
			get
			{
				return _commandNavigate ??
					(_commandNavigate = new DelegateCommand<MenuItemViewModel>(
						async (menu) =>
						{
							if (menu != null && menu.IsEnabled)
							{
								try
								{
									_logService.Log($"Navigating to {menu.NavigationPath}", Category.Info, Priority.None);
									await _navigationService.NavigateAsync(menu.NavigationPath);
								}
								catch (Exception e)
								{
									Debug.WriteLine(e.ToString());
									_logService.Log(e.ToString(), Category.Exception, Priority.High);
									throw;
								}
							}
						}));
			}
		}
	}
}
