using System.Windows.Data;

namespace GradeCalculator.Interfaces.Views
{
    public interface IEditCategoryView
    {
        void InitializeDataBinding(Binding nameBinding, Binding worthBinding);
    }
}
