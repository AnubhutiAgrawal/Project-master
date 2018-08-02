using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaPark.PizzaHub.UserAuthentication.Authentication.Model;

namespace PizzaPark.PizzaHub.UserAuthentication.Authentication.BusinessLayer
{
    public class CreateUser
    {

        List<AuthenticationDomain> user;
        public CreateUser()
        {
            user = new List<AuthenticationDomain>();
            user.Add(new AuthenticationDomain { Email = "Anubhuti@gmail.com", Password = "abc", Name = "abc" });
            user.Add(new AuthenticationDomain { Email = "abcd@gmail.com", Password = "bcd", Name = "abc" });
            user.Add(new AuthenticationDomain { Email = "Anu", Password = "Anu", Name = "Ram" });
            user.Add(new AuthenticationDomain { Email = "akku", Password = "akku", Name = "Priya" });
        }


        public bool CheckUser(string username, string password)
        {
            var account = user.FirstOrDefault(e => e.Email.Equals(username));
            //  var acc = user.Count(e => e.Password.StartsWith("a"));

            if (account != null)
            {
                return account.Password.Equals(password);
            }
            return false;
        }
        public List<AuthenticationDomain> GetList()
        {
            return user;

        }
        public List<AuthenticationDomain> GetUserName(string name)
        {

            var accounts = user.Where(e => e.Name.Equals(name)).ToList();
            return accounts;

        }
        public AuthenticationDomain GetUserEmail(string email)
        {
            var FetchUser = user.SingleOrDefault(e => e.Email.Equals(email));
            return FetchUser;

        }

    }
}
