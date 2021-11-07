using System.Windows;
using System.Windows.Controls;

namespace CS500;

/// <summary>
/// Interaction logic for UC1.xaml
/// </summary>
public partial class UC1 : UserControl, INavigationContextProvider<UC1, NavigationResult>
{
    public UC1()
    {
        InitializeComponent();
        // context = new NavigationContext<UC1, NavigationResult>(this);
        // Trick with a helper class to enable inference for type UC1 through Create method which is the type of this
        context = NavigationContext<NavigationResult>.Create(this);
    }

    private readonly INavigationContext<UC1, NavigationResult> context;

    public INavigationContext<UC1, NavigationResult> GetNavigationContext()
    {
        return context;
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        // "Frees" synchronization context in context which is a Task
        context.Continue(NavigationResult.GoForward);
    }

    // Exit button
    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        context.Continue(NavigationResult.GoBackward);
    }
}