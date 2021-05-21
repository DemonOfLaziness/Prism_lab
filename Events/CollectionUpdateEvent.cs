using Prism.Events;
using System;
using System.Collections.ObjectModel;

namespace Prism_lab.Events
{
	public class CollectionUpdateEvent : PubSubEvent<ObservableCollection<object>>
	{
		public CollectionUpdateEvent()
		{
		}
	}
}
