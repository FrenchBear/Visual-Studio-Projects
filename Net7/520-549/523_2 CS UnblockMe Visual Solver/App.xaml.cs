using System.Windows;

namespace CS523B;

public partial class App: Application
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