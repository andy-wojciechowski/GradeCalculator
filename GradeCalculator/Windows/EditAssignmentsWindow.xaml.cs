using GradeCalculator.DependencyResolution;
using GradeCalculator.Interfaces.Presenters;
using GradeCalculator.Interfaces.Views;
using GradeCalculator.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GradeCalculator.Windows
{
    /// <summary>
    /// Interaction logic for EditAssignmentsForm.xaml
    /// </summary>
    public partial class EditAssignmentsWindow : Window, IEditAssignmentsView
    {
        private IEditAssignmentPresenter presenter { get; set; }

        public EditAssignmentsWindow(Assignment assignment, ObservableCollection<GradeCategory> categories)
        {
            InitializeComponent();
            using (var container = ObjectFactory.GetContainer())
            {
                this.presenter = container.GetInstance<IEditAssignmentPresenter>();
            }
            this.presenter.SetView(this);
            this.presenter.SetGradeCategories(categories);
            this.presenter.SetAssignment(assignment);
            this.presenter.SetDataBindings();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void InitializeDataBinding(Binding nameBinding, Binding categoryBinding, Binding totalPointsEarnedBinding, Binding totalPossiblePointsBinding)
        {
            //Set all the data bindings
            BindingOperations.SetBinding(nameTextBox, TextBox.TextProperty, nameBinding);
            BindingOperations.SetBinding(categoryCombobox, ComboBox.SelectedIndexProperty, categoryBinding);
            BindingOperations.SetBinding(totalPointsEarnedTextBox, TextBox.TextProperty, totalPointsEarnedBinding);
            BindingOperations.SetBinding(totalPointsPossibleTextBox, TextBox.TextProperty, totalPossiblePointsBinding);
        }
    }
}
