using GradeCalculator.DependencyResolution;
using GradeCalculator.Interfaces.Presenters;
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
    public partial class EditAssignmentsWindow : Window
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

        //TODO: Move this to the EditAssignmentPresenter
        public void InitializeDataBinding(Assignment assignment, ObservableCollection<GradeCategory> categories)
        {
            //First bind the readonly combobox
            this.categoryCombobox.ItemsSource = categories;
            this.categoryCombobox.DisplayMemberPath = "Name";

            //Name Property
            Binding binding1 = new Binding();
            binding1.Source = assignment;
            binding1.Path = new PropertyPath("Name");
            binding1.Mode = BindingMode.TwoWay;
            binding1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            //Category property
            Binding binding2 = new Binding();
            binding2.Source = assignment;
            binding2.Path = new PropertyPath("Category");
            binding2.Mode = BindingMode.TwoWay;
            binding2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            //TotalPointsEarned property
            Binding binding3 = new Binding();
            binding3.Source = assignment;
            binding3.Path = new PropertyPath("TotalPointsEarned");
            binding3.Mode = BindingMode.TwoWay;
            binding3.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            //TotalPossiblePoints property
            Binding binding4 = new Binding();
            binding4.Source = assignment;
            binding4.Path = new PropertyPath("TotalPossiblePoints");
            binding4.Mode = BindingMode.TwoWay;
            binding4.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            //Set all the data bindings
            BindingOperations.SetBinding(nameTextBox, TextBox.TextProperty, binding1);
            BindingOperations.SetBinding(categoryCombobox, ComboBox.SelectedItemProperty, binding2);
            BindingOperations.SetBinding(totalPointsEarnedTextBox, TextBox.TextProperty, binding3);
            BindingOperations.SetBinding(totalPointsPossibleTextBox, TextBox.TextProperty, binding4);
        }
    }
}
