using System;
using System.Collections.Generic;

namespace Brute_Force
{
    class Program
    {
        private static int minimum;
        private static int maximum;
        private static List<string> letters;

        static void Main(string[] args)
        {
            minimum = 4;
            maximum = 8;

            Console.WriteLine("Hello and welcome to the the Brute_Force program");
            Console.WriteLine("We will try to hack a password protected zip file.");
            Console.WriteLine("if success we will give you the password for the file.");

            Console.WriteLine("Press enter to start cracking the zip");
            Console.Read();

            Hacker_1 hacker = new Hacker_1(minimum, maximum);
            hacker.HackZipFile_3("FileVault.zip", "D:\\Cloud\\Dropbox\\Skærmbilleder");
        }
    }
}
