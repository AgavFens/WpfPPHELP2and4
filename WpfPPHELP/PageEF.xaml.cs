using System;
using System.Collections.Generic;
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
using System.Xml;
using WpfPPHELP;


namespace WpfPPHELP
{
    public partial class PageEF : Page
    {
        private BDPPEntities praktika1Entity = new BDPPEntities();
        int idKarandashiType;
        int idRazmer;
        int idChvet;
        string nametable = "";
        public PageEF(string selectedTable)
        {
            InitializeComponent();
            if (selectedTable != "")
            {
                nametable = selectedTable;
                if (selectedTable == "Цвет")
                {
                    DataGridEF.ItemsSource = praktika1Entity.ChvetView.ToList();
                    FilterComboBox.ItemsSource = praktika1Entity.Chvet.ToList();
                    FilterComboBox.DisplayMemberPath = "Chvet1";
                }
                else if (selectedTable == "Карандаши")
                {
                    DataGridEF.ItemsSource = praktika1Entity.KarandashiView.ToList();
                    FilterComboBox.ItemsSource = praktika1Entity.Karandashi.ToList();
                    FilterComboBox.DisplayMemberPath = "KarandashiType";
                }
                else if (selectedTable == "Завод карандашей")
                {
                    DataGridEF.ItemsSource = praktika1Entity.ZavodKarandashey.ToList();
                    SizeIDCMBX.ItemsSource = praktika1Entity.Razmer.ToList();
                    SizeIDCMBX.DisplayMemberPath = "Razmer1";
                    ColorIDCMBX.ItemsSource = praktika1Entity.Chvet.ToList();
                    ColorIDCMBX.DisplayMemberPath = "Chvet1";
                    KardashyanTypeIDCMBX.ItemsSource = praktika1Entity.Karandashi.ToList();
                    KardashyanTypeIDCMBX.DisplayMemberPath = "KarandashiType";
                    GridTextBoxEF.Visibility = Visibility.Hidden;
                    GridComboBoxesEF.Visibility = Visibility.Visible;
                    FilterComboBox.ItemsSource = praktika1Entity.Karandashi.ToList();
                    FilterComboBox.DisplayMemberPath = "Карандаши";
                }
                else if (selectedTable == "Размер")
                {
                    DataGridEF.ItemsSource = praktika1Entity.RazmerView.ToList();
                    FilterComboBox.ItemsSource = praktika1Entity.Razmer.ToList();
                    FilterComboBox.DisplayMemberPath = "Razmer1";
                }
            }
        }
        public void AddNewData()
        {
            if (nametable != "")
            {
                if (nametable == "Цвет")
                {
                    Chvet chvet = new Chvet();
                    chvet.Chvet1 = TextBoxEF.Text;
                    praktika1Entity.Chvet.Add(chvet);
                    praktika1Entity.SaveChanges();
                    DataGridEF.ItemsSource = praktika1Entity.ChvetView.ToList();
                }
                else if (nametable == "Карандаши")
                {
                    Karandashi karandashi = new Karandashi();
                    karandashi.KarandashiType = TextBoxEF.Text;
                    praktika1Entity.Karandashi.Add(karandashi);
                    praktika1Entity.SaveChanges();
                    DataGridEF.ItemsSource = praktika1Entity.KarandashiView.ToList();
                }
                else if (nametable == "Размер")
                {
                    Razmer razmer = new Razmer();
                    razmer.Razmer1 = TextBoxEF.Text;
                    praktika1Entity.Razmer.Add(razmer);
                    praktika1Entity.SaveChanges();
                    DataGridEF.ItemsSource = praktika1Entity.RazmerView.ToList();
                }
                else if (nametable == "Завод карандашей")
                {
                    ZavodKarandashey zavodKarandashey = new ZavodKarandashey();
                    zavodKarandashey.KarandashiType_ID = (idKarandashiType);
                    zavodKarandashey.Razmer_ID = (idRazmer);
                    zavodKarandashey.Chvet_ID = (idChvet);
                    zavodKarandashey.Price = (Convert.ToInt32(PriceTBX.Text));
                    praktika1Entity.ZavodKarandashey.Add(zavodKarandashey);
                    praktika1Entity.SaveChanges();
                    DataGridEF.ItemsSource = praktika1Entity.KarandashiInventory.ToList();
                }
                DataGridEF.Columns[0].Visibility = Visibility.Collapsed;
            }
        }
        public void SaveChangesWithButton()
        {
            if (DataGridEF.SelectedItem != null)
            {
                if (nametable == "Цвет")
                {
                    var selected = DataGridEF.SelectedItem as ChvetView;
                    Chvet chvetToSave = praktika1Entity.Chvet.FirstOrDefault(chvet => chvet.ID_Chvet == selected.Номер_цвета);
                    chvetToSave.Chvet1 = TextBoxEF.Text;
                    praktika1Entity.SaveChanges();
                    DataGridEF.ItemsSource = praktika1Entity.ChvetView.ToList();
                }
                else if (nametable == "Карандаши")
                {
                    var selected = DataGridEF.SelectedItem as KarandashiView;
                    Karandashi karandashiToSave = praktika1Entity.Karandashi.FirstOrDefault(k => k.ID_Karandashi == selected.Номер_карандаша);
                    karandashiToSave.KarandashiType = TextBoxEF.Text;
                    praktika1Entity.SaveChanges();
                    DataGridEF.ItemsSource = praktika1Entity.KarandashiView.ToList();
                }
                else if (nametable == "Размер")
                {
                    var selected = DataGridEF.SelectedItem as RazmerView;
                    Razmer razmerToSave = praktika1Entity.Razmer.FirstOrDefault(razmer => razmer.ID_Razmer == selected.Номер_размера);
                    razmerToSave.Razmer1 = TextBoxEF.Text;
                    praktika1Entity.SaveChanges();
                    DataGridEF.ItemsSource = praktika1Entity.ChvetView.ToList();
                }
                else if (nametable == "Завод карандашей")
                {
                    var selected = DataGridEF.SelectedItem as ZavodKarandashey;
                    ZavodKarandashey zavodKarandasheyToSave = praktika1Entity.ZavodKarandashey.FirstOrDefault(sf => sf.ID_SozdanogoKarandasha == selected.ID_SozdanogoKarandasha);
                    zavodKarandasheyToSave.KarandashiType_ID = (idKarandashiType);
                    zavodKarandasheyToSave.Razmer_ID = (idRazmer);
                    zavodKarandasheyToSave.Chvet_ID = (idChvet);
                    zavodKarandasheyToSave.Price = Convert.ToInt32(PriceTBX.Text);
                    praktika1Entity.SaveChanges();
                    DataGridEF.ItemsSource = praktika1Entity.KarandashiInventory.ToList();
                }
                DataGridEF.Columns[0].Visibility = Visibility.Collapsed;
                praktika1Entity.SaveChanges();
            }
        }
        public void DeleteWithButton()
        {
            if (nametable != "")
            {
                if (nametable == "Цвет")
                {
                    ChvetView selectedItem = DataGridEF.SelectedItem as ChvetView;
                    Chvet chvetToDelete = praktika1Entity.Chvet.FirstOrDefault(chvet => chvet.ID_Chvet == selectedItem.Номер_цвета);
                    praktika1Entity.Chvet.Remove(chvetToDelete);
                    praktika1Entity.SaveChanges();
                    DataGridEF.ItemsSource = praktika1Entity.ChvetView.ToList();
                }
                else if (nametable == "Карандаши")
                {
                    KarandashiView selectedItem = DataGridEF.SelectedItem as KarandashiView;
                    Karandashi karandashiToDelete = praktika1Entity.Karandashi.FirstOrDefault(karandashi => karandashi.ID_Karandashi == selectedItem.Номер_карандаша);
                    praktika1Entity.Karandashi.Remove(karandashiToDelete);
                    praktika1Entity.SaveChanges();
                    DataGridEF.ItemsSource = praktika1Entity.KarandashiView.ToList();
                }
                else if (nametable == "Размер")
                {
                    RazmerView selectedItem = DataGridEF.SelectedItem as RazmerView;
                    Razmer razmerToDelete = praktika1Entity.Razmer.FirstOrDefault(razmer => razmer.ID_Razmer == selectedItem.Номер_размера);
                    praktika1Entity.Razmer.Remove(razmerToDelete);
                    praktika1Entity.SaveChanges();
                    DataGridEF.ItemsSource = praktika1Entity.RazmerView.ToList();
                }
                else if (nametable == "Завод карандашей")
                {
                    var selectedItem = DataGridEF.SelectedItem as ZavodKarandashey;
                    ZavodKarandashey zavodKarandasheyToDelete = praktika1Entity.ZavodKarandashey.FirstOrDefault(zd => zd.ID_SozdanogoKarandasha == selectedItem.ID_SozdanogoKarandasha);
                    praktika1Entity.ZavodKarandashey.Remove(zavodKarandasheyToDelete);
                    praktika1Entity.SaveChanges();
                    DataGridEF.ItemsSource = praktika1Entity.KarandashiInventory.ToList();
                }
                DataGridEF.Columns[0].Visibility = Visibility.Collapsed;
            }
        }
        private void ShoeTypeIDCMBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = KardashyanTypeIDCMBX.SelectedItem as Karandashi;
            idKarandashiType = praktika1Entity.Karandashi.Where(k => k.KarandashiType == selectedItem.KarandashiType).Select(k => k.ID_Karandashi).FirstOrDefault();
        }

