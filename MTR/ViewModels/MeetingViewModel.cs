namespace MTR.ViewModels
{
    using FireSharp.Config;
    using FireSharp.Interfaces;
    using MTR.Commands;
    using MTR.Models;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Input;

    /// <summary>
    /// View model for all objects of type ToDoList.Models.Meeting
    /// </summary>
    public class MeetingViewModel : BaseViewModel<Meeting>
    {
        IFirebaseConfig fcon = new FirebaseConfig()
        {
            AuthSecret = "9BsfBOIE3mpXF2A1eapIG1tKDY7PNHUNw3jXWtyy",
            BasePath = "https://mission-to-remember-default-rtdb.firebaseio.com/"
        };
        /// <summary>
        /// Initializes a new instance of the <see cref="MeetingViewModel"/> class
        /// </summary>
        public MeetingViewModel()
            : base()
        {
            this.SortItems = new RelayCommand(this.Sort);
            this.itemPool = DataTranslator<Meeting>.Deserialize();

            try
            {
                client = new FireSharp.FirebaseClient(fcon);
            }
            catch
            {

            }
        }

        /// <summary>
        /// Gets or sets a command for sorting all meetings by the time of their happening
        /// </summary>
        public ICommand SortItems { get; set; }
        IFirebaseClient client;
        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            // Handle closing logic, set e.Cancel as needed
            // tried to set event on closing the window, but it's not working

            // MessageBox.Show("Exit The Project");
        }

        private void Sort(object obj)
        {
            ObservableCollection<Meeting> sorted = new ObservableCollection<Meeting>();
            sorted = new ObservableCollection<Meeting>(this.itemPool.OrderBy(meeting => meeting.EventDate)
                                                                    .ThenBy(meeting => meeting.StartTime));
            var setter = client.Set("Meeting", sorted);
            this.Items = sorted;
        }
    }
}
