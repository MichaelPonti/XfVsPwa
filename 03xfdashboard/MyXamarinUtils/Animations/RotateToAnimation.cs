using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyXamarinUtils.Animations
{
	public class RotateToAnimation : AnimationBase
	{
		public static readonly BindableProperty RotationProperty = BindableProperty.Create(
			"Rotation",
			typeof(double),
			typeof(RotateToAnimation),
			0.0d,
			propertyChanged: (bindable, oldValue, newValue) => ((RotateToAnimation) bindable).Rotation = (double) newValue);

		public double Rotation
		{
			get { return (double) GetValue(RotationProperty); }
			set { SetValue(RotationProperty, value); }
		}

		protected override Task BeginAnimation()
		{
			if (Target == null)
			{
				throw new NullReferenceException("Null Target property.");
			}

			return Target.RotateTo(Rotation, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
		}

		protected override Task ResetAnimation()
		{
			if (Target == null)
			{
				throw new NullReferenceException("Null Target property.");
			}

			return Target.RotateTo(0, 0, null);
		}
	}
}
