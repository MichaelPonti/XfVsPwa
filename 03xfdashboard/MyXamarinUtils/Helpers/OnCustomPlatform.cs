using System;
using System.Collections.Generic;
using System.Text;

namespace MyXamarinUtils.Helpers
{
	public sealed class OnCustomPlatform<T>
	{
		public T Android { get; set; } = default(T);
		public T iOS { get; set; } = default(T);
		public T WinPhone { get; set; } = default(T);
		public T Windows { get; set; } = default(T);
		public T WinTablet { get; set; } = default(T);
		public T Xbox { get; set; } = default(T);
		public T Other { get; set; } = default(T);


		public OnCustomPlatform()
		{
		}


		public static implicit operator T(OnCustomPlatform<T> onPlatform)
		{
			switch (Xamarin.Forms.Device.RuntimePlatform)
			{
				case Xamarin.Forms.Device.Android:
					return onPlatform.Android;
				case Xamarin.Forms.Device.iOS:
					return onPlatform.iOS;
				case Xamarin.Forms.Device.WinPhone:
					return onPlatform.WinPhone;
				case Xamarin.Forms.Device.UWP:
					if (Xamarin.Forms.Device.Idiom == Xamarin.Forms.TargetIdiom.Desktop)
						return onPlatform.Windows;
					else if (Xamarin.Forms.Device.Idiom == Xamarin.Forms.TargetIdiom.Phone)
						return onPlatform.WinPhone;
					else if (Xamarin.Forms.Device.Idiom == Xamarin.Forms.TargetIdiom.Tablet)
						return onPlatform.WinTablet;
					else if (Xamarin.Forms.Device.Idiom == Xamarin.Forms.TargetIdiom.TV)
						return onPlatform.Xbox;
					else
						return default(T);
				default:
					return onPlatform.Other;
			}
		}
	}
}
