using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace WpfPPHELP
{
    public partial class MainWindow : Window
    {
        private PageDS currentPageDS;
        private PageEF currentPageEF;
        string selectedPage;
        string selectedTable = "";
        List<string> tableNames = new List<string>() { "Цвет", "Карандаши", "Завод карандашей", "Размер", "Объединенная таблица" };
        public MainWindow()
        {
            InitializeComponent();
            ComboBoxChangeTable.ItemsSource = tableNames;
        }
        private void PagePreviouseEF_Click(object sender, RoutedEventArgs e)
        {
            selectedPage = "EntityFramework";
            NavigateToPageEF(selectedTable);
        }
        private void PagePreviousDS_Click(object sender, RoutedEventArgs e)
        {
            selectedPage = "DataSet";
            NavigateToPageDS(selectedTable);
        }

        private void ComboBoxChangeTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTable = ComboBoxChangeTable.Items[ComboBoxChangeTable.SelectedIndex] as string;
            if (selectedTable == "Объединенная таблица")
            {
            }
            else
            {
            }
            if (selectedPage == "DataSet")
            {
                NavigateToPageDS(selectedTable);
            }
            else if (selectedPage == "EntityFramework")
            {
                NavigateToPageEF(selectedTable);
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPage == "DataSet")
            {
                currentPageDS.AddNewData();
            }
            else if (selectedPage == "EntityFramework")
            {
                currentPageEF.AddNewData();
            }
        }
        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPage == "DataSet")
            {
                if (currentPageDS != null)
                {
                    currentPageDS?.SaveChangesWithButton();
                }
            }
            else if (selectedPage == "EntityFramework")
            {
                if (currentPageEF != null)
                {
                    currentPageEF?.SaveChangesWithButton();
                }
            }
        }
        private void DeleteDataButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPage == "DataSet")
            {
                if (currentPageDS != null)
                {
                    currentPageDS?.DeleteWithButton();
                }
            }
            else if (selectedPage == "EntityFramework")
            {
                if (currentPageEF != null)
                {
                    currentPageEF?.DeleteWithButton();
                }
            }
        }
        private void NavigateToPageDS(string selectedTable)
        {
            currentPageDS = new PageDS(selectedTable);
            PageFrame.Content = currentPageDS;
        }
        private void NavigateToPageEF(string selectedTable)
        {
            currentPageEF = new PageEF(selectedTable);
            PageFrame.Content = currentPageEF;
        }
    }
}