using GradeCalculator.Interfaces.Views;
using GradeCalculator.Model;

namespace GradeCalculator.Interfaces.Presenters
{
    public interface IMainWindowPresenter
    {
        void SetView(IMainWindowView view);
        void GenerateExcelReport(string directoryPath);
        void ReadExistingData();
        void UpdateClass(SchoolClass classToUpdate);
        void NewClass();
        void WriteToXML();
    }
}
