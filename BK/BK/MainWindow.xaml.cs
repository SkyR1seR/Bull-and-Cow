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

namespace BK
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] number { get; set; }
        string chislo;
        string chislo1 = "0000";
        int bull;
        int cow;
        public MainWindow()
        {
            InitializeComponent();

            number = new string[] {"1","2","3","4","5","6","7","8","9"};

            DataContext = this;
        }
        private void zadChislo_Click_1(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int max = 10;
            int[] x = new int[4];
            for (int i = 0; i < 4; i++)
            {
                bool contains;
                int next;
                do
                {
                    next = r.Next(1, max);
                    contains = false;
                    for (int index = 0; index < i; index++)
                    {
                        int n = x[index];
                        if (n == next)
                        {
                            contains = true;
                            break;
                        }
                    }
                } while (contains);
                x[i] = next;
            }

            foreach (int i in x)
            {
                chislo += i.ToString();
            }
            chislo1 = chislo;
            chislo = "";
            MessageBox.Show("Число загаданно!");
        }
        private void provChislo_Click(object sender, RoutedEventArgs e)
        {
            cow = 0;
            bull = 0;
            char[] a = chislo1.ToCharArray();
            if (Convert.ToChar(combOne.SelectedItem) == a[0])
            {
                bull ++;
            }
            if (Convert.ToChar(combOne.SelectedItem) == a[1] || Convert.ToChar(combOne.SelectedItem) == a[2] || Convert.ToChar(combOne.SelectedItem) == a[3])
            {
                cow++;
            }
            if (Convert.ToChar(combTwo.SelectedItem) == a[1])
            {
                bull++;
            }
            if (Convert.ToChar(combTwo.SelectedItem) == a[2] || Convert.ToChar(combTwo.SelectedItem) == a[3] || Convert.ToChar(combTwo.SelectedItem) == a[0])
            {
                cow++;
            }
            if (Convert.ToChar(combThree.SelectedItem) == a[2])
            {
                bull++;
            }
            if (Convert.ToChar(combThree.SelectedItem) == a[3] || Convert.ToChar(combThree.SelectedItem) == a[0] || Convert.ToChar(combThree.SelectedItem) == a[1])
            {
                cow++;
            }
            if (Convert.ToChar(combFour.SelectedItem) == a[3])
            {
                bull++;
            }
            if (Convert.ToChar(combFour.SelectedItem) == a[0] || Convert.ToChar(combFour.SelectedItem) == a[1] || Convert.ToChar(combFour.SelectedItem) == a[2])
            {
                cow++;
            }
            if (bull < 4)
            {
                TextBox.Text = "Твое число: " + combOne.SelectedItem + combTwo.SelectedItem + combThree.SelectedItem + combFour.SelectedItem + "\n" + "Быков: " + bull + "\n" + "Коров: " + cow;
            } else
            {
                TextBox.Text = "Ты угадал число!";
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
