using GradeCalculator.Model;
using GradeCalculator.Presenters;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GradeCalculator.Windows
{
    /// <summary>
    /// Interaction logic for EditCategoryForm.xaml
    /// </summary>
    public partial class EditCategoryForm : Window
    {
        private EditCategoryPresenter presenter { get; set; }
        public EditCategoryForm(GradeCategory category)
        {
            InitializeComponent();
            this.presenter = new EditCategoryPresenter(this, category);
            this.presenter.InitializeDataBinding();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Figure out if the object in edit class form will need to be updated
            this.Close();
        }

        public void InitializeDataBinding(GradeCategory category)
        {
            //Name Property
            Binding binding1 = new Binding();
            binding1.Source = category;
            binding1.Path = new PropertyPath("Name");
            binding1.Mode = BindingMode.TwoWay;
            binding1.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            //Worth Property
            Binding binding2 = new Binding();
            binding2.Source = category;
            binding2.Path = new PropertyPath("CategoryWorth");
            binding2.Mode = BindingMode.TwoWay;
            binding2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            //Set the 2 bindings
            BindingOperations.SetBinding(nameTextBox, TextBox.TextProperty, binding1);
            BindingOperations.SetBinding(worthTextBox, TextBox.TextProperty, binding2);
        }
    }
}
