using GradeCalculator.Interfaces.Presenters;
using GradeCalculator.Interfaces.Views;
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
        private IEditCategoryPresenter Presenter { get; set; }
        public EditCategoryWindow()
        {
            InitializeComponent();
        }

        public void SetPresenter(IEditCategoryPresenter presenter)
        {
            this.Presenter = presenter;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.CloseView();
        }

        public void InitializeDataBinding(Binding nameBinding, Binding worthBinding)
        {
            //Set the 2 bindings
            BindingOperations.SetBinding(nameTextBox, TextBox.TextProperty, nameBinding);
            BindingOperations.SetBinding(worthTextBox, TextBox.TextProperty, worthBinding);
        }

        public void ShowWindow()
        {
            this.Show();
        }

        public void CloseWindow()
        {
            this.Close();
        }
    }
}
