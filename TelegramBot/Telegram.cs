using System;
using System.Data;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Xml.Serialization;
using Newtonsoft.Json;
int OFFSET = 0;
string url = $"https://api.telegram.org/bot6351596640:AAHm9v1hLxZX5CsaBKVLjKI7s46g8Y0TvwQ/";
WebClient client = new WebClient();
decimal offset = 0;
    while (true)
    {
    string DataBot = client.DownloadString($"{url}getupdates?offset={offset}");
    var dJson = JsonConvert.DeserializeObject<Root>(DataBot);
    foreach (var item in dJson.result)
    {

            Arz arz = new Arz();
            string url2 = $"{url}sendmessage?chat_id={item.message.chat.id}&text=";
            if (item.message.text == "/start")
            {
                client.DownloadString(url2 + "سلام خوش آمدید");
                client.DownloadString(url2 + "درخواست هایی می توانید از من بخواهید:\n دریافت چت آی دی = /ID \nقیمت دلار = /Dolar \n قیمت یورو = /Euro \n قیمت درهم = /Derham\n قیمت ارز = /Crypto \nآب و هوا  = /Weather\n قیمت طلا = /Gold \n ده فیلم برتر جهان = /IMDB\n اوقات شرعی = /Azan");
            }
            else if (item.message.text == "/Crypto")
            {
                client.DownloadString(url2 + ":لطفا رمز ارز مورد نظر خود را وارد کنید نحوه ورود \n /C-BTC ");
            }

            else if (item.message.text == "/Dolar")
            {
                arz.ARZ();
                System.Threading.Thread.Sleep(1000);
                client.DownloadString(url2 + $"قیمت خرید دلار ریال ={arz.buyusd}\nقیمت فروش دلار ریال ={arz.sellusd}");
            }
            else if (item.message.text == "/Euro")
            {
                arz.ARZ();
                System.Threading.Thread.Sleep(1000);
                client.DownloadString(url2 + $"قیمت خرید یورو ریال ={arz.buyeur}\nقیمت فروش یورو ریال ={arz.selleur} ");
            }
            else if (item.message.text == "/Derham")
            {
                arz.ARZ();
                System.Threading.Thread.Sleep(1000);
                client.DownloadString(url2 + $"قیمت خرید درهم ریال ={arz.buyaed}\nقیمت فروش درهم ریال ={arz.sellaed}");
            }
            else if (item.message.text == "/Weather")
            {
                client.DownloadString(url2 + "برای دریافت آب و هوا لطفا اسم استان مورد نظر را وارد کنید \nبرای مثال:  \n /W-Karaj \n /W-کرج");
            }

            else if (item.message.text == "/Gold")
            {
                GoldApi gold = new GoldApi();
                gold.Gold();
                System.Threading.Thread.Sleep(1000);
                client.DownloadString(url2 + $"قیمت هر انس طلا به دلار = {gold.GoldPriceD}\n قیمت هر انس طلا به تومان = {gold.GoldPriceT}\nقیمت هر گرم طلا 18 عیار به تومان = {gold.GoldPriceT18}\nقیمت هر گرم طلا 24 عیار به تومان = {gold.GoldPriceT24}\n");
            }
            else if (item.message.text == "/IMDB")
            {
                client.DownloadString(url2 + "این بخش می تواند 10 فیلم برتر جهان را نمایش دهد \n برای نمایش رتبه فیلمی که می خواهید را وارد کنید برای مثال \n /I-1");
            }

            else if (item.message.text == "/ID")
            {
                client.DownloadString(url2 + $"چت آیدی \n {item.message.from.id} \n نام کاربری \n @{item.message.from.username} ");
            }
            else if (item.message.text == "/Azan")
            {
                client.DownloadString(url2 + "برای دریافت اوقات شرعی لطفا اسم استان مورد نظر را وارد کنید \n برای مثال:  \n /A-Karaj \n /A-کرج");
            }
            else if (item.message.text.StartsWith("/C-"))
            {
                Crypto crypto = new Crypto();
                crypto.crypto = item.message.text;
                crypto.Api();
                System.Threading.Thread.Sleep(2000);
                client.DownloadString(url2 + $"نام ارز ={crypto.cryptoName}\n قیمت ارز به تومان ={crypto.Total1}\n قیمت ارز به دلار ={crypto.cryptoPrice}\nبیشترین قیمت فردا به تومان ={crypto.Total2}\nکمترین قیمت فردا به تومان ={crypto.Total3}");
            }
            else if (item.message.text.StartsWith("/W-"))
            {
                WeatherApi weather = new WeatherApi();
                weather.CityName = item.message.text;
                weather.weather();
                client.DownloadString(url2 + $"نام شهر ={weather.Name}\n دمای هوا ={weather.Temp}\n سرعت باد ={weather.WindSpeed}");
            }
            else if (item.message.text.StartsWith("/I-"))
            {
                IMDB imdb = new IMDB();
                imdb.Id = item.message.text;
                imdb.Movie();
                System.Threading.Thread.Sleep(2000);
                client.DownloadString(url2 + $"لینک پوستر = {imdb.MPoster}");
                client.DownloadString(url2 + $"رتبه فیلم = {imdb.MId}\n اسم فیلم = {imdb.MTitel}\n سال ساخت = {imdb.MYear}\n کشور سازنده = {imdb.MCountry}\n امتیاز = {imdb.MIMDB}");
            }
            else if (item.message.text.StartsWith("/A-"))
            {
                Azan azan = new Azan();
                azan.City = item.message.text;
                azan.Oghat();
                System.Threading.Thread.Sleep(1000);
                client.DownloadString(url2 + $"نام شهر = {azan.CityName}\n طلوع آفتاب = {azan.Sunrise}\n غروب آفتاب = {azan.Sunset}\n اذان صبح = {azan.Imsaak}\n اذان ظهر = {azan.Noon}\n اذان مغرب = {azan.Maghreb}");
            }
            else
            {
                client.DownloadString(url2 + "درخواست هایی می توانید از من بخواهید: \nقیمت دلار = /Dolar \n قیمت یورو = /Euro \n قیمت درهم = /Derham\n قیمت ارز = /Crypto \nآب و هوا = /Weather\n قیمت طلا = /Gold \n ده فیلم برتر جهان = /IMDB \n دریافت چت آی دی = /ID \n اوقات شرعی = /Azan");
            }
            Console.WriteLine($"@{item.message.from.username} Send New Message \n ...........................");
            offset = item.update_id + 1;
    }
    }


