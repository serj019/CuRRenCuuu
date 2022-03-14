using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp14
{
   static class ConverterValute
    {
        public static double Convert(Valute first,Valute second)
        {
            return (first.Value / first.Nominal) / (second.Value / second.Nominal);
        }


    }
}
