using System.Text.RegularExpressions;

namespace AzureFunctionDemo.Helper
{
    public static class EmailValidation
    {
        public static bool ValidateEmail(this string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public static bool ValidateEmail1(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|com.tr|de)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }
    }
}
