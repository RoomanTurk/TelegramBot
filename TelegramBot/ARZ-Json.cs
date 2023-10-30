using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

public class Arz
{
    public string buyusd = "a";
    public string sellusd = "0";
    public string buyeur = "a";
    public string selleur = "a";
    public string buyaed = "a";
    public string sellaed = "a";
    public async void ARZ()
    {
    WebClient client = new WebClient();
    string DataBot = client.DownloadString("https://www.megaweb.ir/api/money");
    var dJson = JsonConvert.DeserializeObject<Root2>(DataBot);
    buyusd = dJson.buy_usd.price;
    sellusd = dJson.sell_usd.price;
    buyeur = dJson.buy_eur.price;
    selleur = dJson.sell_eur.price;
    buyaed = dJson.buy_aed.price;
    sellaed = dJson.sell_aed.price;
    }
}
public class BuyAed
{
    public string title { get; set; }
    public string price { get; set; }
    public string jdate { get; set; }
    public string gdate { get; set; }
}

public class BuyEur
{
    public string title { get; set; }
    public string price { get; set; }
    public string jdate { get; set; }
    public string gdate { get; set; }
}

public class BuyUsd
{
    public string title { get; set; }
    public string price { get; set; }
    public string jdate { get; set; }
    public string gdate { get; set; }
}

public class Root2
{
    public BuyUsd buy_usd { get; set; }
    public BuyEur buy_eur { get; set; }
    public BuyAed buy_aed { get; set; }
    public SellUsd sell_usd { get; set; }
    public SellEur sell_eur { get; set; }
    public SellAed sell_aed { get; set; }
}

public class SellAed
{
    public string title { get; set; }
    public string price { get; set; }
    public string jdate { get; set; }
    public string gdate { get; set; }
}

public class SellEur
{
    public string title { get; set; }
    public string price { get; set; }
    public string jdate { get; set; }
    public string gdate { get; set; }
}

public class SellUsd
{
    public string title { get; set; }
    public string price { get; set; }
    public string jdate { get; set; }
    public string gdate { get; set; }
}
