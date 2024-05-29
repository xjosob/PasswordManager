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

        public static string AccNameName = "accName.txt";
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

                WriteToFile(Path.Combine(directory, AccNameName), NewAccName);
                WriteToFile(Path.Combine(directory, EmailName), NewEmail);
                WriteToFile(Path.Combine(directory, UserName), NewUserName);
                WriteToFile(Path.Combine(directory, PasswrdName), NewPassword);
                WriteToFile(Path.Combine(directory, DofBrthName), NewDateofBirth);
                WriteToFile(Path.Combine(directory, ScrtyInName), NewSecurityInfo);
                WriteToFile(Path.Combine(directory, ExtrIn1Name), NewExtraInfo1);
                WriteToFile(Path.Combine(directory, ExtrIn2Name), NewExtraInfo2);
                WriteToFile(Path.Combine(directory, ExtrIn3Name), NewExtraInfo3);
                WriteToFile(Path.Combine(directory, ExtrIn4Name), NewExtraInfo4);
                WriteToFile(Path.Combine(directory, ExtrIn5Name), NewExtraInfo5);
            }

            private static void WriteToFile(string path, List<string> contents)
            {
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    foreach (var line in contents)
                    {
                        writer.WriteLine(line);
                    }
                }
            }


        }

        public static class AccountLoader
        {
            public static List<AccountStructure> LoadFiles() { return LoadFiles(CentralFolderPath); }
            public static List<AccountStructure> LoadFiles(string directory)
            {
                List<string> accName = ReadFromFile(Path.Combine(directory, AccNameName));
                List<string> emailss = ReadFromFile(Path.Combine(directory, EmailName));
                List<string> usernam = ReadFromFile(Path.Combine(directory, UserName));
                List<string> passwrd = ReadFromFile(Path.Combine(directory, PasswrdName));
                List<string> dobrths = ReadFromFile(Path.Combine(directory, ScrtyInName));
                List<string> scrtyin = ReadFromFile(Path.Combine(directory, DofBrthName));
                List<string> extrin1 = ReadFromFile(Path.Combine(directory, ExtrIn1Name));
                List<string> extrin2 = ReadFromFile(Path.Combine(directory, ExtrIn2Name));
                List<string> exrin3 = ReadFromFile(Path.Combine(directory, ExtrIn3Name));
                List<string> extrin4 = ReadFromFile(Path.Combine(directory, ExtrIn4Name));
                List<string> extrin5 = ReadFromFile(Path.Combine(directory, ExtrIn5Name));

                List<AccountStructure> accounts = new List<AccountStructure>();

                for (int i = 0; i < accName.Count; i++)
                {
                    AccountStructure am = new AccountStructure()
                    {
                        AccountName = accName[i],
                        EmailAdress = emailss[i],
                        UserName = usernam[i],
                        Password = passwrd[i],
                        DateOfBirth = dobrths[i],
                        SecurityInfo = scrtyin[i],
                        ExtraInfo1 = extrin1[i],
                        ExtraInfo2 = extrin2[i],
                        ExtraInfo3 = exrin3[i],
                        ExtraInfo4 = extrin4[i],
                        ExtraInfo5 = extrin4[i],
                    };
                    accounts.Add(am);
                }

                return accounts;
            }
                private static List<string> ReadFromFile(string path)
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        List<string> lines = new List<string>();
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            lines.Add(line);
                        }
                        return lines;
                    }
                }
            }


        public static void createdirthing()
        {
            CreateFileIfNotExists(AccNameName);
            CreateFileIfNotExists(EmailName);
            CreateFileIfNotExists(UserName);
            CreateFileIfNotExists(PasswrdName);
            CreateFileIfNotExists(ScrtyInName);
            CreateFileIfNotExists(DofBrthName);
            CreateFileIfNotExists(ExtrIn1Name);
            CreateFileIfNotExists(ExtrIn2Name);
            CreateFileIfNotExists(ExtrIn3Name);
            CreateFileIfNotExists(ExtrIn4Name);
            CreateFileIfNotExists(ExtrIn5Name);
        }

        private static void CreateFileIfNotExists(string fileName)
        {
            string filePath = Path.Combine(CentralFolderPath, fileName);
            if (!File.Exists(filePath))
            {
                using (File.Create(filePath))
                {
                    // The using block ensures the file stream is closed immediately after creation.
                }
            }
        }
    }
}
