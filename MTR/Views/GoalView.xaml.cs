namespace MTR.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using MTR.ViewModels;

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
