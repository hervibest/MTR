namespace MTR.Views
{
    using MTR.ViewModels;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for MeetingView.xaml
    /// </summary>
    public partial class MeetingView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeetingView"/> class
        /// </summary>
        public MeetingView()
        {
            // TODO
            this.InitializeComponent();

            // this.DataContext = new MeetingViewModel();
        }

        private void TextBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            var filterText = this.TextBoxSearch.Text;

            if (filterText != null)
            {
                (this.DataContext as MeetingViewModel).Filter(filterText);
            }
        }

        private void ListBoxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
