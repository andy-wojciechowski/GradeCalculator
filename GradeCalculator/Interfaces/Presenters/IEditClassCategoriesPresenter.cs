using GradeCalculator.Interfaces.Views;
using GradeCalculator.Model;

namespace GradeCalculator.Interfaces.Presenters
{
    public interface IEditClassCategoriesPresenter
    {
        void SetView(IEditClassCategoriesView view);
        void SetClass(SchoolClass model);
        void UpdateAssignment(Assignment assignment);
        void AddAssignment();
        void UpdateCategory(GradeCategory category);
        void AddCategory();
        void SetDataBindings();
    }
}
