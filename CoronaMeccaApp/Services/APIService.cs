using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaMeccaApp.Services
{
    public class APIService : IAPIService
    {

        HttpClient client;
        public APIService()
        {
            client = new HttpClient();
        }

    }
}
