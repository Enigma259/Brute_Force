using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brute_Force
{
    class Hacker_2
    {
        private readonly List<char> _charList;
        private readonly int[] _currentPassword;
        private readonly string _endPassword;

        public Hacker_2(List<char> charList, string startPassword, string endPassword)
        {
            _charList = charList;
            _endPassword = endPassword;

            var passwordLength = Math.Max(startPassword.Length, endPassword.Length);

            _currentPassword = startPassword.Select(c => _charList.IndexOf(c)).ToArray();

            while (_currentPassword.Length != passwordLength)
            {
                _currentPassword = _currentPassword.Concat(new[] { 0 }).ToArray();
            }
        }

        public string CalculatePassword()
        {
            while (true)
            {
                var password = GetPasswordAsString();

                try
                {
                    if (ZipFile.CheckZipPassword(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\FileVault.zip", password))
                    {
                        return password;
                    }
                }
                catch (BadCrcException)
                {
                    // For some reason, sometimes a BadCRCException is thrown.
                    // I have never had it thrown on the real password,
                    // but this may be an issue for that.
                    // My best guess is that the speed of access the file,
                    // or perhaps accessing it from multiple threads, is the issue
                }

                if (password == _endPassword) { break; }

                CalculateNextPassword();
            }

            return null;
        }

        private void CalculateNextPassword()
        {
            for (var index = _currentPassword.Length - 1; index >= 0; index--)
            {
                if (_currentPassword[index] == _charList.Count - 1)
                {
                    _currentPassword[index] = 0;
                    continue;
                }

                _currentPassword[index]++;
                break;
            }
        }

        private string GetPasswordAsString()
        {
            return new string(_currentPassword.Select(i => _charList[i]).ToArray());
        }
    }
}
