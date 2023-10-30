using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Crypto
{
    public string crypto = "";
    public string cryptoName = "ارزی با این رمز ارز در دیتا موجود نمی باشد";
    public string cryptoPrice = "0";
    public decimal cryptoHPisbini = 0;
    public decimal cryptoLPisbini = 0;
    public decimal Total1;
    public decimal Total2;
    public decimal Total3;
    public async void Api()
    {
        Arz arz = new Arz();
        arz.ARZ();
        HttpClient httpclient = new HttpClient();
        string stringAPI = "https://api.wallex.ir/v1/currencies/stats";
        HttpResponseMessage response = await httpclient.GetAsync(stringAPI);

        if (response.IsSuccessStatusCode)
        {
            string apiresponse = await response.Content.ReadAsStringAsync();
            ApiResponseWrapper apiWrapper = JsonConvert.DeserializeObject<ApiResponseWrapper>(apiresponse);
            List<DataItem> dataItems = apiWrapper.result;
            string C = crypto.Remove(0, 3);
            foreach (var item in dataItems)
            {
                if (C == item.key)
                {
                    cryptoName = item.name_en;
                    cryptoPrice = item.price;
                    Pishbini(item.daily_high_price, item.daily_low_price, item.price_change_24h, item.price_change_7d);
                    decimal P = decimal.Parse(cryptoPrice);
                    decimal S = decimal.Parse(arz.sellusd);
                    decimal U = S / 10;
                    Total1 = P * U;
                    Total2 = cryptoHPisbini * U;
                    Total3 = cryptoLPisbini * U;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
    void Pishbini(string DH, string DL, string PCH, string PCD)
    {
        decimal dh = decimal.Parse(DH);
        decimal dl = decimal.Parse(DL);
        decimal pch = decimal.Parse(PCH);
        decimal pcd = decimal.Parse(PCD);
        decimal P1 = pcd + pch;
        decimal P2;
        if (P1 < 0)
        {
            P2 = P1 * -1;
        }
        else
        {
            P2 = P1;
        }
        decimal P3 = (P2 / 7) + dh;
        decimal P4 = (P2 / 7) + dl;
        cryptoHPisbini = P3;
        cryptoLPisbini = P4;
    }
}
public class ApiResponseWrapper
{
    public List<DataItem> result { get; set; }

}
public class DataItem
{
    public string key { get; set; }
    public string name_en { get; set; }
    public string rank { get; set; }
    public string price { get; set; }
    public string daily_high_price { get; set; }
    public string daily_low_price { get; set; }
    public string weekly_high_price { get; set; }
    public string weekly_low_price { get; set; }
    public string price_change_24h { get; set; }
    public string price_change_7d { get; set; }
    public DateTime updated_at { get; set; }
}