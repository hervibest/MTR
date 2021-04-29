namespace MTR.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using MTR.Commands;
    using MTR.Models;

    /// <summary>
    /// View model for all objects of type ToDoList.Models.Task
    /// </summary>
    public class MissionViewModel : BaseViewModel<Mission>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MissionViewModel"/> class
        /// </summary>
        public MissionViewModel()
            : base()
        {
            this.SortItems = new RelayCommand(this.HandleSortItems);
            this.itemPool = DataTranslator<Mission>.Deserialize();
        }

        /// <summary>
        /// Gets or sets a command for sorting all tasks by their priority
        /// </summary>
        public ICommand SortItems { get; set; }

        /// <summary>
        /// Method for handling sorting of all the tasks
        /// </summary>
        private void HandleSortItems(object obj)
        {
            ObservableCollection<Mission> sorted = new ObservableCollection<Mission>();
            sorted = new ObservableCollection<Mission>(this.itemPool.OrderByDescending(task => task.Priority));
            this.Items = sorted;
        }
    }
}
