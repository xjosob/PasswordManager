using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.AccountStuff
{
    /// <summary>
    ///  Contains all account info, datacontext for an AccountListItem.
    /// </summary>
    public class AccountStructure
    {
        // Account name e.g Youtube, Google
        public string AccountName { get; set; }

        public string EmailAdress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DateOfBirth { get; set; }
        public string SecurityInfo { get; set; }


        // Extra info e.g links, security questions

        public string ExtraInfo1 { get; set; }
        public string ExtraInfo2 { get; set; }
        public string ExtraInfo3 { get; set; }
        public string ExtraInfo4 { get; set; }
        public string ExtraInfo5 { get; set; }
    }
}
