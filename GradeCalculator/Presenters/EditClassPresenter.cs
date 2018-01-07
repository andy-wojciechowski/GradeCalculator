using GradeCalculator.Model;
using GradeCalculator.Windows;
using GradeCalculator.Interfaces.Presenters;

namespace GradeCalculator.Presenters
{
    public class EditClassPresenter : IEditClassPresenter
    {
        private EditClassWindow view;
        private SchoolClass data { get; set; }

        public void UpdateAssignment(Assignment assignment)
        {
            EditAssignmentsWindow form = new EditAssignmentsWindow(assignment, data.Categories);
            form.Show();
        }

        public void AddAssignment()
        {
            Assignment newAssignment = new Assignment() { Name = string.Empty, Category = null, TotalPointsEarned = 0D, TotalPossiblePoints = 0D };
            this.data.Assignments.Add(newAssignment);
            EditAssignmentsWindow form = new EditAssignmentsWindow(newAssignment, data.Categories);
            form.Show();
        }

        public void UpdateCategory(GradeCategory category)
        {
            EditCategoryWindow form = new EditCategoryWindow(category);
            form.Show();
        }

        public void AddCategory()
        {
            GradeCategory category = new GradeCategory() { Name = string.Empty, CategoryWeight = 0D };
            this.data.Categories.Add(category);
            EditCategoryWindow form = new EditCategoryWindow(category);
            form.Show();
        }

        public void SetDataBindings()
        {
            this.view.InitalizeDataBinding(this.data);
        }

        public void SetView(EditClassWindow view)
        {
            this.view = view;
        }

        public void SetClass(SchoolClass model)
        {
            this.data = model;
        }
    }
}
