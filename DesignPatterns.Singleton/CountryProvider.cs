using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StrategyPattern.Models
{
  //Metot 2. kez çağırılıyor ve aynı veri için db'ye 2 kez gidiliyor.Arada 4 sn geçiyor.Burada bu zaman aralığını düşürebilir ve aynı veri tekrardan dbye gitmemize gerek kalmayacak şekilde singleton pattern kullanabiliriz.

  // 1) 1. yöntem
  //public class CountryProvider
  //{
  //  public async Task<List<Country>> GetCountries() 
  //  {
  //    //Retrieving data from db 
  //    await Task.Delay(2000);

  //    return new List<Country>
  //    {
  //       new Country(){Name = "Türkiye"},
  //       new Country(){Name = "Kanada"}
  //    };
  //  }
  //}

  //2)***Bu instance ilk  eriştiğimde create edilsin
  public class CountryProvider
  {
    private static CountryProvider instance = null; 
    public static CountryProvider Instance {

      get
      {
          //Tek yaratıldığından emin olalım.
          if(instance is not null)
            return instance;
          else
           return instance = new CountryProvider();

      } 
      set { instance = value; } 
    }

    public async Task<List<Country>> GetCountries()
    {
      //Retrieving data from db 
      await Task.Delay(2000);

      return new List<Country>
      {
         new Country(){Name = "Türkiye"},
         new Country(){Name = "Kanada"}
      };
    }
  }
}
