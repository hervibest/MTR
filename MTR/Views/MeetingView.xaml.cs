namespace MTR.Views
{
    using MTR.ViewModels;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for NotesView.xaml
    /// </summary>
    public partial class NotesView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotesView"/> class
        /// </summary>
        public NotesView()
        {
            this.InitializeComponent();
        }

        private void TextBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            var filterText = this.TextBoxSearch.Text;

            if (filterText != null)
            {
                (this.DataContext as NoteViewModel).Filter(filterText);
            }
        }
    }
}
