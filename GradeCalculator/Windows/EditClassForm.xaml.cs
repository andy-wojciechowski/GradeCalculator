using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GradeCalculator.Model;
using GradeCalculator.Presenters;

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
            throw new NotImplementedException();
        }

        private void addAssignmentButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void editCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void addCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
