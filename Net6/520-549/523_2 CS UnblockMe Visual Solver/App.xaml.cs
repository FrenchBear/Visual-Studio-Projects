using System.Windows;

namespace CS523B_UnblockMe_Solver_Visual;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var w = new UBMWindow();
        var vm = new UBMViewModel(w);
        w.DataContext = vm;

        w.Show();
    }
}