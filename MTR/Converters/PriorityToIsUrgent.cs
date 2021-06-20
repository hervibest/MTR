namespace MTR.Converters
{
    using MTR.Models;
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// Handles conversion of Priority value Urgent to boolean value and vice versa
    /// </summary>
    public class PriorityToIsUrgent : IValueConverter
    {
        /// <summary>
        /// Convert priority to boolean value
        /// </summary>
        /// <returns>A boolean value determining if inputted value is urgent or not</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "Urgent, Important":
                case "Urgent":
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Convert back to urgent priority
        /// </summary>
        /// <returns>Priority.Urgent</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Priority.Urgent;
        }
    }
}
