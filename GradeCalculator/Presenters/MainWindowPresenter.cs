﻿using GradeCalculator.DependencyResolution;
using GradeCalculator.Interfaces.Presenters;
using GradeCalculator.Interfaces.Views;
using GradeCalculator.Model;
using GradeCalculator.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GradeCalculator.Presenters
{
    public class MainWindowPresenter : IMainWindowPresenter
    {
        private IMainWindowView View { get; set; }
        private ObservableCollection<SchoolClass> Classes { get; set; }

        public void GenerateExcelReport(string directoryPath)
        {
            GradeReport report = new GradeReport(Classes.ToList());
            report.GenerateReport(directoryPath);
        }

        public void ReadExistingData()
        {
            this.Classes = new ObservableCollection<SchoolClass>(App.ReadFromXml());
            this.View.ClassesGrid.ItemsSource = this.Classes;
        }

        public void UpdateClass()
        {
            if (this.View.ClassesGrid.SelectedIndex == -1) { this.View.ClassesGrid.SelectedIndex = 0; }
            var classToUpdate = (SchoolClass)this.View.ClassesGrid.SelectedItem;

            if (classToUpdate is SchoolClassCategories)
            {
                IEditClassCategoriesView view = new EditClassCategoriesWindow();
                using (var container = ObjectFactory.GetContainer())
                {
                    var presenter = container.GetInstance<IEditClassCategoriesPresenter>();
                    view.SetPresenter(presenter);
                    presenter.SetView(view);
                    presenter.SetClass(classToUpdate);
                    presenter.SetDataBindings();
                }
                view.ShowWindow();
            }
            else
            {
                IEditClassPointsView view = new EditClassPointsWindow();
                using (var container = ObjectFactory.GetContainer())
                {
                    var presenter = container.GetInstance<IEditClassPointsPresenter>();
                    view.SetPresenter(presenter);
                    presenter.SetView(view);
                    presenter.SetClass(classToUpdate);
                    presenter.SetDataBindings();
                }
                view.ShowWindow();
            }
        }

        public void NewClassWithCategories()
        {
            SchoolClass newClass = new SchoolClassCategories() { Name = string.Empty, Assignments = new ObservableCollection<Assignment>(), Categories = new ObservableCollection<GradeCategory>() };
            this.Classes.Add(newClass);
            IEditClassCategoriesView view = new EditClassCategoriesWindow();
            using (var container = ObjectFactory.GetContainer())
            {
                var presenter = container.GetInstance<IEditClassCategoriesPresenter>();
                view.SetPresenter(presenter);
                presenter.SetView(view);
                presenter.SetClass(newClass);
                presenter.SetDataBindings();
            }
            view.ShowWindow();
        }

        public void NewClassWithNoCategories()
        {
            SchoolClass newClass = new SchoolClassPoints() { Name = string.Empty, Assignments = new ObservableCollection<Assignment>() };
            this.Classes.Add(newClass);
            IEditClassPointsView view = new EditClassPointsWindow();
            using (var container = ObjectFactory.GetContainer())
            {
                var presenter = container.GetInstance<IEditClassPointsPresenter>();
                view.SetPresenter(presenter);
                presenter.SetView(view);
                presenter.SetClass(newClass);
                presenter.SetDataBindings();
            }
            view.ShowWindow();
        }

        public void SetView(IMainWindowView view)
        {
            this.View = view;
        }

        public void WriteToXML()
        {
            App.WriteToXml(new List<SchoolClass>(this.Classes));
        }
    }
}
