using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

public class WeatherApi
{
    public string CityName = "";
    public string Name = "شهری با این اسم در دیتا موجود نمی باشد";
    public string WeatherMain = "";
    public string Temp = "";
    public string WindSpeed = "";
    public string URLCity = "Ardabil";
    public string URL = "https://api.openweathermap.org/data/2.5/weather?q=";
    public string URLToken = "&appid=4d723d0d3d102c4081078a6c2bba6279";
    public void weather()
    {
        string C = CityName.Remove(0, 3);
        if (C == "تهران" || C == "Tehrun")
        {
            URLCity = "Tehran";
        }
        else if (C == "آذربایجان غربی" || C == "ارومیه" || C == "Urmia")
        {
            URLCity = "Urmia";
        }
        else if (C == "آذربایجان شرقی" || C == "تبریز" || C == "Tabriz")
        {
            URLCity = "Tabriz";
        }
        else if (C == "اردبیل" || C == "Ardabil")
        {
            URLCity = "Ardabil";
        }
        else if (C == "همدان" || C == "Hamadan")
        {
            URLCity = "Hamadan";
        }
        else if (C == "کردستان" || C == "Kurdistan")
        {
            URLCity = "Kurdistan";
        }
        else if (C == "زنجان" || C == "Zanjan")
        {
            URLCity = "Zanjan";
        }
        else if (C == "قزوین" || C == "Qazvin")
        {
            URLCity = "Qazvin";
        }
        else if (C == "گیلان" || C == "Gilan" || C == "رشت")
        {
            URLCity = "Rasht";
        }
        else if (C == "مازندران" || C == "Mazandran" || C == "ساری")
        {
            URLCity = "Sari";
        }
        else if (C == "کرج" || C == "البرز" || C == "Alborz")
        {
            URLCity = "Karaj";
        }
        else if (C == "گلستان" || C == "گرگان" || C == "Golstan")
        {
            URLCity = "Gorgan";
        }
        else if (C == "سمنان" || C == "Semnan")
        {
            URLCity = "Semnan";
        }
        else if (C == "قم" || C == "Qom")
        {
            URLCity = "Qom";
        }
        else if (C == "خراسان شمالی" || C == "بجنورد" || C == "Khorasane Shomali")
        {
            URLCity = "Bojnourd";
        }
        else if (C == "خراسان رضوی" || C == "مشهد" || C == "Khorasane Razavi")
        {
            URLCity = "Mashhad";
        }
        else if (C == "اراک" || C == "مرکزی" || C == "Arak")
        {
            URLCity = "Arak";
        }
        else if (C == "اصفحان" || C == "Esfahan")
        {
            URLCity = "Isfahan";
        }
        else if (C == "یزد" || C == "Yazd")
        {
            URLCity = "Yazd";
        }
        else if (C == "خراسان جنوبی" || C == "بیرجند" || C == "Khorasane Jonobi")
        {
            URLCity = "Birjand";
        }
        else if (C == "کرمان" || C == "Kerman")
        {
            URLCity = "Kerman";
        }
        else if (C == "سیستان و بلوچستان" || C == "Zahedan")
        {
            URLCity = "Zahedan";
        }
        else if (C == "کرمانشاه" || C == "Kermanshah")
        {
            URLCity = "Kermanshah";
        }
        else if (C == "لرستان" || C == "خرم آباد" || C == "Lorstan")
        {
            URLCity = "Lorestan";
        }
        else if (C == "ایلام" || C == "Ilam")
        {
            URLCity = "Lorestan";
        }
        else if (C == "خوزستان" || C == "اهواز" || C == "Ahvaz")
        {
            URLCity = "Ahvaz";
        }
        else if (C == "چهارمحال و بختیاری" || C == "Chaharmahal va Bakhtiari")
        {
            URLCity = "Shūshtar";
        }
        else if (C == "یاسوج" || C == "کهگیلویه و بویراحمد" || C == "Lorstan")
        {
            URLCity = "Yasuj";
        }
        else if (C == "فارس" || C == "شیراز" || C == "Fars")
        {
            URLCity = "Fars";
        }
        else if (C == "بندرعباس" || C == "هرمزگان" || C == "Bandarabbas")
        {
            URLCity = "Bandar Abbas";
        }
        else if (C == "بوشهر" || C == "Bushehr")
        {
            URLCity = "Bushehr";
        }
        else
        {
            return;
        }
        WebClient client = new WebClient();
        string DataBot = client.DownloadString($"{URL}{URLCity}{URLToken}");
        var dJson = JsonConvert.DeserializeObject<Root3>(DataBot);
        Temp = dJson.main.temp.ToString();
        WindSpeed = dJson.wind.speed;
        Name = C;
    }
}

public class Main
{
    public double temp { get; set; }
}
public class Root3
{
    public List<Weather> weather { get; set; }
    public Main main { get; set; }
    public Wind wind { get; set; }
}

public class Weather
{
    public string main { get; set; }
}
public class Wind
{
    public string speed { get; set; }
}






