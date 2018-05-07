using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyXamarinUtils.ViewModels
{
	public abstract class BaseItemViewModel : BindableBase
	{
		public IEventAggregator MessageBus { get; private set; }


		public BaseItemViewModel()
		{
		}

		public BaseItemViewModel(IEventAggregator messageBus)
		{
			MessageBus = messageBus;
		}




		protected virtual void OnChecked(bool newValue)
		{
		}

		protected virtual void OnExpanded(bool newValue)
		{
		}

		protected virtual void OnSelected(bool newValue)
		{
		}

		protected virtual void OnEnabled(bool newValue)
		{
		}

		#region properties


		private bool _isChecked = false;
		public bool IsChecked
		{
			get => _isChecked;
			set
			{
				if (SetProperty<bool>(ref _isChecked, value))
					OnChecked(_isChecked);
			}
		}


		private bool _isExpanded = false;
		public bool IsExapnded
		{
			get => _isExpanded;
			set
			{
				if (SetProperty<bool>(ref _isExpanded, value))
					OnExpanded(_isExpanded);
			}
		}


		private bool _isSelected = false;
		public bool IsSelected
		{
			get => _isSelected;
			set
			{
				if (SetProperty<bool>(ref _isSelected, value))
					OnSelected(_isSelected);
			}
		}


		private bool _isEnabled = true;
		public bool IsEnabled
		{
			get => _isEnabled;
			set
			{
				if (SetProperty(ref _isEnabled, value))
					OnEnabled(_isEnabled);
			}
		}

		#endregion
	}
}
