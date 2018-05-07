using Mvb.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Mvb.Converters
{
	public class MenuItemTypeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var m = (MenuItemType) value;
			var isWindows = (Device.RuntimePlatform != Device.Android && Device.RuntimePlatform != Device.iOS && Device.RuntimePlatform != Device.macOS);

			switch (m)
			{
				case MenuItemType.Dashboard:
					return isWindows ? "Assets/menu_dashboard.png" : "menu_dashboard.png";
				case MenuItemType.Stops:
					return isWindows ? "Assets/menu_stop.png" : "menu_stop.png";
				case MenuItemType.About:
					return isWindows ? "Assets/menu_about.png" : "menu_about.png";
				case MenuItemType.Donate:
					return isWindows ? "Assets/menu_donate.png" : "menu_donate.png";
				case MenuItemType.Route:
					return isWindows ? "Assets/menu_route.png" : "menu_route.png";
				case MenuItemType.Settings:
					return isWindows ? "Assets/menu_settings.png" : "menu_settings.png";
				default:
					return String.Empty;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}
