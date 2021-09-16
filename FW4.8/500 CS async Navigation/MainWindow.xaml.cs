// 500 CS async Navigation
// First program showing real use of async/await
// From http://www.microsoft.com/france/mstechdays/programmes/parcours.aspx?SessionID=002cf2d5-9d45-48a6-b8e0-9eafd0b8a6f9#&fbid=FVmAPqmbr6b
// 2012-03-17   PV

using System.Threading.Tasks;
using System.Windows;

namespace CS500
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        // Implement a simple state machine
        private ApplicationState state = ApplicationState.UC1;

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            var r = await NavigateTo(new UC1());
            // NavigateTo call is blocking, that will restart at the point where it stopped only when Continue is called,
            // without having to write a callback or a lambda
            MessageBox.Show(r.ToString());
            */

            while (state != ApplicationState.Exit)
                switch (state)
                {
                    case ApplicationState.UC1:
                        var r1 = await NavigateTo(new UC1());
                        if (r1 == NavigationResult.GoForward)
                            state = ApplicationState.UC2;
                        else if (r1 == NavigationResult.GoBackward)
                            state = ApplicationState.Exit;
                        break;

                    case ApplicationState.UC2:
                        var r2 = await NavigateTo(new UC2());
                        if (r2 == NavigationResult.GoBackward)
                            state = ApplicationState.UC1;
                        break;
                }
            Close();
        }

        // Since there is no await in the code, there is no need to add async on the method
        // In this case, NavigateTo is a "classical" method returning a Task
        private Task<TResult> NavigateTo<T, TResult>(INavigationContextProvider<T, TResult> provider) where T : UIElement
        {
            var navigation = provider.GetNavigationContext();
            var element = navigation.UIelement;
            navigationGrid.Children.Clear();
            navigationGrid.Children.Add(element);
            // Make call blocking
            return navigation.WaitForContinuationTask();
        }
    }

    public enum ApplicationState { UC1, UC2, Exit }
}