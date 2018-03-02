using GradeCalculator.Interfaces.Presenters;
using GradeCalculator.Interfaces.Views;
using GradeCalculator.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GradeCalculator.Windows
{
    /// <summary>
    /// Interaction logic for EditClassPointsWindow.xaml
    /// </summary>
    public partial class EditClassPointsWindow : Window, IEditClassPointsView
    {
        private IEditClassPointsPresenter Presenter { get; set; }

        public EditClassPointsWindow()
        {
            InitializeComponent();
        }

        public void InitializeDataBinding(Binding nameBinding)
        {
            BindingOperations.SetBinding(nameTextBox, TextBox.TextProperty, nameBinding);
        }

        public void SetPresenter(IEditClassPointsPresenter presenter)
        {
            this.Presenter = presenter;
        }

        private void editAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.assignmentsDataGrid.Items.Count == 0)
            {
                MessageBox.Show("There are no assignments to edit. ", "Grade Calculator", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if (this.assignmentsDataGrid.SelectedIndex == -1) { this.assignmentsDataGrid.SelectedIndex = 0; }
                Assignment selectedAssignment = (Assignment)this.assignmentsDataGrid.SelectedItem;
                this.Presenter.UpdateAssignment(selectedAssignment);
            }
        }


        private void addAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.AddAssignment();
        }

        private void editClassPointsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //HIde all unecessary columns from the assignments datagrid
            for (int i = 0; i < this.assignmentsDataGrid.Columns.Count; i++)
            {
                //This is for simplicity so the VisualTreeHelper does not have to get involved 
                //hide all columns with the index greater than 0
                if (i != 0)
                {
                    this.assignmentsDataGrid.Columns[i].Visibility = Visibility.Hidden;
                }
            }

            this.assignmentsDataGrid.Columns[0].Width = new DataGridLength(0.01, DataGridLengthUnitType.Star);
        }

        public void ShowWindow()
        {
            this.Show();
        }
    }
}
