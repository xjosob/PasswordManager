using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.AccountStuff
{
    public class AccountDatabase
    {
        public static string CentralFolderPath = @"E:\PasswordsLocation";

        public static string AccName = "accName.txt";
        public static string EmailName = "email.txt";
        public static string UserName = "usrnm.txt";
        public static string PasswrdName = "psswrd.txt";
        public static string DofBrthName = "dob.txt";
        public static string ScrtyInName = "scrtinf.txt";
        public static string ExtrIn1Name = "extrin1.txt";
        public static string ExtrIn2Name = "extrin2.txt";
        public static string ExtrIn3Name = "extrin3.txt";
        public static string ExtrIn4Name = "extrin4.txt";
        public static string ExtrIn5Name = "extrin5.txt";

        public static void createdirthing()
        {
            File.Create(Path.Combine(CentralFolderPath, AccName));
            File.Create(Path.Combine(CentralFolderPath, EmailName));
            File.Create(Path.Combine(CentralFolderPath, UserName));
            File.Create(Path.Combine(CentralFolderPath, PasswrdName));
            File.Create(Path.Combine(CentralFolderPath, ScrtyInName));
            File.Create(Path.Combine(CentralFolderPath, DofBrthName));
            File.Create(Path.Combine(CentralFolderPath, ScrtyInName));
            File.Create(Path.Combine(CentralFolderPath, ExtrIn1Name));
            File.Create(Path.Combine(CentralFolderPath, ExtrIn2Name));
            File.Create(Path.Combine(CentralFolderPath, ExtrIn3Name));
            File.Create(Path.Combine(CentralFolderPath, ExtrIn4Name));
            File.Create(Path.Combine(CentralFolderPath, ExtrIn5Name));
        }
    }
}
