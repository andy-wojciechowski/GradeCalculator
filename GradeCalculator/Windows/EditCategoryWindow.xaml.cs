using GradeCalculator.DependencyResolution;
using GradeCalculator.Interfaces.Presenters;
using GradeCalculator.Interfaces.Views;
using GradeCalculator.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GradeCalculator.Windows
{
    /// <summary>
    /// Interaction logic for EditCategoryForm.xaml
    /// </summary>
    public partial class EditCategoryWindow : Window, IEditCategoryView
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

        public void InitializeDataBinding(Binding nameBinding, Binding worthBinding)
        {
            //Set the 2 bindings
            BindingOperations.SetBinding(nameTextBox, TextBox.TextProperty, nameBinding);
            BindingOperations.SetBinding(worthTextBox, TextBox.TextProperty, worthBinding);
        }
    }
}
