using GradeCalculator.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeCalculator.Model;

namespace GradeCalculator.Presenters
{ 
    public class EditClassPresenter : BasePresenter<EditClassForm>
    {   
        private SchoolClass data { get; set; }
        public EditClassPresenter(EditClassForm form, SchoolClass model): base(form)
        {
            this.data = model;
            SetDataBindings();
        }

        private void SetDataBindings()
        {
            this.View.InitalizeDataBinding(this.data);
        }
    }
}
