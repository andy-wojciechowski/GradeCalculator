using GradeCalculator.Model;
using GradeCalculator.Windows;

namespace GradeCalculator.Interfaces.Presenters
{
    public interface IEditCategoryPresenter
    {
        void SetView(EditCategoryWindow view);
        void SetCategory(GradeCategory category);
        void SetDataBindings();
    }
}
