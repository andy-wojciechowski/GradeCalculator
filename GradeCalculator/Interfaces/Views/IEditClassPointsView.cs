using GradeCalculator.Interfaces.Presenters;
using System.Windows.Controls;
using System.Windows.Data;

namespace GradeCalculator.Interfaces.Views
{
    public interface IEditClassPointsView
    {
        DataGrid AssignmentsDataGrid { get; }
        void InitializeDataBinding(Binding nameBinding);
        void SetPresenter(IEditClassPointsPresenter presenter);
        void ShowWindow();
    }
}
