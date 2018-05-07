using Prism;
using Prism.Ioc;
using Prism.Logging;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Mvb
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null)
			: base(initializer)
		{
		}



		private ILoggerFacade _logService = null;


		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<MainPage>(Pages.Main);
			containerRegistry.RegisterForNavigation<Views.MvbMasterPage, ViewModels.MvbMasterPageViewModel>(Pages.Master);
			containerRegistry.RegisterForNavigation<Views.MvbNavigationPage>(Pages.MyNavPage);
			containerRegistry.RegisterForNavigation<Views.DashboardPage>(Pages.Dashboard);
			containerRegistry.RegisterForNavigation<Views.AboutPage>(Pages.About);
			containerRegistry.RegisterForNavigation<Views.DonatePage>(Pages.Donate);
			containerRegistry.RegisterForNavigation<Views.RoutePage>(Pages.Route);
			containerRegistry.RegisterForNavigation<Views.SettingsPage>(Pages.Settings);
			containerRegistry.RegisterForNavigation<Views.StopsPage>(Pages.Stops);

#if DEBUG
			_logService = new DebugLogger();
			containerRegistry.RegisterInstance<ILoggerFacade>(_logService);
#endif
		}

		protected override void OnInitialized()
		{
			InitializeComponent();
			NavigationService.NavigateAsync($"{Pages.Master}/{Pages.MyNavPage}/{Pages.Dashboard}");
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
