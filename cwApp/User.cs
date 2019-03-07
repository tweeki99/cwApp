using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwApp
{
    public class User
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Age { get; set; }


        public bool ReadEmail(string email)
        {
            if (email.Contains("@") && email.Contains("."))
            {
                Email = email;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReadPhone(string phone)
        {
            if (phone.Contains("+") && phone.Length==12)
            {
                Phone = phone;
                return true;
            }
            else
            {
                return false;
            }
        }


    }
    
}
