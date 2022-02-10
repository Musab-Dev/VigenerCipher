using System;
using System.Collections.Generic;
using System.Text;

namespace VigenerCipher
{
    class CipherAlgorithm
    {
        static char[] characterSet = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                                                  'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' '};
        static int numOfchars = characterSet.Length;

        private char[] GenerateKeyStream(String Key, int Length)
        {
            // repeat the key until the keystream have the same length as the plaintext
            String KeyStream = "";
            while (KeyStream.Length < Length)
            {
                KeyStream += new StringBuilder().Insert(0, Key, 1).ToString();
            }
            return KeyStream.ToCharArray();
        }

        private int GetIndexOfChar(char character)
        {            
            for (int i = 0; i < numOfchars; i++)
            {
                if (character == characterSet[i])
                    return i;
            }
            return -1; // character not found
        }

        private char GetCharAt(int index)
        {
            return characterSet[index];
        }

        public String Encrypt(String PlainText, String Key)
        {
            char[] KeyStream = GenerateKeyStream(Key, PlainText.Length);
            String CipherText = "";
            for (int i = 0; i < PlainText.Length; i++)
            {
                int PlainCharIndex = GetIndexOfChar(PlainText[i]);
                int KeyCharIndex = GetIndexOfChar(KeyStream[i]);
                int CipherCharIndex = (PlainCharIndex + KeyCharIndex) % numOfchars;
                CipherText += GetCharAt(CipherCharIndex);
            }
            return CipherText;
        }

        public String Decrypt(String CipherText, String Key)
        {
            char[] KeyStream = GenerateKeyStream(Key, CipherText.Length);
            String PlainText = "";
            for (int i = 0; i < CipherText.Length; i++)
            {
                int CipherCharIndex = GetIndexOfChar(CipherText[i]);
                int KeyCharIndex = GetIndexOfChar(KeyStream[i]);
                int PlainCharIndex;
                if ((CipherCharIndex - KeyCharIndex) >= 0)
                    PlainCharIndex = (CipherCharIndex - KeyCharIndex) % numOfchars;
                else
                    PlainCharIndex = numOfchars - (-(CipherCharIndex - KeyCharIndex) % numOfchars);
                PlainText += GetCharAt(PlainCharIndex);
            }
            return PlainText;
        }
    }
}
