using System;
using System.Text;

namespace VigenerCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            bool end = false;

            CipherAlgorithm algorithm = new CipherAlgorithm();

            while (!end)
            {
                Console.WriteLine("****************************************************************");
                Console.WriteLine("Menue:\n" +
                    "[1] Encrypt a Plain Text.\n" +
                    "[2] Decrypt a Cipher Text.\n" +
                    "[3] Exit.");
                Console.Write("Please Enter Your Choice: ");
                Console.WriteLine();

                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    String Key;
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter the Plain Text: ");
                            String PlainText = Console.ReadLine();
                            Console.Write("Enter the Key: ");
                            Key = Console.ReadLine();
                            
                            Console.WriteLine("\n\nThe Encryption of " + PlainText + " is:\n" + algorithm.Encrypt(PlainText, Key) + "\n\n");

                            break;
                        case 2:
                            Console.Write("Enter the Cipher Text: ");
                            String CipherText = Console.ReadLine();
                            Console.Write("Enter the Key: ");
                            Key = Console.ReadLine();

                            Console.WriteLine("\n\nThe Decryption of " + CipherText + " is:\n" + algorithm.Decrypt(CipherText, Key) + "\n\n");

                            break;
                        case 3:
                            Console.WriteLine("Thank You...\nDeveloped By: MUSAB EYAD :(");
                            end = true;
                            break;
                        default:
                            Console.WriteLine("Please choose a number [1-3]");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please Enter a Valid Number.");
                    continue;
                }
            }
        }
    }
}
