using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace View.Converters
{
	class AngleLegPointConverter : IValueConverter
	{
		public double LegLength { get; set; }

		public string Center { get; set; }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var angle = (double)value;
			var centerCoords = Center.Split(',').Select(int.Parse);
			var center = new Point(centerCoords.First(), centerCoords.Last());
			var legPoint = new Point(
				(int)Math.Round(Math.Sin(angle) * LegLength),
				-(int)Math.Round(Math.Cos(angle) * LegLength)
			);
			legPoint.Offset(center);
			return legPoint;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
