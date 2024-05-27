using PasswordManager.AccountStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordManager.Controls
{
    /// <summary>
    /// Interaction logic for AccountListItem.xaml
    /// </summary>
    public partial class AccountListItem : UserControl
    {
        //Displays contents windows
        public Action ShowContentWindowCallback { get; set; }

        //Account item structure
        public AccountStructure AccountContext { get => this.DataContext as AccountStructure; }

        public AccountListItem()
        {
            InitializeComponent();
        }

        private void ButtonsClicked(object sender, RoutedEventArgs e)
        {
            switch (int.Parse(((Button)sender).Uid))
            {
                //Copy email to clipboard
                case 1: if (!AccountNull) Clipboard.SetText(AccountContext.EmailAdress); break;
                //Copy password to clipboard
                case 2: if (!AccountNull) Clipboard.SetText(AccountContext.Password); break; 
                //View Contents
                case 3: ShowContentWindowCallback?.Invoke(); break;
            }
        }

        public bool AccountNull => AccountContext == null;
    }
}
