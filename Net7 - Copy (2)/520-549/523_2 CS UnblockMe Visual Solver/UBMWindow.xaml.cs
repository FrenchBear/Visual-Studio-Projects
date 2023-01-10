// 523CSB UnblockMe Solver Visual'
// Visual interface for UnblockMe Solver
//
// 2014-07-22   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7

using System.Windows;
using System.Windows.Input;

namespace CS523B;

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
