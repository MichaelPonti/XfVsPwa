using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Mvb.Controls
{
	public class StopsMap : Map
	{
		public StopsMap()
		{
		}


		public static readonly BindableProperty StopsPinProperty =
			BindableProperty.Create(
				"StopsPins",
				typeof(List<StopsMapPin>),
				typeof(StopsMap),
				new List<StopsMapPin>(),
				BindingMode.TwoWay);

		public List<StopsMapPin> StopsPins
		{
			get => (List<StopsMapPin>) GetValue(StopsPinProperty);
			set => SetValue(StopsPinProperty, value);
		}


		public static readonly BindableProperty NavigationServiceProperty =
			BindableProperty.Create(
				"NavigationService",
				typeof(INavigationService),
				typeof(StopsMap),
				null);

		public INavigationService NavigationService
		{
			get => (INavigationService) GetValue(NavigationServiceProperty);
			set => SetValue(NavigationServiceProperty, value);
		}



		public static readonly BindableProperty TrackCenterProperty =
			BindableProperty.Create(
				"TrackCenter",
				typeof(bool),
				typeof(StopsMap),
				false,
				BindingMode.TwoWay);

		public bool TrackCenter
		{
			get => (bool) GetValue(TrackCenterProperty);
			set => SetValue(TrackCenterProperty, value);
		}


		public static readonly BindableProperty CenterProperty =
			BindableProperty.Create(
				"Center",
				typeof(MapSpan),
				typeof(StopsMap),
				null,
				BindingMode.TwoWay);

		public MapSpan Center
		{
			get => (MapSpan) GetValue(CenterProperty);
			set => SetValue(CenterProperty, value);
		}


		public static readonly BindableProperty FuzzyProperty =
			BindableProperty.Create(
				"Fuzzy",
				typeof(double),
				typeof(StopsMap),
				0.0001,
				BindingMode.TwoWay);

		public double Fuzzy
		{
			get => (double) GetValue(FuzzyProperty);
			set => SetValue(FuzzyProperty, value);
		}
	}
}
