// UBMViewModel
// ViewModel for UnblockMe Solver
//
// 2014-07-22 PV
// 2021-09-26   PV      VS2022; Net6

using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CS523B;

internal class UBMViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private readonly UBMModel m;
    private readonly UBMWindow w;

    // Commands
    public ICommand SolveCommand { get; private set; }

    // Constructor
    public UBMViewModel(UBMWindow w)
    {
        // Keep a reference to View
        this.w = w;

        m = new UBMModel();

        // Binding commands with behavior
        SolveCommand = new RelayCommand<object>(SolveExecute, CanSolve);
    }

    // Solve: Automatic resolution of labyrinth
    public void SolveExecute(object parameter) =>
        // ToDo
        DrawSolution();

    public bool CanSolve(object parameter) => true;

    private readonly Brush[] PieceBrushes =
    {
        Brushes.AliceBlue,
        Brushes.AntiqueWhite,
        Brushes.Aqua,
        Brushes.Aquamarine,
        Brushes.Azure,
        Brushes.Beige,
        Brushes.Bisque,
        Brushes.Blue,
        Brushes.BlueViolet,
        Brushes.Brown
    };

    private void DrawSolution()
    {
        w.myGrid.Children.Clear();

        for (int i = 0; i < m.Configuration.Length; i++)
        {
            Rectangle r = new();
            if (m.Pieces[i].IsHorizontal)
            {
                r.Width = 100 * m.Pieces[i].Length;
                r.Height = 100;
                r.SetValue(Grid.RowProperty, (int)m.Pieces[i].RowCol);
                r.SetValue(Grid.ColumnProperty, (int)m.Configuration.Pos[i]);
                r.SetValue(Grid.ColumnSpanProperty, (int)m.Pieces[i].Length);
            }
            else
            {
                r.Width = 100;
                r.Height = 100 * m.Pieces[i].Length;
                r.SetValue(Grid.ColumnProperty, (int)m.Pieces[i].RowCol);
                r.SetValue(Grid.RowProperty, (int)m.Configuration.Pos[i]);
                r.SetValue(Grid.RowSpanProperty, (int)m.Pieces[i].Length);
            }

            r.Fill = i == m.redPiece ? Brushes.Red : PieceBrushes[i];

            _ = w.myGrid.Children.Add(r);
        }
    }
}