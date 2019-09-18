using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Encryption_Task7
{
    internal class DataPharser
    {
        public string getMessage(string filePath)
        {
            using (StreamReader stream = new StreamReader(filePath, Encoding.Default))
            {
                var tmp = stream.ReadToEnd();
                char[] eng = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'V', 'X', 'Y', 'Z' };
                List<string> message = tmp.Split().ToList();
                string result = "";
                foreach (var item in message)
                {
                    if (!string.IsNullOrEmpty(item) && !eng.Contains(char.ToUpper(item[0])))
                    {
                        result += item + " ";
                    }
                }
                return result.ToUpper().Trim(' ');
            }
        }

        public string getKey()
        {
            using (StreamReader stream = new StreamReader("Key.txt", Encoding.Default))
            {
                return stream.ReadLine().ToUpper();
            }
        }

        public Dictionary<int, char> GetAlphabet()
        {
            Dictionary<int, char> result = new Dictionary<int, char>();
            using (StreamReader stream = new StreamReader("Alphabet.txt", Encoding.Default))
            {
                char[] alphabet = stream.ReadToEnd().ToCharArray();
                for (int i = 0; i < alphabet.Length; i++)
                {
                    result.Add(i, alphabet[i]);
                }
            }
            return result;
        }

        public int GetSymbolCode(char symbol)
        {
            int result = 0;
            foreach (var item in GetAlphabet())
            {
                if (symbol == item.Value)
                {
                    result = item.Key;
                }
                else
                {
                    continue;
                }
            }
            return result;
        }
    }
}