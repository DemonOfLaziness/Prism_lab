using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows.Media;
using Prism.Mvvm;

namespace Prism_lab.Modules.ContainerModule.Models
{
	class Bird : BindableBase
	{
		private string species;
		private string name;
		private int age;
		private MyColor color;

		public Bird()
		{
			Species = "empty";
			Name = "-";
			Age = 0;
			Color = new MyColor();
		}

		public string Species
		{
			get { return species; }
			set 
			{ 
				SetProperty(ref species, value);
			}
		}

		public string Name
		{
			get { return name; }
			set 
			{
				SetProperty(ref name, value);
			}
		}

		public int Age
		{
			get { return age; }
			set
			{
				if (value >= 0 && value <= 50)
				{
					SetProperty(ref age, value);
				}
			}
		}

		public MyColor Color
		{
			get { return color; }
			set 
			{
				SetProperty(ref color, value);
			}
		}

		public override string ToString()
		{
			return $"Имя: {Name}, вид: {Species}, возраст: {Age}";
		}

		public new event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
	}
}
