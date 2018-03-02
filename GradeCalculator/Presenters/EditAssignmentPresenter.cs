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
        private IEditAssignmentsView View { get; set; }
        private ObservableCollection<GradeCategory> Categories { get; set; }
        private Assignment Data { get; set; }

        public void SetView(IEditAssignmentsView view)
        {
            this.View = view;
        }

        public void SetAssignment(Assignment assignment)
        {
            this.Data = assignment;
        }

        public void SetGradeCategories(ObservableCollection<GradeCategory> categories)
        {
            this.Categories = categories;
        }

        public void SetDataBindings()
        {
            //First bind the readonly combobox
            this.View.CategoryCombobox.ItemsSource = Categories;
            this.View.CategoryCombobox.DisplayMemberPath = "Name";

            //Name Property
            Binding nameBinding = new Binding();
            nameBinding.Source = this.Data;
            nameBinding.Path = new PropertyPath("Name");
            nameBinding.Mode = BindingMode.TwoWay;
            nameBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            //Category Property
            Binding categoryBinding = new Binding();
            categoryBinding.Source = this.Data;
            categoryBinding.Path = new PropertyPath("Category");
            categoryBinding.Mode = BindingMode.TwoWay;
            categoryBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            Binding totalPointsEarnedBinding = new Binding();
            totalPointsEarnedBinding.Source = this.Data;
            totalPointsEarnedBinding.Path = new PropertyPath("TotalPointsEarned");
            totalPointsEarnedBinding.Mode = BindingMode.TwoWay;
            totalPointsEarnedBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            Binding totalPossiblePointsBinding = new Binding();
            totalPossiblePointsBinding.Source = this.Data;
            totalPossiblePointsBinding.Path = new PropertyPath("TotalPossiblePoints");
            totalPossiblePointsBinding.Mode = BindingMode.TwoWay;
            totalPossiblePointsBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            this.View.InitializeDataBinding(nameBinding, categoryBinding, totalPointsEarnedBinding, totalPossiblePointsBinding);
        }

        public void CloseView()
        {
            this.View.CloseWindow();
        }
    }
}
