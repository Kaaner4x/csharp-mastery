namespace EscapeCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Metinsel ifade içinde \"Çift tırnak\" kullanımı örneğidir.");
            Console.WriteLine("Metinsel ifade içinde \'Tek tırnak\' kullanımı örneğidir.");
            Console.WriteLine("Metinsel ifade içinde \\Ters eğik çizgi\\ kullanımı örneğidir.");
            Console.WriteLine("Paragrafın birinci satırıdır.\nParagrafın ikinci satırıdır.");
            Console.WriteLine("İmleci satır başına getirir.\r:D");
            Console.WriteLine("Bir \ttab boşluk bırakır.");
            Console.WriteLine("Bu birinci \bmetinsel ifadedir.");
            Console.WriteLine("Bu ikinci \vmetinsel ifadedir.");
            Console.WriteLine("Bu bir uyarı \asesidir");
            Console.WriteLine("Metinsel ifadeyi sonlandırır ya da null karakteri ekler: \0");

            /* Ek olarak string başında '@' (verbatim string) kullanarak kaçış
               devre dışı bırakabiliriz. Kaçış karakterleri ve verbatim string
               genellikle dosya yolunu belirtmek için kullanılır.
            */
        }
    }
}
