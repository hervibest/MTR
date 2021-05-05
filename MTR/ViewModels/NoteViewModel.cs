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
    /// View model for all objects of type ToDoList.Models.Note
    /// </summary>
    public class NoteViewModel : BaseViewModel<Note>
    {
        IFirebaseConfig fcon = new FirebaseConfig()
        {
            AuthSecret = "9BsfBOIE3mpXF2A1eapIG1tKDY7PNHUNw3jXWtyy",
            BasePath = "https://mission-to-remember-default-rtdb.firebaseio.com/"
        };
        /// <summary>
        /// Initializes a new instance of the <see cref="NoteViewModel"/> class
        /// </summary>
        public NoteViewModel()
            : base()
        {
            this.SortItems = new RelayCommand(this.HandleSortItems);
            this.itemPool = DataTranslator<Note>.Deserialize();

            try
            {
                client = new FireSharp.FirebaseClient(fcon);
            }
            catch
            {

            }
        }

        /// <summary>
        /// Gets or sets a command for sorting all notes by their title
        /// </summary>
        public ICommand SortItems { get; set; }
        IFirebaseClient client;

        /// <summary>
        /// Method for handling sorting of all the notes
        /// </summary>
        private void HandleSortItems(object obj)
        {
            ObservableCollection<Note> sorted = new ObservableCollection<Note>();
            sorted = new ObservableCollection<Note>(this.itemPool.OrderBy(note => note.Title));
            var setter = client.Set("Note", sorted);
            this.Items = sorted;
        }
    }
}
