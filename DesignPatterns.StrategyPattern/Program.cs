

#region Example 1 : Game Character

//var ch = new Character(new AgressiveCombatStrategy());
//ch.ApplyAttackStrategy();

////2. adımında defansif bir atak uygulansın.
//ch.SetCombatStrategey(new DeffensiveCombatStrategy());
//ch.ApplyAttackStrategy();

//Console.ReadLine();



// Srategy Design Pattern - Behavioral Category
//Bir nesne, oyun karakteri, API ölmesine gerek kalmadan davranışını değiştirebilmeyi sağlayan tasarım kalıbı  Strategy Patterndir.

//Karakter ilk oluştuğunda agresif bir atak uygulasın.

// Srategy Design Pattern - Behavioral Category
//Bir nesne, oyun karakteri, API ölmesine gerek kalmadan davranışını değiştirebilmeyi sağlayan tasarım kalıbı  Strategy Patterndir.

//Karakter ilk oluştuğunda agresif bir atak uygulasın.


var paymentOptions = new PaymentOptions()
{
  CardNumber = "1234567123456",
  CardHolderName = "Ali Yılmaz",
  ExpirationDate = "12/25",
  Cvv = "123",
  Amount = 1000
};


var paymentService = new PaymentService();

do
{
  Console.WriteLine("Ödeme yapılacak bankayı seçiniz (1:Garanti, 2: Yapı Kredi, 3: İş Bankası): ");
  var bank = Console.ReadLine();
  IPaymentService bankPaymentService = null;
  //Stratejiyi belirle --------------------------------------
  switch (bank)
  {
    case "1":
      bankPaymentService = new GarantiBankasıPaymentService();
      break;
    case "2":
      bankPaymentService = new YKBPaymentService();
      break;
    case "3":
      bankPaymentService = new IsBankasıPaymentService();
      break;
    default:
      Console.WriteLine("Geçersiz banka seçimi");
      break;
  }
  paymentService.SetPaymentService(bankPaymentService);
  //-------------------------------------------------------
  //Ödemeyi Yap
  paymentService.PayViaStrategy(paymentOptions);

} while (Console.ReadKey().Key != ConsoleKey.Escape);



class Character
{
  private ICombatStrategy combatStrategy;

  public Character(ICombatStrategy combatStrategy)
  {
    this.combatStrategy = combatStrategy;
  }

  public Character()
  {

  }

  public void SetCombatStrategey(ICombatStrategy combatStrategy)
  {
    this.combatStrategy = combatStrategy;
  }

  public void ApplyAttackStrategy()
  {
    combatStrategy.Attack();
  }
}

interface ICombatStrategy
{
  void Attack();
}

class AgressiveCombatStrategy : ICombatStrategy
{
  public void Attack()
  {
    Console.WriteLine("Agressive Attack!");
  }
}

class DeffensiveCombatStrategy : ICombatStrategy
{
  public void Attack()
  {
    Console.WriteLine("Deffensive Attack!");
  }
}

#endregion



#region Example 2 : Payment Systems

interface IPaymentService
{
  bool Pay(PaymentOptions paymentOptions);
}

public class PaymentOptions
{
  public string CardNumber { get; set; }
  public string CardHolderName { get; set; }
  public string ExpirationDate { get; set; }
  public string Cvv { get; set; }
  public decimal Amount { get; set; }
}

class PaymentService
{
  private IPaymentService _paymentService;

  public PaymentService()
  {

  }
  public PaymentService(IPaymentService paymentService)
  {
    this._paymentService = paymentService;
  }

  public void SetPaymentService(IPaymentService paymentService)
  {
    this._paymentService = paymentService;
  }
  public bool PayViaStrategy(PaymentOptions paymentOptions)
  {
    return _paymentService.Pay(paymentOptions);
  }
}

//Strategy 1
public class YKBPaymentService : IPaymentService
{
  public bool Pay(PaymentOptions paymentOptions)
  {
    Console.WriteLine("YKB ile ödeme yapıldı.");
    return true;
  }
}

//Strategy 2
public class GarantiBankasıPaymentService : IPaymentService
{
  public bool Pay(PaymentOptions paymentOptions)
  {
    Console.WriteLine("GarantiBankası ile ödeme yapıldı.");
    return true;
  }
}

//Strategy 3
public class IsBankasıPaymentService : IPaymentService
{
  public bool Pay(PaymentOptions paymentOptions)
  {
    Console.WriteLine("IsBankası ile ödeme yapıldı.");
    return true;
  }
}





#endregion


