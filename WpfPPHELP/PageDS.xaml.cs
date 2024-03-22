using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
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
using WpfPPHELP.BDPPDataSetTableAdapters;
using static WpfPPHELP.BDPPDataSet;

namespace WpfPPHELP
{

    public partial class PageDS : Page
    {
        ChvetTableAdapter colorTableAdapter = new ChvetTableAdapter();
        KarandashiTableAdapter KarandashiTableAdapter = new KarandashiTableAdapter();
        ZavodKarandasheyTableAdapter ZavodKarandasheyTableAdapter = new ZavodKarandasheyTableAdapter();
        RazmerTableAdapter sizeTableAdapter = new RazmerTableAdapter();
        KarandashiInventoryTableAdapter KarandashiInventoryTableAdapter = new KarandashiInventoryTableAdapter();
        KarandashiViewTableAdapter karandashiView = new KarandashiViewTableAdapter();
        RazmerViewTableAdapter sizeViewTableAdapter = new RazmerViewTableAdapter();
        ChvetViewTableAdapter colorViewTableAdapter = new ChvetViewTableAdapter();
        public string editedText = "";
        string nametable = "";
        int selectedKarandashiID;
        int selectedRazmerID;
        int selectedChvetID;

        public PageDS(string selectedTable)
        {
            InitializeComponent();
            if (selectedTable != "")
            {
                nametable = selectedTable;
                if (selectedTable == "Цвет")
                {
                    DataGridDS.ItemsSource = colorViewTableAdapter.GetData();
                    FilterComboBox.ItemsSource = colorTableAdapter.GetData();
                    FilterComboBox.DisplayMemberPath = "Chvet";
                }
                else if (selectedTable == "Карандаши")
                {
                    DataGridDS.ItemsSource = karandashiView.GetData();
                    FilterComboBox.ItemsSource = KarandashiTableAdapter.GetData();
                    FilterComboBox.DisplayMemberPath = "KarandashiType";
                }
                else if (selectedTable == "Завод карандашей")
                {
                    DataGridDS.ItemsSource = ZavodKarandasheyTableAdapter.GetData();
                    KardashyanTypeIDCMBX.ItemsSource = KarandashiTableAdapter.GetData();
                    KardashyanTypeIDCMBX.DisplayMemberPath = "KarandashiType";
                    ColorIDCMBX.ItemsSource = colorTableAdapter.GetData();
                    ColorIDCMBX.DisplayMemberPath = "Chvet";
                    SizeIDCMBX.ItemsSource = sizeTableAdapter.GetData();
                    SizeIDCMBX.DisplayMemberPath = "Razmer";
                    FilterComboBox.ItemsSource = KarandashiInventoryTableAdapter.GetData();
                    FilterComboBox.DisplayMemberPath = "Тип карандаша";
                }
                else if (selectedTable == "Размер")
                {
                    DataGridDS.ItemsSource = sizeViewTableAdapter.GetData();
                    FilterComboBox.ItemsSource = sizeTableAdapter.GetData();
                    FilterComboBox.DisplayMemberPath = "Razmer";
                }
                if (selectedTable == "Объединенная таблица")
                {
                    DataGridDS.ItemsSource = ZavodKarandasheyTableAdapter.GetData();
                }
            }

        }
        private void SaveChanges()
        {
            object id = (DataGridDS.SelectedItem as DataRowView).Row[0];
            if (nametable != "")
            {
                SearchCheckBox.IsChecked = false;
                if (nametable == "Завод карандашей")
                {
                    ZavodKarandasheyTableAdapter.UpdateQueryZavodKarandashey(selectedKarandashiID, selectedRazmerID, selectedChvetID, Convert.ToInt32(PriceTBX.Text), Convert.ToInt32(id));
                    DataGridDS.ItemsSource = ZavodKarandasheyTableAdapter.GetData();
                }
            }
        }
        public void AddNewData()
        {
            if (nametable != "")
            {
                SearchCheckBox.IsChecked = false;
                if (nametable == "Завод карандашей")
                {
                    ZavodKarandasheyTableAdapter.InsertQueryZavodKarandashey(selectedKarandashiID, selectedRazmerID, selectedChvetID, Convert.ToInt32(PriceTBX.Text));
                    DataGridDS.ItemsSource = ZavodKarandasheyTableAdapter.GetData();
                }
            }
        }
        public void SaveChangesWithButton()
        {
            editedText = TextBoxDS.Text;
            SaveChanges();
        }
        public void DeleteWithButton()
        {
            object id = (DataGridDS.SelectedItem as DataRowView)?.Row[0];
            if (id != null && nametable != "")
            {
                SearchCheckBox.IsChecked = false;
                if (nametable == "Завод карандашей")
                {
                    ZavodKarandasheyTableAdapter.DeleteQueryZavodKarandashey(Convert.ToInt32(id));
                    DataGridDS.ItemsSource = ZavodKarandasheyTableAdapter.GetData();
                }
            }
        }
        private void KardashyanIDCMBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)KardashyanTypeIDCMBX.SelectedItem;
            selectedKarandashiID = (int)selectedRow["ID_Karandashi"];
        }

        private void SizeIDCMBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)SizeIDCMBX.SelectedItem;
            selectedRazmerID = (int)selectedRow["ID_Razmer"];
        }

        private void ColorIDCMBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)ColorIDCMBX.SelectedItem;
            selectedChvetID = (int)selectedRow["ID_Chvet"];
        }
        private void SearchCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (SearchCheckBox.IsChecked == true)
            {
                if (nametable != "")
                {
                    if (nametable == "Цвет")
                    {
                        DataGridDS.ItemsSource = colorViewTableAdapter.SearchByName(SearchTextBox.Text);
                    }
                    else if (nametable == "Карандаши")
                    {
                        DataGridDS.ItemsSource = karandashiView.SearchByName(SearchTextBox.Text);
                    }
                    else if (nametable == "Размер")
                    {
                        DataGridDS.ItemsSource = sizeViewTableAdapter.SearchByName(SearchTextBox.Text);
                    }
                    else if (nametable == "Завод карандашей")
                    {
                        DataGridDS.ItemsSource = KarandashiInventoryTableAdapter.SearchByName(SearchTextBox.Text);
                    }
                }
            }
        }
        private void SearchCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (SearchCheckBox.IsChecked == false)
            {
                if (nametable != "")
                {
                    if (nametable == "Цвет")
                    {
                        DataGridDS.ItemsSource = colorViewTableAdapter.GetData();
                    }
                    else if (nametable == "Карандаши")
                    {
                        DataGridDS.ItemsSource = karandashiView.GetData();
                    }
                    else if (nametable == "Размер")
                    {
                        DataGridDS.ItemsSource = sizeViewTableAdapter.GetData();
                    }
                    else if (nametable == "Завод карандашей")
                    {
                        DataGridDS.ItemsSource = KarandashiInventoryTableAdapter.GetData();
                    }
                }
            }
        }
        private void FilterCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (FilterComboBox.SelectedItem != null)
            {
                if (nametable != "")
                {
                    var id = (int)(FilterComboBox.SelectedItem as DataRowView).Row[0];
                    if (nametable == "Цвет")
                    {
                        DataGridDS.ItemsSource = colorViewTableAdapter.FilterByChvetName(id);
                    }
                    else if (nametable == "Карандаши")
                    {
                        DataGridDS.ItemsSource = karandashiView.FilterByKarandashi(id);
                    }
                    else if (nametable == "Размер")
                    {
                        DataGridDS.ItemsSource = sizeViewTableAdapter.FilterByRazmerView(id);
                    }
                    else if (nametable == "Завод карандашей")
                    {
                        DataGridDS.ItemsSource = KarandashiInventoryTableAdapter.FilterByKarandashiInventory(FilterComboBox.Text);
                    }
                }
            }
        }
        private void FilterCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (SearchCheckBox.IsChecked == false)
            {
                if (nametable != "")
                {
                    if (nametable == "Цвет")
                    {
                        DataGridDS.ItemsSource = colorViewTableAdapter.GetData();
                    }
                    else if (nametable == "Карандаши")
                    {
                        DataGridDS.ItemsSource = karandashiView.GetData();
                    }
                    else if (nametable == "Размер")
                    {
                        DataGridDS.ItemsSource = sizeViewTableAdapter.GetData();
                    }
                    else if (nametable == "Завод карандашей")
                    {
                        DataGridDS.ItemsSource = KarandashiInventoryTableAdapter.GetData();
                    }
                    DataGridDS.Columns[0].Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
