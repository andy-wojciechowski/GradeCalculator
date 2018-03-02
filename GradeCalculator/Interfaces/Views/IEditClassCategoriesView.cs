using GradeCalculator.Interfaces.Presenters;
using System.Windows.Controls;
using System.Windows.Data;

namespace GradeCalculator.Interfaces.Views
{
    public interface IEditClassCategoriesView
    {
        DataGrid CategoryGrid { get; }
        DataGrid AssignmentsGrid { get; }
        void InitializeDataBinding(Binding nameBinding);
        void SetPresenter(IEditClassCategoriesPresenter presenter);
        void ShowWindow();
    }
}
