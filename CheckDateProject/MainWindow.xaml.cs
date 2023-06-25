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

namespace CheckDateProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            labelTip.Content = "Выберите дату начала договора";
            datePickerFrom.DisplayDateStart = DateTime.Now;
            
            if (datePickerFrom.SelectedDate == null)
            {
                datePickerTo.IsEnabled = false;
            }
        }

        private void datePickerFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)/// действия при выборе даты 
        {
            datePickerTo.IsEnabled = true;
            datePickerTo.DisplayDateStart = datePickerFrom.SelectedDate.Value.AddMonths(1); /// устанавливаем для второго датапикера минимальную дату не меньше выбранной на месяц

            labelTip.Content = "Выберите дату окончания договора";



        }

        private void datePickerTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
           int dateCheckresult =  PriceDateCalc.DateCheck(datePickerFrom.SelectedDate.Value,datePickerTo.SelectedDate.Value);

            if (dateCheckresult == 1)
            {
                double finalprice = PriceDateCalc.DatePriceCount(datePickerFrom.SelectedDate.Value, datePickerTo.SelectedDate.Value, 30000);
                labelTip.Content = "Итого: " + finalprice.ToString();
            }
            else if (dateCheckresult == 0)
            {
                labelTip.Content = "Даты не введены";
            }
            else if ( dateCheckresult == -1)
            {
                labelTip.Content = "Введенная дата ОТ больше даты ДО!";


            }
        }
    }
}
