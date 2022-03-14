using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp14
{
   static class Connector
    {
    
      static public string JsonText { get; private set; }






        static public async Task RefreshData(string Url)
        {
            HttpClient _client = new HttpClient();
            HttpResponseMessage _responce = await _client.GetAsync(Url);
            JsonText = await _responce.Content.ReadAsStringAsync();
           
        }

        

    }
}
