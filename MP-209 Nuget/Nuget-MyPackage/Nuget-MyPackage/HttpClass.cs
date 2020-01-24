using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;

namespace Nuget_MyPackage
{
    public class HttpClass
    {
        async Task DownloadAsync()
        {
            HttpClient httpClient = new HttpClient();
            await httpClient.GetStringAsync("");
        }
    }
}