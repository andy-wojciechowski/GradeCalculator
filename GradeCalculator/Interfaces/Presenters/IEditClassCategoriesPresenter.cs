using GradeCalculator.Interfaces.Views;
using GradeCalculator.Model;

namespace GradeCalculator.Interfaces.Presenters
{
    public interface IEditClassCategoriesPresenter
    {
        void SetView(IEditClassCategoriesView view);
        void SetClass(SchoolClass model);
        void UpdateAssignment();
        void AddAssignment();
        void UpdateCategory();
        void AddCategory();
        void SetDataBindings();
    }
}
