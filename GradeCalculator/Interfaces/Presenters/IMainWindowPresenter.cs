using GradeCalculator.Interfaces.Views;

namespace GradeCalculator.Interfaces.Presenters
{
    public interface IMainWindowPresenter
    {
        void SetView(IMainWindowView view);
        void GenerateExcelReport(string directoryPath);
        void ReadExistingData();
        void UpdateClass();
        void NewClassWithCategories();
        void NewClassWithNoCategories();
        void WriteToXML();
    }
}
