using GradeCalculator.Interfaces.Presenters;
using GradeCalculator.Interfaces.Views;
using GradeCalculator.Model;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows;

namespace GradeCalculator.Presenters
{
    public class EditAssignmentPresenter : IEditAssignmentPresenter
    {
        private IEditAssignmentsView view { get; set; }
        private ObservableCollection<GradeCategory> categories { get; set; }
        private Assignment data { get; set; }

        public void SetView(IEditAssignmentsView view)
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
            var window = this.view as Windows.EditAssignmentsWindow;
            if(window != null)
            {
                //First bind the readonly combobox
                window.categoryCombobox.ItemsSource = categories;
                window.categoryCombobox.DisplayMemberPath = "Name";

                //Name Property
                Binding nameBinding = new Binding();
                nameBinding.Source = this.data;
                nameBinding.Path = new PropertyPath("Name");
                nameBinding.Mode = BindingMode.TwoWay;
                nameBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

                //Category Property
                Binding categoryBinding = new Binding();
                categoryBinding.Source = this.data;
                categoryBinding.Path = new PropertyPath("Category");
                categoryBinding.Mode = BindingMode.TwoWay;
                categoryBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

                Binding totalPointsEarnedBinding = new Binding();
                totalPointsEarnedBinding.Source = this.data;
                totalPointsEarnedBinding.Path = new PropertyPath("TotalPointsEarned");
                totalPointsEarnedBinding.Mode = BindingMode.TwoWay;
                totalPointsEarnedBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

                Binding totalPossiblePointsBinding = new Binding();
                totalPossiblePointsBinding.Source = this.data;
                totalPossiblePointsBinding.Path = new PropertyPath("TotalPossiblePoints");
                totalPossiblePointsBinding.Mode = BindingMode.TwoWay;
                totalPossiblePointsBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

                this.view.InitializeDataBinding(nameBinding, categoryBinding, totalPointsEarnedBinding, totalPossiblePointsBinding);
            }
        }
    }
}
