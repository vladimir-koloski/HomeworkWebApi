using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollegeApp.Services.Helpers
{
    public static class Validations
    {
        public static bool ValidatePhoneNumber(int number)
        {
            if (number.ToString().StartsWith("07") && number.ToString().Length == 9)
            {
                return false;
            }
            return true;
        }

        public static bool ValidateEmail(string email)
        {
            if (!email.Contains('@'))
            {
                return false;
            }
            
            string[] emailParts = email.Split('@');
            if (emailParts.Length != 2)
            {
                return false;
            }

            if (!emailParts[emailParts.Length - 1].Contains('.'))
            {
                return false;
            }

            return true;
        }
    }
}
