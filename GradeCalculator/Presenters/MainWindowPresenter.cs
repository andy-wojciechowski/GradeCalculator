using GradeCalculator.Interfaces.Presenters;
using GradeCalculator.Model;
using GradeCalculator.Windows;
using System.Collections.ObjectModel;
using System.Linq;

namespace GradeCalculator.Presenters
{
    public class MainWindowPresenter : IMainWindowPresenter
    {
        private MainWindow View { get; set; }

        public void GenerateExcelReport(ObservableCollection<SchoolClass> classes, string directoryPath)
        {
            GradeReport report = new GradeReport(classes.ToList());
            report.GenerateReport(directoryPath);
        }

        public void ReadExistingData()
        {
            ObservableCollection<SchoolClass> classes = new ObservableCollection<SchoolClass>(App.ReadFromXml());
            this.View.SetClassBindings(classes);
        }

        public void UpdateClass(SchoolClass classToUpdate)
        {
            EditClassWindow form = new EditClassWindow(classToUpdate);
            form.Show();
        }

        public void NewClass()
        {
            SchoolClass newClass = new SchoolClass() { Name = string.Empty, Assignments = new ObservableCollection<Assignment>(), Categories = new ObservableCollection<GradeCategory>() };
            this.View.UpdateObservableCollection(newClass);
            EditClassWindow form = new EditClassWindow(newClass);
            form.Show();
        }

        public void SetView(MainWindow view)
        {
            this.View = view;
        }
    }
}
