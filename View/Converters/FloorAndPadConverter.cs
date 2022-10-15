using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace View.Converters
{
	public class FloorAndPadConverter : IValueConverter
	{
		public int PadAmount { get; set; }


		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int number;
			if (value is double)
			{
				number = (int)(double)value;
			}
			else
			{
				number = (int)value;
			}

			return number.ToString().PadLeft(PadAmount, '0');
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
