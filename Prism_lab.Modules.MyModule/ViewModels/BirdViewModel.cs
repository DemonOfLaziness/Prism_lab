using ControlsLibrary;
//using MvvmLib;
using Prism_lab;
using Prism.Commands;
using Prism.Events;
using Prism_lab.Modules.BirdModule.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Windows;
using Prism_lab.Events;

namespace Prism_lab.Modules.BirdModule.ViewModels
{
	class BirdViewModel : Prism.Mvvm.BindableBase
	{
		private Bird currBird;
		private ObservableCollection<Bird> birds;
		private ColoredButtVM buttVM;
		private IEventAggregator eventAgregator;

		#region props
		public ColoredButtVM ButtVM
		{
			get { return buttVM; }
			set => SetProperty(ref buttVM, value);
		}

		public ObservableCollection<Bird> Birds
		{
			get
			{
				return birds;
			}
			set => SetProperty(ref birds, value);
		}
		public Bird CurrBird
		{
			get { return currBird; }
			set => SetProperty(ref currBird, value);
		}

		public List<MyColor> Colors { get; set; }
		#endregion

		#region ctor
		public BirdViewModel(IEventAggregator ea)
		{
			eventAgregator = ea;
			Colors = new List<MyColor>();

			//using (var jFile = new StreamReader("BirdsList.txt")) // ВЫТАЩИ В ОТДЕЛЬНЫЙ ИНТЕРФЕЙС
			//{
			//	var jString = jFile.ReadToEnd();

			//	if (jString.Length > 0)
			//		Birds = JsonSerializer.Deserialize<ObservableCollection<Bird>>(jString);
			//	else
			//		Birds = new ObservableCollection<Bird>();
			//}

			Colors.Add(new MyColor(0, 0, 0));
			Colors.Add(new MyColor(255, 0, 0));
			Colors.Add(new MyColor(0, 255, 0));
			Colors.Add(new MyColor(0, 0, 255));
			Colors.Add(new MyColor(255, 255, 255));
			Colors.Add(new MyColor(255, 255, 0));
			Colors.Add(new MyColor(128, 128, 128));

			ButtVM = new ColoredButtVM();
			CurrBird = new Bird();
		}
		#endregion

		#region Commands
		private DelegateCommand<object> addElem;
		public DelegateCommand<object> AddElem
		{
			get
			{
				return addElem ?? (addElem = new DelegateCommand<object>(x =>
				{
					Birds.Add(CurrBird);
					CurrBird = new Bird();

					AddElem.RaiseCanExecuteChanged();
					DelElem.RaiseCanExecuteChanged();

					eventAgregator.GetEvent<CollectionUpdateEvent>().Publish(new ObservableCollection<object>(Birds));

				}, x => Birds.Count < 4));
			}
			//oператор называется оператором объединения с нулевым
			//значением и используется для определения значения по
			//умолчанию для типов значений, допускающих значение NULL, а
			//также для ссылочных типов. Он возвращает левый операнд, если
			//он не равен нулю; в противном случае возвращается правильный
			//операнд. 
		}

		private DelegateCommand<object> delElem;
		public DelegateCommand<object> DelElem
		{
			get
			{
				return delElem ?? (delElem = new DelegateCommand<object>(x =>
				{
					Birds.Remove(Birds.Last());

					AddElem.RaiseCanExecuteChanged();
					DelElem.RaiseCanExecuteChanged();

					eventAgregator.GetEvent<CollectionUpdateEvent>().Publish(new ObservableCollection<object>(Birds));

				#if DEBUG
					MessageBox.Show("Команда delElem только что кого-то убила");
				#endif

				}, x => Birds.Count > 0));
			}
		}

		private DelegateCommand collectionUpdate;
		public DelegateCommand CollectionUpdate
		{
			get => collectionUpdate;
			set => eventAgregator.GetEvent<CollectionUpdateEvent>().Publish(new ObservableCollection<object>(Birds));		
		}
		#endregion

		//public event PropertyChangedEventHandler PropertyChanged;
		//public void OnPropertyChanged([CallerMemberName] string prop = "")
		//{
		//	if (PropertyChanged != null)
		//		PropertyChanged(this, new PropertyChangedEventArgs(prop));
		//}

		//~BirdViewModel()
		//{
		//	using (var jFile = new StreamWriter("BirdsList.txt", false))
		//	{
		//		var jString = JsonSerializer.Serialize(Birds);

		//		jFile.Write(jString);
		//	}
		//} // в призме так не надо!
	}
}
