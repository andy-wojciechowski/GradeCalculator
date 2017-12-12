using GradeCalculator.Model;
using GradeCalculator.Windows;

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

        public void UpdateAssignment(Assignment assignment)
        {
            EditAssignmentsForm form = new EditAssignmentsForm(assignment, data.Categories);
            form.Show();
        }

        public void AddAssignment()
        {
            Assignment newAssignment = new Assignment() { Name = string.Empty, Category = null, TotalPointsEarned = 0D, TotalPossiblePoints = 0D };
            this.data.Assignments.Add(newAssignment);
            EditAssignmentsForm form = new EditAssignmentsForm(newAssignment, data.Categories);
            form.Show();
        }

        public void UpdateCategory(GradeCategory category)
        {
            EditCategoryForm form = new EditCategoryForm(category);
            form.Show();
        }

        public void AddCategory()
        {
            GradeCategory category = new GradeCategory() { Name = string.Empty, CategoryWeight = 0D };
            this.data.Categories.Add(category);
            EditCategoryForm form = new EditCategoryForm(category);
            form.Show();
        }

        private void SetDataBindings()
        {
            this.View.InitalizeDataBinding(this.data);
        }
    }
}