        private void SizeIDCMBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = SizeIDCMBX.SelectedItem as Razmer;
            idRazmer = praktika1Entity.Razmer.Where(size => size.Razmer1 == selectedItem.Razmer1).Select(size => size.ID_Razmer).FirstOrDefault();


        }
        private void ColorIDCMBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ColorIDCMBX.SelectedItem as Chvet;
            idChvet = praktika1Entity.Chvet.Where(color => color.Chvet1 == selectedItem.Chvet1).Select(color => color.ID_Chvet).FirstOrDefault();
        }

        private void DataGridEF_Loaded(object sender, RoutedEventArgs e)
        {
            if (nametable != "" && nametable != "Объединенная таблица")
            {
                DataGridEF.Columns[0].Visibility = Visibility.Collapsed;
            }
        }
        private void DataGridAllTables_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void SearchCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (SearchCheckBox.IsChecked == true)
            {
                if (nametable != "")
                {
                    if (nametable == "Цвет")
                    {
                        DataGridEF.ItemsSource = praktika1Entity.ChvetView.ToList().Where(item => item.Цвет.ToLower().Contains(SearchTextBox.Text.ToLower()));
                    }
                    else if (nametable == "Карандаши")
                    {
                        DataGridEF.ItemsSource = praktika1Entity.KarandashiView.ToList().Where(item => item.Тип_карандаша.Contains(SearchTextBox.Text));
                    }
                    else if (nametable == "Размер")
                    {
                        DataGridEF.ItemsSource = praktika1Entity.RazmerView.ToList().Where(item => item.Размер.ToString().Contains(SearchTextBox.Text));
                    }
                    else if (nametable == "Завод карандашей")
                    {
                        DataGridEF.ItemsSource = praktika1Entity.KarandashiInventory.ToList().Where(item => item.Тип_карандаша.Contains(SearchTextBox.Text));
                    }
                    DataGridEF.Columns[0].Visibility = Visibility.Collapsed;
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
                        DataGridEF.ItemsSource = praktika1Entity.ChvetView.ToList();
                    }
                    else if (nametable == "Карандаши")
                    {
                        DataGridEF.ItemsSource = praktika1Entity.KarandashiView.ToList();
                    }
                    else if (nametable == "Размер")
                    {
                        DataGridEF.ItemsSource = praktika1Entity.RazmerView.ToList();

                    }
                    else if (nametable == "Завод карандашей")
                    {
                        DataGridEF.ItemsSource = praktika1Entity.KarandashiInventory.ToList();

                    }
                    DataGridEF.Columns[0].Visibility = Visibility.Collapsed;
                }
            }
        }
        private void FilterCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (FilterComboBox.SelectedItem != null)
            {
                if (nametable != "")
                {
                    if (nametable == "Цвет")
                    {
                        DataGridEF.ItemsSource = praktika1Entity.ChvetView.ToList().Where(item => item.Цвет == FilterComboBox.Text); ;
                    }
                    else if (nametable == "Карандаши")
                    {
                        DataGridEF.ItemsSource = praktika1Entity.KarandashiView.ToList().Where(item => item.Тип_карандаша == FilterComboBox.Text); ;
                    }
                    else if (nametable == "Размер")
                    {
                        DataGridEF.ItemsSource = praktika1Entity.RazmerView.ToList().Where(item => item.Размер == FilterComboBox.Text);
                    }
                    else if (nametable == "Завод карандашей")
                    {
                        DataGridEF.ItemsSource = praktika1Entity.KarandashiInventory.ToList().Where(item => item.Тип_карандаша == FilterComboBox.Text); ;
                    }
                    DataGridEF.Columns[0].Visibility = Visibility.Collapsed;
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
                        DataGridEF.ItemsSource = praktika1Entity.ChvetView.ToList();
                    }
                    else if (nametable == "Карандаши")
                    {
                        DataGridEF.ItemsSource = praktika1Entity.KarandashiView.ToList();
                    }
                    else if (nametable == "Размер")
                    {
                        DataGridEF.ItemsSource = praktika1Entity.RazmerView.ToList();

                    }
                    else if (nametable == "Обувная фабрика")
                    {
                        DataGridEF.ItemsSource = praktika1Entity.KarandashiInventory.ToList();

                    }
                    DataGridEF.Columns[0].Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}