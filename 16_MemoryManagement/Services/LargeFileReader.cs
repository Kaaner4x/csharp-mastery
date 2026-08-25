using System;
using System.IO;

namespace _16_MemoryManagement.Services
{
    public class LargeFileReader : IDisposable
    {
        private StreamReader? _streamReader;
        private bool _disposed = false; // To detect redundant calls

        public LargeFileReader(string filePath)
        {
            Console.WriteLine($"[LargeFileReader] Opening file: {filePath}");
            _streamReader = new StreamReader(filePath);
        }

        public void ProcessLines()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(LargeFileReader));

            string? line;
            while ((line = _streamReader?.ReadLine()) != null)
            {
                // Ağır işlem simülasyonu
                Console.WriteLine($"Processing: {line}");
            }
        }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Managed state (managed objects) temizliği.
                    if (_streamReader != null)
                    {
                        Console.WriteLine("[LargeFileReader] Disposing managed resources (StreamReader).");
                        _streamReader.Dispose();
                        _streamReader = null;
                    }
                }

                // Unmanaged resources (unmanaged objects) temizliği burada yapılır (eğer varsa).
                // ...
                _disposed = true;
            }
        }

        // Yıkıcı (Destructor / Finalizer) - Sadece unmanaged kaynaklar doğrudan bu sınıftaysa gereklidir.
        ~LargeFileReader()
        {
            Dispose(false);
        }
    }
}
