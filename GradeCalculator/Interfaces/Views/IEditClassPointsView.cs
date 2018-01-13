using GradeCalculator.Interfaces.Presenters;
using System.Windows.Data;

namespace GradeCalculator.Interfaces.Views
{
    public interface IEditClassPointsView
    {
        void InitializeDataBinding(Binding nameBinding);
        void SetPresenter(IEditClassPointsPresenter presenter);
    }
}
