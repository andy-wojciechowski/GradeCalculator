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
        private IEditClassPointsView View { get; set; }
        private SchoolClass Data { get; set; }

        public void AddAssignment()
        {
            Assignment newAssignment = new Assignment() { Name = string.Empty, Category = null, TotalPointsEarned = 0D, TotalPossiblePoints = 0D };
            this.Data.Assignments.Add(newAssignment);
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
            this.Data = model;
        }

        public void SetDataBindings()
        {
            //Assignments
            this.View.AssignmentsDataGrid.ItemsSource = this.Data.Assignments;

            //Name Property
            Binding nameBinding = new Binding();
            nameBinding.Source = Data;
            nameBinding.Path = new PropertyPath("Name");
            nameBinding.Mode = BindingMode.TwoWay;
            nameBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            this.View.InitializeDataBinding(nameBinding);
        }

        public void SetView(IEditClassPointsView view)
        {
            this.View = view;
        }

        public void UpdateAssignment()
        {
            if (this.View.AssignmentsDataGrid.SelectedIndex == -1) { this.View.AssignmentsDataGrid.SelectedIndex = 0; }
            Assignment assignment = (Assignment)this.View.AssignmentsDataGrid.SelectedItem;

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
