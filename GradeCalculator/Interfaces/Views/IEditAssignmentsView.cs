using GradeCalculator.Interfaces.Presenters;
using System.Windows.Controls;
using System.Windows.Data;

namespace GradeCalculator.Interfaces.Views
{
    public interface IEditAssignmentsView
    {
        ComboBox CategoryCombobox { get; }
        void SetPresenter(IEditAssignmentPresenter presenter);
        void ShowWindow();
        void CloseWindow();
        void InitializeDataBinding(Binding nameBinding, Binding categoryBinding, Binding totalPointsEarnedBinding, Binding totalPossiblePointsBinding);
    }
}
