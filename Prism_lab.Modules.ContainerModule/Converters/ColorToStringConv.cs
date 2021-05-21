using System;
using MvvmLib;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Prism_lab.Modules.ContainerModule.Converters
{
	public class ColorToStringConv : ConvertorBase<ColorToStringConv>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			MyColor tmp = (MyColor)value;

			if (tmp.Equals(Color.FromRgb(0, 0, 0)))
				return "Black";
			else if (tmp.Equals(Color.FromRgb(255, 0, 0)))
				return "Red";
			else if (tmp.Equals(Color.FromRgb(0, 255, 0)))
				return "Green";
			else if (tmp.Equals(Color.FromRgb(0, 0, 255)))
				return "Blue";
			else if (tmp.Equals(Color.FromRgb(255, 255, 255)))
				return "White";
			else if (tmp.Equals(Color.FromRgb(255, 255, 0)))
				return "Yellow";
			else if (tmp.Equals(Color.FromRgb(128, 128, 128)))
				return "Gray";
			else return "Inknown color";
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var tmp = (string)value;

			if (tmp == "Black")
				return new MyColor(0, 0, 0);
			else if (tmp == "Red")
				return new MyColor(255, 0, 0);
			else if (tmp == "Green")
				return new MyColor(0, 255, 0);
			else if (tmp == "Blue")
				return new MyColor(0, 0, 255);
			else if (tmp == "White")
				return new MyColor(255, 255, 255);
			else if (tmp == "Yellow")
				return new MyColor(255, 255, 0);
			else if (tmp == "Gray")
				return new MyColor(128, 128, 128);
			else return new MyColor(67, 0, 67);
		}
	}
}
