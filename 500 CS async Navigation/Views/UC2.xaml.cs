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

namespace CS500
{
    /// <summary>
    /// Interaction logic for UC2.xaml
    /// </summary>
    public partial class UC2 : UserControl, INavigationContextProvider<UC2, NavigationResult>
    {
        public UC2()
        {
            InitializeComponent();
            context = NavigationContext<NavigationResult>.Create(this);
        }

        private INavigationContext<UC2, NavigationResult> context;

        public INavigationContext<UC2, NavigationResult> GetNavigationContext()
        {
            return context;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            context.Continue(NavigationResult.GoBackward);
        }
    }
}
