using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp14
{
    class JsonToValuteAdapter
    {
        public Dictionary<string,Valute> Valutes { get; private set; }
        public BankInfo BankInfo { get; private set; }

        public void Convert(string Json)
        {

            BankInfo = JsonConvert.DeserializeObject<BankInfo>(Json);
            Valutes = BankInfo.Valute;


        }
      
    }
}
