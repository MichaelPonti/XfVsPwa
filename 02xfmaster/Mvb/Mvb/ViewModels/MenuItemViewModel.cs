using MyXamarinUtils.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mvb.ViewModels
{
	public class MenuItemViewModel : BaseItemViewModel
	{
		public MenuItemViewModel()
		{
		}

		public MenuItemViewModel(string title, MenuItemType menuItem, string navigationPath)
		{
			_title = title;
			_menuItem = menuItem;
			_navigationPath = navigationPath;
		}


		#region properties


		private string _title = null;
		public string Title
		{
			get => _title;
			set => SetProperty<string>(ref _title, value);
		}


		private MenuItemType _menuItem;
		public MenuItemType MenuItem
		{
			get => _menuItem;
			set => SetProperty<MenuItemType>(ref _menuItem, value);
		}


		private string _navigationPath = null;
		public string NavigationPath
		{
			get => _navigationPath;
			set => SetProperty<string>(ref _navigationPath, value);
		}


		#endregion
	}
}
