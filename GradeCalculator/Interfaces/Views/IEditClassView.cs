using GradeCalculator.Interfaces.Presenters;
using System.Windows.Data;

namespace GradeCalculator.Interfaces.Views
{
    public interface IEditClassView
    {
        void InitializeDataBinding(Binding nameBinding);
        void SetPresenter(IEditClassPresenter presenter);
    }
}
