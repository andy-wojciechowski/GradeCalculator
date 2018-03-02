using GradeCalculator.Interfaces.Presenters;
using System.Windows.Data;

namespace GradeCalculator.Interfaces.Views
{
    public interface IEditAssignmentsView
    {
        void SetPresenter(IEditAssignmentPresenter presenter);
        void ShowWindow();
        void CloseWindow();
        void InitializeDataBinding(Binding nameBinding, Binding categoryBinding, Binding totalPointsEarnedBinding, Binding totalPossiblePointsBinding);
    }
}
