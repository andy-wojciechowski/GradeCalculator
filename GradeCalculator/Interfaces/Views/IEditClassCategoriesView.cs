using GradeCalculator.Interfaces.Presenters;
using System.Windows.Data;

namespace GradeCalculator.Interfaces.Views
{
    public interface IEditClassCategoriesView
    {
        void InitializeDataBinding(Binding nameBinding);
        void SetPresenter(IEditClassCategoriesPresenter presenter);
        void ShowWindow();
    }
}
