using GradeCalculator.DependencyResolution;
using GradeCalculator.Interfaces.Presenters;
using GradeCalculator.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GradeCalculator.Windows
{
    /// <summary>
    /// Interaction logic for EditCategoryForm.xaml
    /// </summary>
    public partial class EditCategoryWindow : Window
    {
        private IEditCategoryPresenter presenter { get; set; }
        public EditCategoryWindow(GradeCategory category)
        {
            InitializeComponent();
            using (var container = ObjectFactory.GetContainer())
            {
                this.presenter = container.GetInstance<IEditCategoryPresenter>();
            }
            this.presenter.SetView(this);
            this.presenter.SetCategory(category);
            this.presenter.SetDataBindings();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //TODO: Move this to EditCategoryPresenter
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
            binding2.Path = new PropertyPath("CategoryWeight");
            binding2.Mode = BindingMode.TwoWay;
            binding2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            binding2.StringFormat = "D2";

            //Set the 2 bindings
            BindingOperations.SetBinding(nameTextBox, TextBox.TextProperty, binding1);
            BindingOperations.SetBinding(worthTextBox, TextBox.TextProperty, binding2);
        }
    }
}
