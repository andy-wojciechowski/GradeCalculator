using GradeCalculator.Interfaces.Presenters;
using System.Windows.Data;

namespace GradeCalculator.Interfaces.Views
{
    public interface IEditCategoryView
    {
        void SetPresenter(IEditCategoryPresenter presenter);
        void InitializeDataBinding(Binding nameBinding, Binding worthBinding);
    }
}
