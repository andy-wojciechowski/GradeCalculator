using GradeCalculator.DependencyResolution;
using GradeCalculator.Interfaces.Presenters;
using GradeCalculator.Interfaces.Views;
using GradeCalculator.Model;
using GradeCalculator.Windows;
using System.Windows;
using System.Windows.Data;

namespace GradeCalculator.Presenters
{
    public class EditClassPointsPresenter : IEditClassPointsPresenter
    {
        private IEditClassPointsView view { get; set; }
        private SchoolClass data { get; set; }

        public void AddAssignment()
        {
            Assignment newAssignment = new Assignment() { Name = string.Empty, Category = null, TotalPointsEarned = 0D, TotalPossiblePoints = 0D };
            this.data.Assignments.Add(newAssignment);
            IEditAssignmentsView view = new EditAssignmentsWindow(true);
            using (var container = ObjectFactory.GetContainer())
            {
                var presenter = container.GetInstance<IEditAssignmentPresenter>();
                view.SetPresenter(presenter);
                presenter.SetView(view);
                presenter.SetGradeCategories(new System.Collections.ObjectModel.ObservableCollection<GradeCategory>());
                presenter.SetAssignment(newAssignment);
                presenter.SetDataBindings();
            }
            view.ShowWindow();
        }

        public void SetClass(SchoolClass model)
        {
            this.data = model;
        }

        public void SetDataBindings()
        {
            //Assignments
            this.view.AssignmentsDataGrid.ItemsSource = this.data.Assignments;

            //Name Property
            Binding nameBinding = new Binding();
            nameBinding.Source = data;
            nameBinding.Path = new PropertyPath("Name");
            nameBinding.Mode = BindingMode.TwoWay;
            nameBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            this.view.InitializeDataBinding(nameBinding);
        }

        public void SetView(IEditClassPointsView view)
        {
            this.view = view;
        }

        public void UpdateAssignment()
        {
            if (this.view.AssignmentsDataGrid.SelectedIndex == -1) { this.view.AssignmentsDataGrid.SelectedIndex = 0; }
            Assignment assignment = (Assignment)this.view.AssignmentsDataGrid.SelectedItem;

            IEditAssignmentsView view = new EditAssignmentsWindow(true);
            using (var container = ObjectFactory.GetContainer())
            {
                var presenter = container.GetInstance<IEditAssignmentPresenter>();
                view.SetPresenter(presenter);
                presenter.SetView(view);
                presenter.SetGradeCategories(new System.Collections.ObjectModel.ObservableCollection<GradeCategory>());
                presenter.SetAssignment(assignment);
                presenter.SetDataBindings();
            }
            view.ShowWindow();
        }
    }
}
