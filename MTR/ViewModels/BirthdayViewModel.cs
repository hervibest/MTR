namespace MTR.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using MTR.Commands;
    using MTR.Models;
    using FireSharp.Config;
    using FireSharp.Response;
    using FireSharp.Interfaces;
    /// <summary>
    /// View model for all objects of type ToDoList.Models.BirthdayReminder
    /// </summary>
    public class BirthdayViewModel : BaseViewModel<Birthday>
    {
        IFirebaseConfig fcon = new FirebaseConfig()
        {
            AuthSecret = "9BsfBOIE3mpXF2A1eapIG1tKDY7PNHUNw3jXWtyy",
            BasePath = "https://mission-to-remember-default-rtdb.firebaseio.com/"
        };
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BirthdayViewModel"/> class
        /// </summary>
        public BirthdayViewModel()
            : base()
        {
            this.SortItems = new RelayCommand(this.HandleSortItems);
            this.itemPool = DataTranslator<Birthday>.Deserialize();
            try
            {
                client = new FireSharp.FirebaseClient(fcon);
            }
            catch
            {
                
            }
        }

        /// <summary>
        /// Gets or sets a command for sorting all reminders by date
        /// </summary>
        public ICommand SortItems { get; set; }
        IFirebaseClient client;
        /// <summary>
        /// Method for handling sorting of all the goals
        /// </summary>
        private void HandleSortItems(object obj)
        {
            ObservableCollection<Birthday> sorted = new ObservableCollection<Birthday>();
            
            sorted = new ObservableCollection<Birthday>(this.itemPool.OrderBy(reminder => reminder.EventDate.Month)
                                                                             .ThenBy(reminder => reminder.EventDate.Day)
                                                                             .ThenBy(reminder => reminder.PersonName));
            var setter = client.Set("Birthday", sorted);
            this.Items = sorted;
        }
    }
}
