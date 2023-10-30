using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json;

public class GoldApi
{
    string apiKey = "goldapi-26y0zrlobwcbxq-io";
    string symbol = "XAU";
    string curr = "USD";
    string date = "";
    public string GoldPriceD = "0";
    public string GoldPriceT = "0";
    public string GoldPriceT24 = "0";
    public string GoldPriceT18 = "0";
    public async void Gold()
    {
        Arz arz = new Arz();
        using (HttpClient client = new HttpClient())
        {
            arz.ARZ();
            client.DefaultRequestHeaders.Add("x-access-token", apiKey);
            string url = $"https://www.goldapi.io/api/{symbol}/{curr}{date}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            var dJson = JsonConvert.DeserializeObject<Root4>(result);
            string A = dJson.price.ToString();
            GoldPriceD = A;
            decimal P = decimal.Parse(arz.sellusd);
            decimal P4 = P / 10;
            decimal P1 = decimal.Parse(A);
            string B = dJson.price_gram_18k.ToString();
            string C = dJson.price_gram_24k.ToString();
            decimal P2 = decimal.Parse(B);
            decimal P3 = decimal.Parse(C);
            decimal Total1 = P1 * P4;
            decimal Total2 = P2 * P4;
            decimal Total3 = P3 * P4;
            GoldPriceT = Total1.ToString();
            GoldPriceT18 = Total2.ToString();
            GoldPriceT24 = Total3.ToString();
        }
    }
}
public class Root4
{
    public double price { get; set; }
    public double price_gram_24k { get; set; }
    public double price_gram_18k { get; set; }
}

