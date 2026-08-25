using CSharp.Mastery.ControlFlowAndLoops.Services;

namespace CSharp.Mastery.ControlFlowAndLoops;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Modül 3: Kontrol Akışları ve Döngüler ===");

        // State Machine tabanlı ATM Sistemi başlatılıyor.
        // Konsol uygulaması, kullanıcı kapatma komutu verene kadar çalışmaya devam edecek.
        var atmMachine = new AtmMachineService();
        atmMachine.StartEngine();
        
        Console.WriteLine("Sistem kapandı.");
    }
}
