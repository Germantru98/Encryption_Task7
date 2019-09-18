using System;
using System.Collections.Generic;

namespace Encryption_Task7
{
    internal class EncryptionTools
    {
        private DataPharser _data = new DataPharser();

        public List<int> Encrypt(string filePath)
        {
            var result = new List<int>();
            var message = _data.getMessage(filePath);
            var key = _data.getKey();
            int flag = 0;
            for (int i = 0; i < message.Length; i++)
            {
                if (flag == key.Length)
                {
                    flag = 0;
                }
                var tmp = _data.GetSymbolCode(message[i]) + _data.GetSymbolCode(key[flag]);
                result.Add(tmp);
                flag++;
            }
            return result;
        }

        public string Decrypt(List<int> message)
        {
            var alphabet = _data.GetAlphabet();
            var key = _data.getKey();
            int flag = 0;
            string result = "";
            for (int i = 0; i < message.Count; i++)
            {
                if (flag == key.Length)
                {
                    flag = 0;
                }
                result += alphabet[Math.Abs(message[i] - _data.GetSymbolCode(key[flag]))];
                flag++;
            }
            return result;
        }
    }
}