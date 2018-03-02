using GradeCalculator.Interfaces.Presenters;
using GradeCalculator.Interfaces.Views;
using GradeCalculator.Model;
using System.Windows;
using System.Windows.Data;

namespace GradeCalculator.Presenters
{
    public class EditCategoryPresenter : IEditCategoryPresenter
    {
        private GradeCategory Categories { get; set; }
        private IEditCategoryView View { get; set; }

        public void SetCategory(GradeCategory category)
        {
            this.Categories = category;
        }

        public void CloseView()
        {
            this.View.CloseWindow();
        }

        public void SetDataBindings()
        {
            //Name Property
            Binding nameBinding = new Binding();
            nameBinding.Source = this.Categories;
            nameBinding.Path = new PropertyPath("Name");
            nameBinding.Mode = BindingMode.TwoWay;
            nameBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            //Worth Property
            Binding worthBinding = new Binding();
            worthBinding.Source = this.Categories;
            worthBinding.Path = new PropertyPath("CategoryWeight");
            worthBinding.Mode = BindingMode.TwoWay;
            worthBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            this.View.InitializeDataBinding(nameBinding, worthBinding);
        }

        public void SetView(IEditCategoryView view)
        {
            this.View = view;
        }
    }
}
