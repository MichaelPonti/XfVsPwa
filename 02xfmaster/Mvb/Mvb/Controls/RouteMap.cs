using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Mvb.Controls
{
	public class RouteMap : Map
	{
		public RouteMap()
		{
		}


		public static readonly BindableProperty RoutePinsProperty =
			BindableProperty.Create(
				"RoutePins",
				typeof(List<RouteMapPin>),
				typeof(RouteMap),
				new List<RouteMapPin>(),
				BindingMode.TwoWay);

		public List<RouteMapPin> RoutePins
		{
			get => (List<RouteMapPin>) GetValue(RoutePinsProperty);
			set => SetValue(RoutePinsProperty, value);
		}


		public static readonly BindableProperty CenterProperty =
			BindableProperty.Create(
				"Center",
				typeof(MapSpan),
				typeof(RouteMap),
				null,
				BindingMode.TwoWay);

		public MapSpan Center
		{
			get => (MapSpan) GetValue(CenterProperty);
			set => SetValue(CenterProperty, value);
		}


		public static readonly BindableProperty TrackCenterProperty =
			BindableProperty.Create(
				"TrackCenter",
				typeof(bool),
				typeof(RouteMap),
				false,
				BindingMode.TwoWay);

		public bool TrackCenter
		{
			get => (bool) GetValue(TrackCenterProperty);
			set => SetValue(TrackCenterProperty, value);
		}


		public static readonly BindableProperty FuzzyProperty =
			BindableProperty.Create(
				"Fuzzy",
				typeof(double),
				typeof(RouteMap),
				0.01,
				BindingMode.TwoWay);

		public double Fuzzy
		{
			get => (double) GetValue(FuzzyProperty);
			set => SetValue(FuzzyProperty, value);
		}


		public static readonly BindableProperty NavigationServiceProperty =
			BindableProperty.Create(
				"NavigationService",
				typeof(INavigationService),
				typeof(RouteMap),
				null,
				BindingMode.TwoWay);

		public INavigationService NavigationService
		{
			get => (INavigationService) GetValue(NavigationServiceProperty);
			set => SetValue(NavigationServiceProperty, value);
		}
	}
}
