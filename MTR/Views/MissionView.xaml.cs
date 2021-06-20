namespace MTR.Views
{
    using MTR.ViewModels;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for TasksView.xaml
    /// </summary>
    public partial class MissionView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MissionView"/> class
        /// </summary>
        public MissionView()
        {
            this.InitializeComponent();
        }

        private void TextBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            var filterText = this.TextBoxSearch.Text;

            if (filterText != null)
            {
                (this.DataContext as MissionViewModel).Filter(filterText);
            }
        }

        private void ListBoxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
