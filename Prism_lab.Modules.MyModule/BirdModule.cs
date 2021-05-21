using System;
using System.Collections.Generic;
using System.Text;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using Prism_lab.Modules.BirdModule.Views;
using Unity;

namespace Prism_lab.Modules.BirdModule
{
	public class BirdModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var regionManager = containerProvider.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion("BirdRegion", typeof(BirdView));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{

		}

	}
}
