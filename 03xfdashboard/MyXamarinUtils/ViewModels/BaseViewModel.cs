using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyXamarinUtils.ViewModels
{
	public abstract class BaseViewModel : BindableBase
	{
		public IEventAggregator MessageBus { get; private set; }

		public BaseViewModel()
		{
		}

		public BaseViewModel(IEventAggregator messageBus)
		{
			MessageBus = messageBus;
		}
	}
}
