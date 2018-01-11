using GradeCalculator.Interfaces.Views;
using GradeCalculator.Model;
using System.Collections.ObjectModel;

namespace GradeCalculator.Interfaces.Presenters
{
    public interface IEditAssignmentPresenter
    {
        void CloseView();
        void SetView(IEditAssignmentsView view);
        void SetAssignment(Assignment assignment);
        void SetGradeCategories(ObservableCollection<GradeCategory> categories);
        void SetDataBindings();
    }
}
