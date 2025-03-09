using System;
namespace Web_6.Data
{
    public class Encrypter
    {
        public int Key { get; private set; } = 3;

        public Encrypter(int? k)
        {
              if(k.HasValue)
                  Key = k.Value;
        } 
        public string Encrpyt(string pass)
        {
            int n = pass.Length;
            char[] result = new char[n];

            for (int i = 0; i < n; i++)
            {
                if (char.IsLetter(pass[i]))
                {
                    char c = char.IsUpper(pass[i]) ? 'A' : 'a';
                    result[i] = (char)(((pass[i] - c) - Key + 26) % 26 + c);
                }
                else
                    result[i] = pass[i];
            }

            return new string(result);
        }

        public string Decrpyt(string pass)
        {
            int n = pass.Length;
            char[] result = new char[n];

            for (int i = 0; i < n; i++)
            {
                if (char.IsLetter(pass[i]))
                {
                    char c = char.IsUpper(pass[i]) ? 'A' : 'a';
                    result[i] = (char)((pass[i] - c + Key) % 26 + c);
                }
                else
                    result[i] = pass[i];
            }

            return new string(result);
        }

    }
}
