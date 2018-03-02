using GradeCalculator.Interfaces.Presenters;
using GradeCalculator.Interfaces.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GradeCalculator.Windows
{
    /// <summary>
    /// Interaction logic for EditClassFormxaml.xaml
    /// </summary>
    public partial class EditClassCategoriesWindow : Window, IEditClassCategoriesView
    {
        private IEditClassCategoriesPresenter Presenter { get; set; }

        public DataGrid CategoryGrid => this.categoryGrid;

        public DataGrid AssignmentsGrid => this.assignmentsDataGrid;

        public EditClassCategoriesWindow()
        {
            InitializeComponent();
        }

        public void InitializeDataBinding(Binding nameBinding)
        {
            BindingOperations.SetBinding(nameTextBox, TextBox.TextProperty, nameBinding);
        }

        public void SetPresenter(IEditClassCategoriesPresenter presenter)
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
                this.Presenter.UpdateAssignment();
            }
        }


        private void addAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.AddAssignment();
        }

        private void editCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.categoryGrid.Items.Count == 0)
            {
                MessageBox.Show("There are no categories to edit. ", "Grade Calculator", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                this.Presenter.UpdateCategory();
            }
        }

        private void addCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.AddCategory();
        }

        private void editClassForm_Loaded(object sender, RoutedEventArgs e)
        {
            //HIde all unecessary columns from both datagrids
            for (int i = 0; i < this.categoryGrid.Columns.Count; i++)
            {
                //This is for simplicity so the VisualTreeHelper does not have to get involved 
                //hide all columns with the index greater than 0
                if (i != 0)
                {
                    this.categoryGrid.Columns[i].Visibility = Visibility.Hidden;
                }
            }

            for (int i = 0; i < this.assignmentsDataGrid.Columns.Count; i++)
            {
                //This is for simplicity so the VisualTreeHelper does not have to get involved 
                //hide all columns with the index greater than 0
                if (i != 0)
                {
                    this.assignmentsDataGrid.Columns[i].Visibility = Visibility.Hidden;
                }
            }

            this.categoryGrid.Columns[0].Width = new DataGridLength(0.01, DataGridLengthUnitType.Star);
            this.assignmentsDataGrid.Columns[0].Width = new DataGridLength(0.01, DataGridLengthUnitType.Star);
        }

        public void ShowWindow()
        {
            this.Show();
        }
    }
}
