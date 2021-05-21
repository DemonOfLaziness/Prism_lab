using System;
using Prism.Events;

namespace Prism_lab.Events

public class CollectionUpdateEvent : PubSubEvent<ObservableCollection<object>>
{
	public CollectionUpdateEvent()
	{
	}
}
