using Microsoft.Win32;
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
using ПродКорз.Modeli;
using System.IO;
using ПродКорз.Kontroller;

namespace ПродКорз
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[] polesnost;
        int[] tsena;
        public List<Tovary> Pokupki = new List<Tovary>();
        public List<int> PokupkiIndexes = new List<int>();
        private void Vybrat(object sender, RoutedEventArgs e)
        {
           try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.ShowDialog();
                List<string> spisokPokupok = new List<string>();
                if (dialog.FileName != "")
                {
                    string productString = File.ReadAllText(dialog.FileName);
                    spisokPokupok.AddRange(productString.Split('\n'));
                }
                else
                {
                    MessageBox.Show("Выберите файл");
                    return;
                }
                polesnost = new int[spisokPokupok.Count];
                tsena = new int[spisokPokupok.Count];
                Pokupki.Clear();
                Spisok.ItemsSource = null;
                for (int i = 0; i < spisokPokupok.Count; i++)
                {
                    if (spisokPokupok[i] != "")
                    {
                        string[] data = new string[4];
                        data = spisokPokupok[i].Split(':');
                        Pokupki.Add(new Tovar(data[0], data[1], Int32.Parse(data[2]), Int32.Parse(data[3])));
                        tsena[i] = Int32.Parse(data[2]);
                        polesnost[i] = Int32.Parse(data[3]);
                    }
                }
                Spisok.ItemsSource = Pokupki;
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте формат файла и путь");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = 0;
                //int itog = 0;
                Itog.Items.Clear();
                int money = Int32.Parse(Summa.Text);
                PokupkiIndexes = Ruksak.rukzakproblem(tsena, polesnost, money);
                if (money <= 0)
                {
                    MessageBox.Show("Бомж");
                    return;
                } 
                for (i = 0; i < (PokupkiIndexes.Count - 1); i++)
                /*{
                    Tovary tovary = Pokupki[PokupkiIndexes[i]];
                    itog = itog + tovary.Tsena;
                }*/
                Itog.Items.Add(Pokupki[PokupkiIndexes[i]].Name);
                Itog.Items.Add("Итоговая полезность: " + PokupkiIndexes[i]);
                //Itog.Items.Add("Итоговая цена: " + itog);
            }
            catch (Exception)
            {
                MessageBox.Show("Ты не знаешь что такое цифры?");
                Summa.Text = "";
            }
        }
    }
}

