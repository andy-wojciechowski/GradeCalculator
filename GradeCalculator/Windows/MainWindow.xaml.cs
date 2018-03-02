using GradeCalculator.DependencyResolution;
using GradeCalculator.Interfaces.Presenters;
using GradeCalculator.Interfaces.Views;
using System.Windows;
using System.Windows.Controls;
using WinForms = System.Windows.Forms;

namespace GradeCalculator.Windows
{
    /// <summary>
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindowView
    {
        private IMainWindowPresenter Presenter { get; set; }

        public DataGrid ClassesGrid => this.classGrid;

        public MainWindow()
        {
            InitializeComponent();
            this.Initialize();
        }

        public void Initialize()
        {
            using (var container = ObjectFactory.GetContainer())
            {
                this.Presenter = container.GetInstance<IMainWindowPresenter>();
            }
            this.Presenter.SetView(this);
            this.Presenter.ReadExistingData();
        }

        private void generateExcelButton_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new WinForms.FolderBrowserDialog();
            var result = fileDialog.ShowDialog();
            string directoryPath = null;
            if(result == WinForms.DialogResult.OK)
            {
                directoryPath = fileDialog.SelectedPath;
            }

            this.Presenter.GenerateExcelReport(directoryPath);
        }

        private void editClassMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(this.classGrid.Items.Count == 0)
            {
                MessageBox.Show("There are no classes to edit.", "Grade Calculator", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                this.Presenter.UpdateClass();
            }
        }

        private void addClassCategoriesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.NewClassWithCategories();
        }

        private void addClassPointsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.NewClassWithNoCategories();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Presenter.WriteToXML();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Hide unnecessary columns
            for (int i = 0; i < this.classGrid.Columns.Count; i++)
            {
                //This is for simplicity so the VisualTreeHelper does not have to get involved 
                //hide all columns with the index greater than 0
                if (i != 0)
                {
                    this.classGrid.Columns[i].Visibility = Visibility.Hidden;
                }
            }

            this.classGrid.Columns[0].Width = new DataGridLength(0.01, DataGridLengthUnitType.Star);
        }
    }
}
