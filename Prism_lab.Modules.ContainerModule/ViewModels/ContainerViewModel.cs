using Prism.Events;
using Prism.Mvvm;
using Prism_lab.Modules.ContainerModule.Models;
using Prism_lab.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Prism_lab.Modules.ContainerModule.ViewModels
{
	class ContainerViewModel : BindableBase
	{
		IEventAggregator eventAggregator;
		private ObservableCollection<Bird> birds;
		public ObservableCollection<Bird> Birds
		{
			get => birds;
			set => SetProperty(ref birds, value);
		}

		public ContainerViewModel(IEventAggregator ea)
		{
			eventAggregator = ea;
			eventAggregator.GetEvent<CollectionUpdateEvent>().Subscribe(UpdateCollection);
		}

		private void UpdateCollection(object collection)
		{
			if (collection is ObservableCollection<Bird>)
				Birds = (collection as ObservableCollection<Bird>);
		}
	}
}
