using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO.Compression;

namespace Brute_Force
{
    /// <summary>
    /// 
    /// </summary>
    public class Hacker_1
    {
        private List<string> letters;
        private int minimum_letters;
        private int maximum_letters;
        private List<int> index_Letters;
        private string file_path;
        private string destination_path;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minimum_letters"></param>
        /// <param name="maximum_letters"></param>
        public Hacker_1(int minimum_letters, int maximum_letters)
        {
            if (minimum_letters < 0)
            {
                this.minimum_letters = 0;
            }

            else
            {
                this.minimum_letters = minimum_letters;
            }


            if (maximum_letters <= 0)
            {
                this.minimum_letters = 1;
            }

            else
            {
                this.maximum_letters = maximum_letters;
            }

            this.letters = new List<string>();
            this.index_Letters = new List<int>();

            SetLetters();
            SetIndexLetters();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minimum_letters"></param>
        public void SetMinimumLetters(int minimum_letters)
        {
            this.minimum_letters = minimum_letters;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maximum_letters"></param>
        public void SetMaximumLetters(int maximum_letters)
        {
            this.maximum_letters = maximum_letters;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetLetters()
        {
            //Lowercase letters
            letters.Add("");
            letters.Add("a");
            letters.Add("b");
            letters.Add("c");
            letters.Add("d");
            letters.Add("e");
            letters.Add("f");
            letters.Add("g");
            letters.Add("h");
            letters.Add("i");
            letters.Add("j");
            letters.Add("k");
            letters.Add("l");
            letters.Add("m");
            letters.Add("n");
            letters.Add("o");
            letters.Add("p");
            letters.Add("q");
            letters.Add("r");
            letters.Add("s");
            letters.Add("t");
            letters.Add("u");
            letters.Add("v");
            letters.Add("w");
            letters.Add("x");
            letters.Add("y");
            letters.Add("z");

            //Uppercase Letters
            letters.Add("A");
            letters.Add("B");
            letters.Add("C");
            letters.Add("D");
            letters.Add("E");
            letters.Add("F");
            letters.Add("G");
            letters.Add("H");
            letters.Add("I");
            letters.Add("J");
            letters.Add("K");
            letters.Add("L");
            letters.Add("M");
            letters.Add("N");
            letters.Add("O");
            letters.Add("P");
            letters.Add("Q");
            letters.Add("R");
            letters.Add("S");
            letters.Add("T");
            letters.Add("U");
            letters.Add("V");
            letters.Add("W");
            letters.Add("X");
            letters.Add("Y");
            letters.Add("Z");

            //Numbers
            letters.Add("0");
            letters.Add("1");
            letters.Add("2");
            letters.Add("3");
            letters.Add("4");
            letters.Add("5");
            letters.Add("6");
            letters.Add("7");
            letters.Add("8");
            letters.Add("9");
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetIndexLetters()
        {
            while (GetIndexLetters().Count < GetMaximumLetters())
            {
                if (GetIndexLetters().Count <= GetMinimumLetters())
                {
                    GetIndexLetters().Add(1);
                }

                else
                {
                    GetIndexLetters().Add(0);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath"></param>
        public void SetFilePath(string file_path)
        {
            this.file_path = file_path;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="destination"></param>
        public void SetDestinationPath(string destination)
        {
            this.destination_path = destination;
        }

        /// <summary>
        /// 
        /// </summary>
        public void IncreaseIndexLetter()
        {
            int index;
            bool increasing;
            if (GetIndexLetters()[maximum_letters - 1] < GetLetters().Count && GetIndexLetters()[0] > 0)
            {
                index = 0;
                increasing = true;

                while (increasing && index < GetMaximumLetters() - 1)
                {
                    if (GetIndexLetters()[index] == GetLetters().Count - 1)
                    {
                        GetIndexLetters()[index] = 1;
                        index++;
                    }

                    else
                    {
                        GetIndexLetters()[index]++;
                        increasing = false;
                    }
                }
            }

            else
            {
                index = 0;

                while (index < GetIndexLetters().Count)
                {
                    GetIndexLetters()[index] = 0;
                    index++;
                }
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetMinimumLetters()
        {
            return minimum_letters;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetMaximumLetters()
        {
            return maximum_letters;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<int> GetIndexLetters()
        {
            return index_Letters;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> GetLetters()
        {
            return letters;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetFilePath()
        {
            return file_path;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetDestinationPath()
        {
            return destination_path;
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        public void HackZipFile_1()
        {
            string result = "";
            string current_password = PasswordGuess();
            bool found_password = false;

            Console.WriteLine("Hello World");
            Console.WriteLine("Will crack zip file where the password is between " + GetMinimumLetters() + " and " + GetMaximumLetters());

            ZipArchive zipfile = ZipFile.OpenRead("Passwords.zip");

            Console.WriteLine(zipfile);
            Console.WriteLine("press enter to start");

            Console.ReadLine();
            Console.Read();

            while (found_password.Equals(false) && !current_password.Equals(""))
            {
                Console.WriteLine(current_password);

                found_password = zipfile.Entries.GetType().GetMember("Password").Equals(current_password);

                if (found_password)
                {
                    result = current_password;
                }

                else
                {
                    current_password = PasswordGuess();
                }
            }

            if (found_password)
            {
                Console.WriteLine("Here is the password: " + result);
            }

            else
            {
                Console.WriteLine("Could not find the password with the given parameters");
            }

            Console.ReadLine();
            Console.Read();
        }
        */

        public void HackZipFile_2()
        {
            string result = "";
            string current_password = PasswordGuess();
            bool found_password = false;
            string zipFile = @GetFilePath();
            string targetDirectory = @"D:\Cloud\OneDrive - University College Nordjylland\Opgaver\UCN 2.0\2. Semester\Security";

            Console.WriteLine("Hello World");
            Console.WriteLine("Will crack zip file where the password is between " + GetMinimumLetters() + " and " + GetMaximumLetters());

            while (found_password.Equals(false) && !current_password.Equals(""))
            {
                Console.WriteLine(current_password);

                try
                {
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(zipFile))
                    {
                        zip.Password = current_password;
                        zip.ExtractAll(targetDirectory, Ionic.Zip.ExtractExistingFileAction.DoNotOverwrite);
                        result = current_password;
                        found_password = true;
                    }
                }

                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    current_password = PasswordGuess();
                    break;
                }
            }

            if (found_password)
            {
                Console.WriteLine("Here is the password: " + result);
            }

            else
            {
                Console.WriteLine("Could not find the password with the given parameters");
            }

            Console.ReadLine();
            Console.Read();
        }

        public void HackZipFile_3(string file_path, string destination_path)
        {
            string result = "";
            string current_password;
            bool found_password = false;
            SetFilePath(file_path);
            SetDestinationPath(destination_path);

            Console.WriteLine("Start cracking zip file.");
            Console.WriteLine("Source: " + GetFilePath());
            Console.WriteLine("Destination: " + GetDestinationPath());


            while (found_password.Equals(false) && GetIndexLetters()[0] != 0)
            {
                current_password = PasswordGuess();

                try
                {
                    using (Ionic.Zip.ZipFile zip = Ionic.Zip.ZipFile.Read(GetFilePath()))
                    {
                        zip.Password = current_password;
                        zip.ExtractAll(GetDestinationPath(), ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                
                catch(BadPasswordException bad_password)
                {
                    Console.WriteLine(bad_password.Message);
                }

                if(result != "")
                {
                    found_password = true;
                }
            }

            if(found_password)
            {
                Console.WriteLine("The Password for this zipfile: " + result);
            }

            else
            {
                Console.WriteLine("Could not guess the password.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int FinishNumber()
        {
            int result;
            result = GetLetters().Count * GetLetters().Count;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string PasswordGuess()
        {
            string result = "";

            if(GetIndexLetters()[0] > 0)
            {
                foreach (int current_index in GetIndexLetters())
                {
                    if (current_index < GetLetters().Count)
                    {
                        result += GetLetters()[current_index];
                    }

                    else
                    {
                        break;
                    }
                }
            }

            IncreaseIndexLetter();
            return result;
        }


    }
}