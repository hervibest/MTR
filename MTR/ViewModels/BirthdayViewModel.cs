﻿namespace MTR.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using MTR.Commands;
    using MTR.Models;

    /// <summary>
    /// View model for all objects of type ToDoList.Models.BirthdayReminder
    /// </summary>
    public class BirthdayViewModel : BaseViewModel<Birthday>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BirthdayViewModel"/> class
        /// </summary>
        public BirthdayViewModel()
            : base()
        {
            this.SortItems = new RelayCommand(this.HandleSortItems);
            this.itemPool = DataTranslator<Birthday>.Deserialize();
        }

        /// <summary>
        /// Gets or sets a command for sorting all reminders by date
        /// </summary>
        public ICommand SortItems { get; set; }

        /// <summary>
        /// Method for handling sorting of all the goals
        /// </summary>
        private void HandleSortItems(object obj)
        {
            ObservableCollection<Birthday> sorted = new ObservableCollection<Birthday>();
            sorted = new ObservableCollection<Birthday>(this.itemPool.OrderBy(reminder => reminder.EventDate.Month)
                                                                             .ThenBy(reminder => reminder.EventDate.Day)
                                                                             .ThenBy(reminder => reminder.PersonName));
            this.Items = sorted;
        }
    }
}
