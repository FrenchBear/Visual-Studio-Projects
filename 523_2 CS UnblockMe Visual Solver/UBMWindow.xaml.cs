// 523CSB UnblockMe Solver Visual'
// Visual interface for UnblockMe Solver
// 2014-07-22   PV

using System.Windows;
using System.Windows.Input;

namespace CS523B_UnblockMe_Solver_Visual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UBMWindow : Window
    {
        public UBMWindow()
        {
            InitializeComponent();

            // Move focus to 1st control
            // Other options at http://stackoverflow.com/questions/817610/wpf-and-initial-focus
            Loaded += (sender, e) => MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }
    }
}