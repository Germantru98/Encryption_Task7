using System;

namespace Encryption_Task7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DataPharser dp = new DataPharser();
            EncryptionTools tools = new EncryptionTools();
            Console.WriteLine("Исходное сообщение:" + dp.getMessage("Message.txt"));
            Console.WriteLine("Код сообщения:");
            var message = tools.Encrypt("Message.txt");
            foreach (var item in message)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\nРезультат декодирования: " + tools.Decrypt(message));
        }
    }
}