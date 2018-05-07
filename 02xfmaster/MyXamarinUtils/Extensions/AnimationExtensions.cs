using MyXamarinUtils.Animations;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyXamarinUtils.Extensions
{
	public static class AnimationExtension
	{
		public static async void Animate(this VisualElement visualElement, AnimationBase animation, Action onFinishedCallback = null)
		{
			animation.Target = visualElement;
			await animation.Begin();
			onFinishedCallback?.Invoke();
		}
	}
}
