// See https://aka.ms/new-console-template for more information
using DesignPatterns.StrategyPattern.Models;

//1.Kullanım

//Console.WriteLine("Başlangıç: " + DateTime.Now.ToLongTimeString());
//var countryProvider = new CountryProvider();

//var countries = await countryProvider.GetCountries();
//foreach (var item in countries)
//{
//  Console.WriteLine(item.Name);
//}

////Another Service
//var countryProvider2 = new CountryProvider();
//var countries2 = await countryProvider.GetCountries();
//Console.WriteLine("Bitiş: " + DateTime.Now.ToLongTimeString());


//2) Daha güzeli
Console.WriteLine("Başlangıç: " + DateTime.Now.ToLongTimeString());
var countryProvider = new CountryProvider();
var countries = await CountryProvider.Instance.GetCountries();

foreach (var item in countries)
{
  Console.WriteLine(item.Name);
}

//Another Service
var countryProvider2 = new CountryProvider();
var countries2 = await CountryProvider.Instance.GetCountries();
Console.WriteLine("Bitiş: " + DateTime.Now.ToLongTimeString());

Console.ReadLine();

