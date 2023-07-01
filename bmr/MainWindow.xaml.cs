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

namespace bmr
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
        public static double BMP;
        public static double TDEE;
        public static double weight;
        public static double year;
        public static double height;

        private void yearTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void heightTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void weightTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (heightTb.Text.Length > 0 && yearTb.Text.Length > 0 && weightTb.Text.Length > 0 && floorCb.SelectedItem != null)
            {
                height = int.Parse(heightTb.Text.Trim());
                year = int.Parse(yearTb.Text.Trim());
                weight = int.Parse(weightTb.Text.Trim());
                int yer1 = 0;
                int yer2 = 2023;
                //int yer2 = 2023;
                int hed1 = 0;
                int head2 = 200;
                int wei1 = 0;

                if ((year > yer1 && year < yer2) && (height > hed1 && height < head2) && weight > wei1)
                {
                    if ((string)(floorCb.SelectedItem as ComboBoxItem).Tag == "2")
                    {
                        bmrTb.Text = (65.5 + (9.6 * weight) + (1.8 * height) - (4.7 * (2023 - year))).ToString();
                    }
                    else
                    {
                        bmrTb.Text = (66 + (13.7 * weight) + (5 * height) - (6.8 * (2023 - year))).ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Введите корректные данные ");
                }


            }
            else
            {
                MessageBox.Show("Введите данные");
            }
        }

      

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
            if (ActivCb.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус активности");
            }
            else
            {
                //TdeeTb.Text = "0";
                double bm = double.Parse(bmrTb.Text.Trim());

                if ((string)(ActivCb.SelectedItem as ComboBoxItem).Tag == "1")
                {
                    TdeeTb.Text = (bm * 1.2).ToString();
                }
                else if ((string)(ActivCb.SelectedItem as ComboBoxItem).Tag == "2")
                {
                    TdeeTb.Text = (bm * 1.375).ToString();
                }
                else if ((string)(ActivCb.SelectedItem as ComboBoxItem).Tag == "3")
                {
                    TdeeTb.Text = (bm * 1.55).ToString();
                }
                else if ((string)(ActivCb.SelectedItem as ComboBoxItem).Tag == "4")
                {
                    TdeeTb.Text = (bm * 1.725).ToString();

                }
                else
                {
                    TdeeTb.Text = (bm * 1.9).ToString();

                }

                //switch ((ActivCb.SelectedItem as ComboBoxItem).Tag)
                //{
                //    case "1":
                //        TdeeTb.Text = (bm * 1.2).ToString();
                //        break;
                //    case "2":
                //        TdeeTb.Text = (bm * 1.375).ToString();
                //        break;
                //    case "3":
                //        TdeeTb.Text = (bm * 1.55).ToString();
                //        break;
                //    case "4":
                //        TdeeTb.Text = (bm * 1.725).ToString();
                //        break;
                //    case "5":
                //        TdeeTb.Text = (bm * 1.9).ToString();
                //        break;


                //    //default:
                //    //    break;
                //}
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            floorCb.Text = "";
            yearTb.Text = "";
            weightTb.Text = "";
            heightTb.Text = "";
            yearTb.Text = "";
            ActivCb.Text = "";
            bmrTb.Text = "";
            TdeeTb.Text = "";
        }
    }
}
