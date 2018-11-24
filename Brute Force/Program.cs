using System;

namespace Brute_Force
{
    class Program
    {
        static void Main(string[] args)
        {
            int minimum_letters = 4;
            int maximum_letters = 8;
            Hacker_1 hacker = new Hacker_1(minimum_letters, maximum_letters);
            hacker.HackZipFile_3(@"E:\Github\Brute_Force\Brute Force\FileVault.zip", @"E:\Results");
        }
    }
}
