using GradeCalculator.Interfaces.Presenters;
using GradeCalculator.Interfaces.Views;
using GradeCalculator.Model;
using System.Windows;
using System.Windows.Data;

namespace GradeCalculator.Presenters
{
    public class EditCategoryPresenter : IEditCategoryPresenter
    {
        private GradeCategory category { get; set; }
        private IEditCategoryView view { get; set; }

        public void SetCategory(GradeCategory category)
        {
            this.category = category;
        }

        public void SetDataBindings()
        {
            //Name Property
            Binding nameBinding = new Binding();
            nameBinding.Source = this.category;
            nameBinding.Path = new PropertyPath("Name");
            nameBinding.Mode = BindingMode.TwoWay;
            nameBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            //Worth Property
            Binding worthBinding = new Binding();
            worthBinding.Source = this.category;
            worthBinding.Path = new PropertyPath("CategoryWeight");
            worthBinding.Mode = BindingMode.TwoWay;
            worthBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            this.view.InitializeDataBinding(nameBinding, worthBinding);
        }

        public void SetView(IEditCategoryView view)
        {
            this.view = view;
        }
    }
}
