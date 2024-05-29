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
        public static string CentralFolderPath = @"C:\PasswordsLocation";

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

        public static class AccountSaver
        {
            public static void SaveFiles(List<AccountStructure> accounts) { SaveFiles(accounts, CentralFolderPath); }
            public static void SaveFiles(List<AccountStructure> accounts, string directory)
            {
                List<string> NewAccName = new List<string>();
                List<string> NewEmail = new List<string>();
                List<string> NewUserName = new List<string>();
                List<string> NewPassword = new List<string>();
                List<string> NewDateofBirth = new List<string>();
                List<string> NewSecurityInfo = new List<string>();
                List<string> NewExtraInfo1 = new List<string>();
                List<string> NewExtraInfo2 = new List<string>();
                List<string> NewExtraInfo3 = new List<string>();
                List<string> NewExtraInfo4 = new List<string>();
                List<string> NewExtraInfo5 = new List<string>();

                for (int i = 0; i < accounts.Count; i++)
                {
                    NewAccName.Add(accounts[i].AccountName);
                    NewEmail.Add(accounts[i].EmailAdress);
                    NewUserName.Add(accounts[i].UserName);
                    NewPassword.Add(accounts[i].Password);
                    NewDateofBirth.Add(accounts[i].DateOfBirth);
                    NewSecurityInfo.Add(accounts[i].SecurityInfo);
                    NewExtraInfo1.Add(accounts[i].ExtraInfo1);
                    NewExtraInfo2.Add(accounts[i].ExtraInfo2);
                    NewExtraInfo3.Add(accounts[i].ExtraInfo3);
                    NewExtraInfo4.Add(accounts[i].ExtraInfo4);
                    NewExtraInfo5.Add(accounts[i].ExtraInfo5);
                }

                File.WriteAllLines(Path.Combine(directory, AccName), NewAccName);
            }
        }


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
