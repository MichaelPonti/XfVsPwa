using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace MyXamarinUtils.Animations
{
	public class RotateYToAnimation : AnimationBase
	{
		public static readonly BindableProperty RotationProperty = BindableProperty.Create(

			"Rotation",
			typeof(double),
			typeof(RotateYToAnimation),
			0.0d,
			propertyChanged: (bindable, oldValue, newValue) => ((RotateYToAnimation) bindable).Rotation = (double) newValue);

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

			return Target.RotateYTo(Rotation, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
		}

		protected override Task ResetAnimation()
		{
			if (Target == null)
			{
				throw new NullReferenceException("Null Target property.");
			}

			return Target.RotateYTo(Rotation, Convert.ToUInt32(Duration), EasingHelper.GetEasing(Easing));
		}
	}
}
