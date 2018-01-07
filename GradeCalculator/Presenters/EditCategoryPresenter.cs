using GradeCalculator.Model;
using GradeCalculator.Windows;
using GradeCalculator.Interfaces.Presenters;

namespace GradeCalculator.Presenters
{
    public class EditCategoryPresenter : IEditCategoryPresenter
    {
        private GradeCategory category { get; set; }
        private EditCategoryWindow view { get; set; }

        public void SetCategory(GradeCategory category)
        {
            this.category = category;
        }

        public void SetDataBindings()
        {
            this.view.InitializeDataBinding(category);
        }

        public void SetView(EditCategoryWindow view)
        {
            this.view = view;
        }
    }
}
