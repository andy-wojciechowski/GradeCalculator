using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using GradeCalculator.Model;
using GradeCalculator.Presenters;
using System.Windows.Controls;

namespace GradeCalculator.Windows
{
    /// <summary>
    /// Interaction logic for MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        private MainFormPresenter presenter { get; set; }
        private ObservableCollection<SchoolClass> classes { get; set;}

        public MainForm()
        {
            InitializeComponent();
            this.presenter = new MainFormPresenter(this);
            this.presenter.ReadExistingData();
        }

        private void generateExcelButton_Click(object sender, RoutedEventArgs e)
        {
            this.presenter.GenerateExcelReport(classes);
        }

        public void SetClassBindings(ObservableCollection<SchoolClass> collection)
        {
            this.classes = collection;
            this.classGrid.ItemsSource = this.classes;
        }

        private void editClassMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(this.classGrid.Items.Count == 0)
            {
                MessageBox.Show("There are no classes to edit.", "Grade Calculator", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if(this.classGrid.SelectedIndex == -1) { this.classGrid.SelectedIndex = 0; }
                var schoolClass = (SchoolClass)this.classGrid.SelectedItem;
                this.presenter.UpdateClass(schoolClass);
            }
        }

        private void addClassMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.presenter.NewClass();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.WriteToXml(new List<SchoolClass>(this.classes));
        }

        public void UpdateObservableCollection(SchoolClass classToAdd)
        {
            this.classes.Add(classToAdd);
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
        }
    }
}
