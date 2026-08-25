using CSharp.Mastery.ControlFlowAndLoops.Models;

namespace CSharp.Mastery.ControlFlowAndLoops.Services;

public class AtmMachineService
{
    private AtmState _currentState = AtmState.Idle;
    private BankAccount _currentAccount = new BankAccount(); // Simüle edilmiş veritabanı kaydı
    private int _pinTries = 0;

    public void StartEngine()
    {
        Console.WriteLine("ATM Sistemine Hoş Geldiniz...");
        
        // Sonsuz Döngü - Sistem fişten çekilene veya Exit state'ine girene kadar çalışır.
        while (true)
        {
            switch (_currentState)
            {
                case AtmState.Idle:
                    ProcessIdleState();
                    break;
                case AtmState.CardInserted:
                    ProcessCardInsertedState();
                    break;
                case AtmState.PinEntered:
                case AtmState.TransactionMenu:
                    ProcessTransactionMenu();
                    break;
                case AtmState.Exiting:
                    Console.WriteLine("\nLütfen kartınızı almayı unutmayınız. İyi günler dileriz.");
                    return; // Metodu ve sonsuz döngüyü tamamen sonlandırır (Program kapanır).
            }
        }
    }

    private void ProcessIdleState()
    {
        Console.WriteLine("\n[Lütfen Kartınızı Takınız - Takmak için 'T', Kapatmak için 'Q' tuşuna basın]");
        string input = Console.ReadLine()?.ToUpper() ?? "";

        if (input == "Q")
        {
            _currentState = AtmState.Exiting;
        }
        else if (input == "T")
        {
            _currentState = AtmState.CardInserted;
        }
        else
        {
            Console.WriteLine("Geçersiz giriş!");
        }
    }

    private void ProcessCardInsertedState()
    {
        Console.WriteLine($"\n[Kart Okundu - Kalan şifre hakkınız: {3 - _pinTries}] Lütfen 4 Haneli PIN kodunuzu giriniz:");
        string input = Console.ReadLine() ?? "";

        if (input == _currentAccount.PinCode)
        {
            Console.WriteLine("Şifre doğru. Giriş yapılıyor...");
            _pinTries = 0;
            _currentState = AtmState.TransactionMenu;
        }
        else
        {
            _pinTries++;
            Console.WriteLine("Hatalı Şifre!");

            if (_pinTries >= 3)
            {
                Console.WriteLine("Kartınız bloke olmuştur. Bankanızla iletişime geçiniz.");
                _currentState = AtmState.Exiting;
            }
        }
    }

    private void ProcessTransactionMenu()
    {
        Console.WriteLine("\n--- İŞLEM MENÜSÜ ---");
        Console.WriteLine("1. Bakiye Sorgulama");
        Console.WriteLine("2. Para Çekme");
        Console.WriteLine("3. Kart İade (Çıkış)");
        Console.Write("Seçiminiz: ");
        
        string input = Console.ReadLine() ?? "";

        if (input == "1")
        {
            Console.WriteLine($"Mevcut Bakiyeniz: {_currentAccount.Balance:C}");
            // İşlem bitince menüye tekrar dönmek için break ile switch/if dışına çıkılır, döngü başa sarar.
        }
        else if (input == "2")
        {
            Console.Write("Çekmek istediğiniz tutarı giriniz: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Geçersiz tutar.");
                    return; // Gelişmiş senaryolarda alt döngüler kullanılabilir. Burada basitleştirildi.
                }

                if (amount > _currentAccount.Balance)
                {
                    Console.WriteLine("Yetersiz bakiye.");
                }
                else
                {
                    _currentAccount.Balance -= amount;
                    Console.WriteLine($"İşlem başarılı. Lütfen paranızı alınız. Yeni Bakiyeniz: {_currentAccount.Balance:C}");
                }
            }
            else
            {
                Console.WriteLine("Lütfen geçerli bir sayısal değer giriniz.");
            }
        }
        else if (input == "3")
        {
            _currentState = AtmState.Exiting;
        }
        else
        {
            Console.WriteLine("Hatalı seçim.");
        }
    }
}
