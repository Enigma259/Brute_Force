using System;

namespace Brute_Force
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to the the Brute_Force program");
            Console.WriteLine("We will try to hack a password protected zip file.");
            Console.WriteLine("if success we will give you the password for the file.");
            Console.WriteLine("Press enter to start.");
            Console.ReadLine();
            Console.Read();

            int minimum_letters = 4;
            int maximum_letters = 8;
            Hacker_1 hacker = new Hacker_1(minimum_letters, maximum_letters);
            hacker.HackZipFile_3("FileVault.zip", "E:\\Results");
        }
    }
}
