using System.Windows.Controls;

namespace GradeCalculator.Interfaces.Views
{
    public interface IMainWindowView
    {
        DataGrid ClassesGrid { get; }
        void Initialize();
    }
}
