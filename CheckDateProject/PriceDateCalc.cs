using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckDateProject
{
    public   class PriceDateCalc
    {

     

        public static int DateCheck(DateTime dateFrom, DateTime dateTo)/// это метод проверки даты(чтобы правильно все было введнено)
        {
            int result=0;

            if (dateFrom == null || dateTo == null)
            {
                result =  0;  
            }
            else if (dateFrom > dateTo) { result= -1; }
            else if (dateFrom < dateTo) { result = 1; }

            return result;



        }
        public static double DatePriceCount(DateTime dateFrom, DateTime dateTo, Double price)/// это метод подсчета суммы принимает три параметра - начальная дата, конечная дата, цена
        {
            double result = 0;

            result = (double)((dateTo.Month - dateFrom.Month)+(dateTo.Year-dateFrom.Year)*12) * price;


            return result; /// возвращает сумму
        }

    }
}
