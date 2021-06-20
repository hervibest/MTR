namespace MTR.Views
{
    using MTR.ViewModels;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for BirthdayView.xaml
    /// </summary>
    public partial class BirthdayView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BirthdayView"/> class
        /// </summary>
        public BirthdayView()
        {
            this.InitializeComponent();
        }

        private void TextBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            var filterText = this.TextBoxSearch.Text;

            if (filterText != null)
            {
                (this.DataContext as BirthdayViewModel).Filter(filterText);
            }
        }

        private void ListBoxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
