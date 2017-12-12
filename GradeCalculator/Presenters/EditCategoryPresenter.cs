using GradeCalculator.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeCalculator.Model;

namespace GradeCalculator.Presenters
{
    public class EditCategoryPresenter : BasePresenter<EditCategoryForm>
    {
        private GradeCategory category { get; set; }
        public EditCategoryPresenter(EditCategoryForm form, GradeCategory category) : base(form)
        {
            this.category = category;
        }

        public void InitializeDataBinding()
        {
            this.View.InitializeDataBinding(category);
        }
    }
}
