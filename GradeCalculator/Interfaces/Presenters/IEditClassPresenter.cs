using GradeCalculator.Model;
using GradeCalculator.Windows;

namespace GradeCalculator.Interfaces.Presenters
{
    public interface IEditClassPresenter
    {
        void SetView(EditClassWindow view);
        void SetClass(SchoolClass model);
        void UpdateAssignment(Assignment assignment);
        void AddAssignment();
        void UpdateCategory(GradeCategory category);
        void AddCategory();
        void SetDataBindings();
    }
}
