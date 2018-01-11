using GradeCalculator.Model;
using GradeCalculator.Windows;
using GradeCalculator.Interfaces.Presenters;
using GradeCalculator.Interfaces.Views;
using System.Windows.Data;
using System.Windows;

namespace GradeCalculator.Presenters
{
    public class EditClassPresenter : IEditClassPresenter
    {
        private IEditClassView view { get; set; }
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
            var window = this.view as EditClassWindow;
            if(window != null)
            {
                //Grade Categories
                window.categoryGrid.ItemsSource = this.data.Categories;

                //Assignments
                window.assignmentsDataGrid.ItemsSource = this.data.Assignments;

                //Name Property
                Binding nameBinding = new Binding();
                nameBinding.Source = data;
                nameBinding.Path = new PropertyPath("Name");
                nameBinding.Mode = BindingMode.TwoWay;
                nameBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                this.view.InitializeDataBinding(nameBinding);
            }
        }

        public void SetView(IEditClassView view)
        {
            this.view = view;
        }

        public void SetClass(SchoolClass model)
        {
            this.data = model;
        }
    }
}
