using System;

namespace _19_DesignPatterns.Models
{
    public interface IDocument
    {
        void Print();
    }

    public class InvoiceDocument : IDocument
    {
        public void Print()
        {
            Console.WriteLine("[Document] Printing Invoice... Amount: $1000");
        }
    }

    public class ReportDocument : IDocument
    {
        public void Print()
        {
            Console.WriteLine("[Document] Printing Monthly Report... Status: Green");
        }
    }
}
