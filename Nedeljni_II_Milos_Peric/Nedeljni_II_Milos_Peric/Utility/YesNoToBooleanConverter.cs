﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Nedeljni_II_Milos_Peric.Utility
{
	public class YesNoToBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{

			switch (value.ToString())
			{
				case "Yes":
					return true;
				case "No":
					return false;
			}
			return false;

		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool)
			{
				if ((bool)value == true)
					return "Yes";
				else
					return "No";
			}
			return "No";
		}
	}
}
