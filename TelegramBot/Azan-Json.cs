using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

public class Azan
{
    public string City = "";
    public string CityName = "شهری با این اسم در دیتا موجود نمی باشد";
    public string Imsaak = "";
    public string Sunrise = "";
    public string Noon = "";
    public string Sunset = "";
    public string Maghreb = "";
    public string URLCity = "";
    public async void Oghat()
    {
        string C = City.Remove(0, 3);
        if (C == "تهران" || C == "Tehrun")
        {
            URLCity = "1";
        }
        else if (C == "آذربایجان غربی" || C == "ارومیه" || C == "Urmia")
        {
            URLCity = "3";
        }
        else if (C == "آذربایجان شرقی" || C == "تبریز" || C == "Tabriz")
        {
            URLCity = "6";
        }
        else if (C == "اردبیل" || C == "Ardabil")
        {
            URLCity = "26";
        }
        else if (C == "همدان" || C == "Hamadan")
        {
            URLCity = "24";
        }
        else if (C == "کردستان" || C == "Kurdistan")
        {
            URLCity = "22";
        }
        else if (C == "زنجان" || C == "Zanjan")
        {
            URLCity = "25";
        }
        else if (C == "قزوین" || C == "Qazvin")
        {
            URLCity = "10";
        }
        else if (C == "گیلان" || C == "Gilan" || C == "رشت")
        {
            URLCity = "16";
        }
        else if (C == "مازندران" || C == "Mazandran" || C == "ساری")
        {
            URLCity = "17";
        }
        else if (C == "کرج" || C == "البرز" || C == "Alborz")
        {
            URLCity = "9";
        }
        else if (C == "گلستان" || C == "گرگان" || C == "Golstan")
        {
            URLCity = "18";
        }
        else if (C == "سمنان" || C == "Semnan")
        {
            URLCity = "27";
        }
        else if (C == "قم" || C == "Qom")
        {
            URLCity = "11";
        }
        else if (C == "خراسان شمالی" || C == "بجنورد" || C == "Khorasane Shomali")
        {
            URLCity = "15";
        }
        else if (C == "خراسان رضوی" || C == "مشهد" || C == "Khorasane Razavi")
        {
            URLCity = "13";
        }
        else if (C == "اراک" || C == "مرکزی" || C == "Arak")
        {
            URLCity = "4";
        }
        else if (C == "اصفحان" || C == "Esfahan")
        {
            URLCity = "2";
        }
        else if (C == "یزد" || C == "Yazd")
        {
            URLCity = "14";
        }
        else if (C == "خراسان جنوبی" || C == "بیرجند" || C == "Khorasane Jonobi")
        {
            URLCity = "827";
        }
        else if (C == "کرمان" || C == "Kerman")
        {
            URLCity = "19";
        }
        else if (C == "سیستان و بلوچستان" || C == "Zahedan")
        {
            URLCity = "12";
        }
        else if (C == "کرمانشاه" || C == "Kermanshah")
        {
            URLCity = "21";
        }
        else if (C == "لرستان" || C == "خرم آباد" || C == "Lorstan")
        {
            URLCity = "30";
        }
        else if (C == "ایلام" || C == "Ilam")
        {
            URLCity = "29";
        }
        else if (C == "خوزستان" || C == "اهواز" || C == "Ahvaz")
        {
            URLCity = "5";
        }
        else if (C == "چهارمحال و بختیاری" || C == "Chaharmahal va Bakhtiari")
        {
            URLCity = "382";
        }
        else if (C == "یاسوج" || C == "کهگیلویه و بویراحمد" || C == "Lorstan")
        {
            URLCity = "32";
        }
        else if (C == "فارس" || C == "شیراز" || C == "Fars")
        {
            URLCity = "8";
        }
        else if (C == "بندرعباس" || C == "هرمزگان" || C == "Bandarabbas")
        {
            URLCity = "7";
        }
        else if (C == "بوشهر" || C == "Bushehr")
        {
            URLCity = "20";
        }
        else
        {
            return;
        }
        WebClient client = new WebClient();
        string DataBot = client.DownloadString($"https://prayer.aviny.com/api/prayertimes/{URLCity}");
        var item = JsonConvert.DeserializeObject<Infomation>(DataBot);
        CityName = item.CityName;
        Imsaak = item.Imsaak;
        Sunrise = item.Sunrise;
        Noon = item.Noon;
        Sunset = item.Sunset;
        Maghreb = item.Maghreb;
    }
}
public class Infomation
{
    public string CityName { get; set; }
    public string Imsaak { get; set; }
    public string Sunrise { get; set; }
    public string Noon { get; set; }
    public string Sunset { get; set; }
    public string Maghreb { get; set; }
}
