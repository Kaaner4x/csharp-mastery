namespace Variables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte number1 = 70;
            sbyte number2 = -100;
            short number3 = 30122;
            ushort number4 = 52130;
            int number5 = 16134242;
            uint number6 = 51234234;
            long number7 = 9223372036854775807;
            ulong number8 = 12513451341235134;
            float number9 = 3.40282347E+38f;
            double number10 = 1.7976932E+305;
            decimal number11 = 79228162514264337593543950335m;
            char character = 'A';
            bool isCorrect = true;
            string message = "Bu örnek bir mesajdır.";
            var inferredNumber = 23;

            /* String Interpolation: Bir metinsel ifadeden önce "$" karakteri ekleyerek değişkenlerin ve
            ifadelerin doğrudan metin içinde kullanılmasını sağlar. */

            Console.WriteLine($"number1 is {number1}\n" +
                              $"number2 is {number2}\n" +
                              $"number3 is {number3}\n" +
                              $"number4 is {number4}\n" +
                              $"number5 is {number5}\n" +
                              $"number6 is {number6}\n" +
                              $"number7 is {number7}\n" +
                              $"number8 is {number8}\n" +
                              $"number9 is {number9}\n" +
                              $"number10 is {number10}\n" +
                              $"number11 is {number11}\n" +
                              $"character is {character}\n" +
                              $"Condition is {isCorrect}\n" +
                              $"Message: {message}\n" +
                              $"InferrredNumber is {inferredNumber}");

            /* 
             < İsimlendirme kuralları >
                camelCase
                PascalCase
                snake_case
                UPPER_SNAKE_CASE
             */
        }
    }
}
