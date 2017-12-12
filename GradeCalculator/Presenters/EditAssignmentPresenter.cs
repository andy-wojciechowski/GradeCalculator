using GradeCalculator.Model;
using GradeCalculator.Windows;
using System.Collections.ObjectModel;

namespace GradeCalculator.Presenters
{
    public class EditAssignmentPresenter : BasePresenter<EditAssignmentsForm>
    {
        private Assignment data { get; set; }
        public EditAssignmentPresenter(EditAssignmentsForm form, Assignment assignment, ObservableCollection<GradeCategory> categories) : base(form)
        {
            this.data = assignment;
        }

        private void SetDataBinding(ObservableCollection<GradeCategory> categories)
        {
            this.View.InitializeDataBinding(this.data, categories);
        }
    }
}
