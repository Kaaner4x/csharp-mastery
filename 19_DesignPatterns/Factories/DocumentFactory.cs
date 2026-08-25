using System;
using _19_DesignPatterns.Models;

namespace _19_DesignPatterns.Factories
{
    public static class DocumentFactory
    {
        public static IDocument CreateDocument(string type)
        {
            return type.ToLower() switch
            {
                "invoice" => new InvoiceDocument(),
                "report" => new ReportDocument(),
                _ => throw new ArgumentException("Invalid document type", nameof(type))
            };
        }
    }
}
