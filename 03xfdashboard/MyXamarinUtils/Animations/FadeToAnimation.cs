using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyXamarinUtils.Animations
{
	public class FadeToAnimation : AnimationBase
	{
		public static readonly BindableProperty OpacityProperty =
			BindableProperty.Create(
				"Opacity",
				typeof(double),
				typeof(FadeToAnimation),
				0.0d,
				propertyChanged: (bindable, oldValue, newValue) => ((FadeToAnimation) bindable).Opacity = (double) newValue);

		public double Opacity
		{
			get { return (double) GetValue(OpacityProperty); }
			set { SetValue(OpacityProperty, value); }
		}

		protected override Task BeginAnimation()
		{
			if (Target == null)
			{
				throw new NullReferenceException("Null Target property.");
			}

			return Target.FadeTo(Opacity, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
		}

		protected override Task ResetAnimation()
		{
			if (Target == null)
			{
				throw new NullReferenceException("Null Target property.");
			}

			return Target.FadeTo(0, 0, null);
		}
	}
}
