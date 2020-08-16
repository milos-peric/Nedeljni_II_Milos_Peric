using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nedeljni_II_Milos_Peric.Validation
{
    class PasswordValidator
    {
        public static bool ValidatePassword(string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            bool isMatch1 = hasNumber.IsMatch(password);
            bool isMatch2 = hasUpperChar.IsMatch(password);
            bool isMatch3 = hasLowerChar.IsMatch(password);
            bool isMatch4 = hasMiniMaxChars.IsMatch(password);
            bool isMatch5 = hasSymbols.IsMatch(password);
            bool isValid = isMatch1 && isMatch2 && isMatch3 && isMatch4 && isMatch5;
            return isValid;
        }
    }
}
