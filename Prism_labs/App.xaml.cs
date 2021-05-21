using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Prism_lab.Shell.Views;
using Prism_lab.Modules.BirdModule;
using Prism_lab.Modules.ContainerModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Prism_lab.Shell
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : PrismApplication
	{
		protected override Window CreateShell()
		{
			return Container.Resolve<Views.Shell>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			
		}

		protected override IModuleCatalog CreateModuleCatalog()
		{
			//return new ConfigurationModuleCatalog();
			return new XamlModuleCatalog(new Uri("/Prism_lab;component/ModuleCatalog.xaml", UriKind.Relative));
		}
		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			base.ConfigureModuleCatalog(moduleCatalog);

			moduleCatalog.AddModule<Modules.BirdModule.BirdModule>();
			moduleCatalog.AddModule<Modules.ContainerModule.ContainerModule>();
		}
	}
}
