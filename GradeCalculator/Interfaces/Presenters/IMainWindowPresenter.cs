using GradeCalculator.Model;
using GradeCalculator.Windows;
using System.Collections.ObjectModel;

namespace GradeCalculator.Interfaces.Presenters
{
    public interface IMainWindowPresenter
    {
        void SetView(MainWindow view);
        void GenerateExcelReport(ObservableCollection<SchoolClass> classes, string directoryPath);
        void ReadExistingData();
        void UpdateClass(SchoolClass classToUpdate);
        void NewClass();
    }
}
