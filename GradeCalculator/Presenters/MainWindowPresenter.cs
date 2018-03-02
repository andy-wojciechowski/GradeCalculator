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
        private ObservableCollection<SchoolClass> classes { get; set; }

        public void GenerateExcelReport(string directoryPath)
        {
            GradeReport report = new GradeReport(classes.ToList());
            report.GenerateReport(directoryPath);
        }

        public void ReadExistingData()
        {
            this.classes = new ObservableCollection<SchoolClass>(App.ReadFromXml());
            this.View.ClassesGrid.ItemsSource = this.classes;
        }

        public void UpdateClass(SchoolClass classToUpdate)
        {
            if(classToUpdate is SchoolClassCategories)
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
            this.classes.Add(newClass);
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
            this.classes.Add(newClass);
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
            App.WriteToXml(new List<SchoolClass>(this.classes));
        }
    }
}
