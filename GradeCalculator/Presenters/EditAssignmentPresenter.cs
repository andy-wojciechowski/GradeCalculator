using GradeCalculator.Interfaces.Presenters;
using GradeCalculator.Model;
using GradeCalculator.Windows;
using System.Collections.ObjectModel;

namespace GradeCalculator.Presenters
{
    public class EditAssignmentPresenter : IEditAssignmentPresenter
    {
        private EditAssignmentsWindow view { get; set; }
        private ObservableCollection<GradeCategory> categories { get; set; }
        private Assignment data { get; set; }

        public void SetView(EditAssignmentsWindow view)
        {
            this.view = view;
        }

        public void SetAssignment(Assignment assignment)
        {
            this.data = assignment;
        }

        public void SetGradeCategories(ObservableCollection<GradeCategory> categories)
        {
            this.categories = categories;
        }

        public void SetDataBindings()
        {
            this.view.InitializeDataBinding(this.data, this.categories);
        }
    }
}
