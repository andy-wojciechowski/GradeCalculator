using GradeCalculator.Interfaces.Views;
using GradeCalculator.Model;

namespace GradeCalculator.Interfaces.Presenters
{
    public interface IEditCategoryPresenter
    {
        void SetView(IEditCategoryView view);
        void SetCategory(GradeCategory category);
        void SetDataBindings();
    }
}
