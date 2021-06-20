﻿using MTR.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace MTR.Converters
{

    /// <summary>
    /// Handles conversion of Priority value Important to boolean value and vice versa
    ///// </summary>
    public class PriorityToIsImportant : IValueConverter
    {
        /// <summary>
        /// Converts Priority to boolean values
        /// </summary>
        /// <returns>A boolean value determining if inputted value is important or not</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "Urgent, Important":
                case "Important":
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Convert back to important priority
        /// </summary>
        /// <returns>Priority.Important</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Priority.Important;
        }
    }
}

