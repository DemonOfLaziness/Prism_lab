using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prism_lab.Modules.ContainerModule
{
	public class ContainerModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var regionManager = containerProvider.Resolve<IRegionManager>();
			regionManager.RegisterViewWithRegion("ContainerRegion", typeof(Views.ContainerView));
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{

		}
	}
}
