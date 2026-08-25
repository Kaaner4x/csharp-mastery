using System;
using _16_MemoryManagement.Services;

namespace _16_MemoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Memory Management & IDisposable Demo");
            
            // Simüle edilecek dosya yolu
            string dummyFilePath = "server_logs.txt";
            
            // Dummy dosya oluşturalım
            System.IO.File.WriteAllText(dummyFilePath, "Log 1: System started\nLog 2: User login\nLog 3: Error 500");

            // 'using' declaration (C# 8.0+)
            using var reader = new LargeFileReader(dummyFilePath);
            reader.ProcessLines();
            
            Console.WriteLine("File processing completed. Unmanaged resources are safely released.");
            
            // GC'yi manuel tetiklemek (Genelde gerçek projelerde tavsiye edilmez, demo amaçlıdır)
            GC.Collect();
            Console.WriteLine("Garbage Collection triggered manually.");
        }
    }
}
