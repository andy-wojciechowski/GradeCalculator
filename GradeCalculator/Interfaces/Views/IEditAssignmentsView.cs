using System.Windows.Data;

namespace GradeCalculator.Interfaces.Views
{
    public interface IEditAssignmentsView
    {
        void InitializeDataBinding(Binding nameBinding, Binding categoryBinding, Binding totalPointsEarnedBinding, Binding totalPossiblePointsBinding);
    }
}
