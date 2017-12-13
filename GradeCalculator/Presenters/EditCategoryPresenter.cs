using GradeCalculator.Model;
using GradeCalculator.Windows;

namespace GradeCalculator.Presenters
{
    public class EditCategoryPresenter : BasePresenter<EditCategoryForm>
    {
        private GradeCategory category { get; set; }
        public EditCategoryPresenter(EditCategoryForm form, GradeCategory category) : base(form)
        {
            this.category = category;
            this.InitializeDataBinding();
        }

        private void InitializeDataBinding()
        {
            this.View.InitializeDataBinding(this.category);
        }
    }
}
