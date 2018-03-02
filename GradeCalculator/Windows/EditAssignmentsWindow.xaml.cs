using GradeCalculator.Interfaces.Presenters;
using GradeCalculator.Interfaces.Views;
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

        public EditAssignmentsWindow(bool noCategories)
        {
            InitializeComponent();
            if(noCategories) { this.categoryCombobox.IsEnabled = false; }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.presenter.CloseView();
        }

        public void InitializeDataBinding(Binding nameBinding, Binding categoryBinding, Binding totalPointsEarnedBinding, Binding totalPossiblePointsBinding)
        {
            //Set all the data bindings
            BindingOperations.SetBinding(nameTextBox, TextBox.TextProperty, nameBinding);
            BindingOperations.SetBinding(categoryCombobox, ComboBox.SelectedItemProperty, categoryBinding);
            BindingOperations.SetBinding(totalPointsEarnedTextBox, TextBox.TextProperty, totalPointsEarnedBinding);
            BindingOperations.SetBinding(totalPointsPossibleTextBox, TextBox.TextProperty, totalPossiblePointsBinding);
        }

        public void SetPresenter(IEditAssignmentPresenter presenter)
        {
            this.presenter = presenter;
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
