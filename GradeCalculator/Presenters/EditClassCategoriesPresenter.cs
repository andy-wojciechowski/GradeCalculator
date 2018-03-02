using GradeCalculator.DependencyResolution;
using GradeCalculator.Model;
using GradeCalculator.Windows;
using GradeCalculator.Interfaces.Presenters;
using GradeCalculator.Interfaces.Views;
using System.Windows.Data;
using System.Windows;

namespace GradeCalculator.Presenters
{
    public class EditClassCategoriesPresenter : IEditClassCategoriesPresenter
    {
        private IEditClassCategoriesView View { get; set; }
        private SchoolClass Data { get; set; }

        public void UpdateAssignment()
        {
            if (this.View.AssignmentsGrid.SelectedIndex == -1) { this.View.AssignmentsGrid.SelectedIndex = 0; }
            Assignment assignment = (Assignment)this.View.AssignmentsGrid.SelectedItem;

            IEditAssignmentsView view = new EditAssignmentsWindow(false);
            using (var container = ObjectFactory.GetContainer())
            {
                var presenter = container.GetInstance<IEditAssignmentPresenter>();
                view.SetPresenter(presenter);
                presenter.SetView(view);
                presenter.SetGradeCategories(((SchoolClassCategories)Data).Categories);
                presenter.SetAssignment(assignment);
                presenter.SetDataBindings();
            }
            view.ShowWindow();
        }

        public void AddAssignment()
        {
            Assignment newAssignment = new Assignment() { Name = string.Empty, Category = null, TotalPointsEarned = 0D, TotalPossiblePoints = 0D };
            this.Data.Assignments.Add(newAssignment);
            IEditAssignmentsView view = new EditAssignmentsWindow(false);
            using (var container = ObjectFactory.GetContainer())
            {
                var presenter = container.GetInstance<IEditAssignmentPresenter>();
                view.SetPresenter(presenter);
                presenter.SetView(view);
                presenter.SetGradeCategories(((SchoolClassCategories)Data).Categories);
                presenter.SetAssignment(newAssignment);
                presenter.SetDataBindings();
            }
            view.ShowWindow();
        }

        public void UpdateCategory()
        {
            if (this.View.CategoryGrid.SelectedIndex == -1) { this.View.CategoryGrid.SelectedIndex = 0; }
            GradeCategory category = (GradeCategory)this.View.CategoryGrid.SelectedItem;

            IEditCategoryView view = new EditCategoryWindow();
            using (var container = ObjectFactory.GetContainer())
            {
                var presenter = container.GetInstance<IEditCategoryPresenter>();
                view.SetPresenter(presenter);
                presenter.SetView(view);
                presenter.SetCategory(category);
                presenter.SetDataBindings();
            }
            view.ShowWindow();
        }

        public void AddCategory()
        {
            GradeCategory category = new GradeCategory() { Name = string.Empty, CategoryWeight = 0D };
            ((SchoolClassCategories)this.Data).Categories.Add(category);
            IEditCategoryView view = new EditCategoryWindow();
            using (var container = ObjectFactory.GetContainer())
            {
                var presenter = container.GetInstance<IEditCategoryPresenter>();
                view.SetPresenter(presenter);
                presenter.SetView(view);
                presenter.SetCategory(category);
                presenter.SetDataBindings();
            }
            view.ShowWindow();
        }

        public void SetDataBindings()
        {
            //Grade Categories
            this.View.CategoryGrid.ItemsSource = ((SchoolClassCategories)this.Data).Categories;

            //Assignments
            this.View.AssignmentsGrid.ItemsSource = this.Data.Assignments;

            //Name Property
            Binding nameBinding = new Binding();
            nameBinding.Source = Data;
            nameBinding.Path = new PropertyPath("Name");
            nameBinding.Mode = BindingMode.TwoWay;
            nameBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            this.View.InitializeDataBinding(nameBinding);
        }

        public void SetView(IEditClassCategoriesView view)
        {
            this.View = view;
        }

        public void SetClass(SchoolClass model)
        {
            this.Data = model;
        }
    }
}
