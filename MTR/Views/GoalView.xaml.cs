namespace MTR.Views
{
    using MTR.ViewModels;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for GoalsView.xaml
    /// </summary>
    public partial class GoalView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoalView"/> class
        /// </summary>
        public GoalView()
        {
            this.InitializeComponent();
        }

        private void TextBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            var filterText = this.TextBoxSearch.Text;

            if (filterText != null)
            {
                (this.DataContext as GoalViewModel).Filter(filterText);
            }
        }
    }
}
