using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GradeCalculator
{
    public class MainFormPresenter : BasePresenter<MainForm>
    {
        public MainFormPresenter(MainForm form) : base(form) { }

        public void GenerateExcelReport(ObservableCollection<SchoolClass> classes)
        {
            GradeReport report = new GradeReport(classes.ToList());
            //TODO: Prompt the user for an actual directory
            report.GenerateReport("C:\\temp");
        }

        public void ReadExistingData()
        {
            ObservableCollection<SchoolClass> classes = new ObservableCollection<SchoolClass>(App.ReadFromXml());
            this.View.SetClassBindings(classes);
        }

        public void UpdateClass(SchoolClass classToUpdate)
        {
            EditClassForm form = new EditClassForm(classToUpdate);
            form.Show();
        }

        public void NewClass()
        {
            SchoolClass newClass = new SchoolClass() { Name = string.Empty, Assignments = new List<Assignment>(), Categories = new List<GradeCategory>() };
            this.View.UpateObservableCollection(newClass);
            EditClassForm form = new EditClassForm(newClass);
            form.Show();
        }

    }
}
