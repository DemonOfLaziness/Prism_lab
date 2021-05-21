using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Prism_lab.Modules.ContainerModule
{
	[Serializable]
	class MyColor
	{
		private byte r;
		private byte g;
		private byte b;

		public byte R { get => r; set => r = value; }
		public byte G { get => g; set => g = value; }
		public byte B { get => b; set => b = value; }

		public MyColor(byte R = 255, byte G = 255, byte B = 255)
		{
			r = R;
			g = G;
			b = B;
		}

		public override bool Equals(object obj)
		{
			if (obj is Color)
			{
				var tmp = (Color)obj;
				if (tmp.R == r && tmp.G == g && tmp.B == b)
					return true;
				else return false;
			}

			return base.Equals(obj);
		}
	}
}
