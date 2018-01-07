using GradeCalculator.Model;
using GradeCalculator.Windows;
using System.Collections.ObjectModel;

namespace GradeCalculator.Interfaces.Presenters
{
    public interface IEditAssignmentPresenter
    {
        void SetView(EditAssignmentsWindow view);
        void SetAssignment(Assignment assignment);
        void SetGradeCategories(ObservableCollection<GradeCategory> categories);
        void SetDataBindings();
    }
}
