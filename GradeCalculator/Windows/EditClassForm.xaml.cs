using GradeCalculator.Model;
using GradeCalculator.Presenters;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GradeCalculator.Windows
{
    /// <summary>
    /// Interaction logic for EditClassFormxaml.xaml
    /// </summary>
    public partial class EditClassForm : Window
    {
        private EditClassPresenter presenter { get; set; }

        public EditClassForm(SchoolClass data)
        {
            InitializeComponent();
            this.presenter = new EditClassPresenter(this, data);
        }

        public void InitalizeDataBinding(SchoolClass data)
        {
            //Name Property
            Binding binding = new Binding();
            binding.Source = data;
            binding.Path = new PropertyPath("Name");
            binding.Mode = BindingMode.TwoWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(nameTextBox, TextBox.TextProperty, binding);

            //Grade Categories
            this.categoryGrid.ItemsSource = data.Categories;

            //Assignments
            this.assignmentsDataGrid.ItemsSource = data.Assignments;
       }

        private void editAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.assignmentsDataGrid.Items.Count == 0)
            {
                MessageBox.Show("There are no assignments to edit. ", "Grade Calculator", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if (this.assignmentsDataGrid.SelectedIndex == -1) { this.assignmentsDataGrid.SelectedIndex = 0;  }
                Assignment selectedAssignment = (Assignment)this.assignmentsDataGrid.SelectedItem;
                this.presenter.UpdateAssignment(selectedAssignment);
            }
        }


        private void addAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            this.presenter.AddAssignment();
        }

        private void editCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.categoryGrid.Items.Count == 0)
            {
                MessageBox.Show("There are no categories to edit. ", "Grade Calculator", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if (this.categoryGrid.SelectedIndex == -1) { this.categoryGrid.SelectedIndex = 0; }
                GradeCategory selectedCategory = (GradeCategory)this.categoryGrid.SelectedItem;
                this.presenter.UpdateCategory(selectedCategory);
            }
        }

        private void addCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            this.presenter.AddCategory();
        }
    }
}
