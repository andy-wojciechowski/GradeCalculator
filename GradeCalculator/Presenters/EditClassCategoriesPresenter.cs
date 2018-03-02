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
        private IEditClassCategoriesView view { get; set; }
        private SchoolClass data { get; set; }

        public void UpdateAssignment(Assignment assignment)
        {
            IEditAssignmentsView view = new EditAssignmentsWindow(false);
            using (var container = ObjectFactory.GetContainer())
            {
                var presenter = container.GetInstance<IEditAssignmentPresenter>();
                view.SetPresenter(presenter);
                presenter.SetView(view);
                presenter.SetGradeCategories(((SchoolClassCategories)data).Categories);
                presenter.SetAssignment(assignment);
                presenter.SetDataBindings();
            }
            view.ShowWindow();
        }

        public void AddAssignment()
        {
            Assignment newAssignment = new Assignment() { Name = string.Empty, Category = null, TotalPointsEarned = 0D, TotalPossiblePoints = 0D };
            this.data.Assignments.Add(newAssignment);
            IEditAssignmentsView view = new EditAssignmentsWindow(false);
            using (var container = ObjectFactory.GetContainer())
            {
                var presenter = container.GetInstance<IEditAssignmentPresenter>();
                view.SetPresenter(presenter);
                presenter.SetView(view);
                presenter.SetGradeCategories(((SchoolClassCategories)data).Categories);
                presenter.SetAssignment(newAssignment);
                presenter.SetDataBindings();
            }
            view.ShowWindow();
        }

        public void UpdateCategory(GradeCategory category)
        {
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
            ((SchoolClassCategories)this.data).Categories.Add(category);
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
            var window = this.view as EditClassCategoriesWindow;
            if(window != null)
            {
                //Grade Categories
                window.categoryGrid.ItemsSource = ((SchoolClassCategories)this.data).Categories;

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

        public void SetView(IEditClassCategoriesView view)
        {
            this.view = view;
        }

        public void SetClass(SchoolClass model)
        {
            this.data = model;
        }
    }
}
