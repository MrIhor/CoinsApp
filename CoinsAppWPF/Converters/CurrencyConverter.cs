using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CoinsAppWPF.Converters
{
    public class CurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double number)
            {
                return FormatNumber(number);
            }

            if (value is string stringValue)
            {
                if (double.TryParse(stringValue, out double parsedNumber))
                {
                    return FormatNumber(parsedNumber);
                }
            }

            return value; // Return the original value if it's not a valid double or string
        }

        private string FormatNumber(double number)
        {
            const int roundTo = 1;
            double abbreviatedNumber = number;

            string[] suffixes = { "", "K", "M", "B", "T" };

            int suffixIndex = 0;
            while (abbreviatedNumber >= 1000 && suffixIndex < suffixes.Length - 1)
            {
                abbreviatedNumber /= 1000;
                suffixIndex++;
            }

            string formattedNumber = Math.Round(abbreviatedNumber, roundTo).ToString();
            formattedNumber += suffixes[suffixIndex];

            return formattedNumber;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
