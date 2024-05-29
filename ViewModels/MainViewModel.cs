using PasswordManager.AccountStuff;
using PasswordManager.Controls;
using PasswordManager.Utilities;
using PasswordManager.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PasswordManager.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<AccountListItem> _items = new ObservableCollection<AccountListItem>();
        public ObservableCollection<AccountListItem> Accounts { get => _items; set { _items = value; RaisePropertyChanged(); } }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex; set
            {
                _selectedIndex = value; RaisePropertyChanged();
            }
        }

        public bool AccountSelected => SelectedIndex >= 0 && SelectedIndex < Accounts.Count;

        public AccountListItem SelectedAccountItem
        {
            get
            {
                try { return Accounts[SelectedIndex]; }
                catch
                {
                    return null;
                }
            }
        }

        public AccountStructure SelectedAccountStructure
        {
            get
            {
                try { return Accounts[SelectedIndex].DataContext as AccountStructure; }
                catch
                {
                    return null;
                }
            }
        }

        public AddAccountWindow NewAccountWindow { get; set; }
        public EditAccountWindow EditAccountWindow { get; set; }
        public AccountContentViewer AccountViewer { get; set; }

        public ICommand AddAccountCommand { get; set; }
        public ICommand EditAccountCommand { get; set; }
        public ICommand DeleteAccountCommand { get; set; }
        public ICommand ShowAccountInfoCommand { get; set; }
        public ICommand MoveAccountPostCommand { get; set; }

        public ICommand SaveAccountsCommand { get; set; }
        public ICommand LoadAccountsCommand { get; set; }

        public MainViewModel()
        {
            AddAccountCommand = new Command(ShowAddAccountWindow);
            EditAccountCommand = new Command(ShowEditAccountWindow);
            DeleteAccountCommand = new Command(DeleteAccount);
            ShowAccountInfoCommand = new Command(ShowAccContentWindow);
            SaveAccountsCommand = new Command(SaveAccounts);
            LoadAccountsCommand = new Command(LoadAccounts);
            MoveAccountPostCommand = new CommandParam(MoveSelectedAccountPosition);
            

            NewAccountWindow = new AddAccountWindow();
            EditAccountWindow = new EditAccountWindow();
            AccountViewer = new AccountContentViewer();

            AccountDatabase.createdirthing();

            NewAccountWindow.AddAccountCallback = this.AddAccount;
        }

        private void MoveSelectedAccountPosition(object upOrDown)
        {
            switch (int.Parse(upOrDown.ToString()))
            {
                case 0:
                    if(SelectedIndex > 0)
                    {
                        Accounts.Move(SelectedIndex, SelectedIndex - 1);
                    }
                    break;
                case 1:
                    if(SelectedIndex + 1 < Accounts.Count)
                    {
                        Accounts.Move(SelectedIndex, SelectedIndex + 1);
                    }
                    break;
            }
        }

        private void SaveAccounts() 
        {
            List<AccountStructure> accs = new List<AccountStructure>();
            foreach (AccountListItem acc in Accounts)
            {
                
                AccountStructure accStr = acc.DataContext as AccountStructure;
                accs.Add(accStr);
            }

            AccountDatabase.AccountSaver.SaveFiles(accs);
        }
        private void LoadAccounts() 
        {
            foreach(var it in AccountDatabase.AccountLoader.LoadFiles())
            {
                AddAccount(it);
            }
        }

        private void ShowAccContentWindow()
        {
            if (AccountSelected)
            {
                SetAccWndContext(); 
                AccountViewer.Show();
            }
        }
        private void SetAccWndContext() 
        {
            AccountViewer.DataContext = SelectedAccountStructure; 
        }

        private void AddAccount() 
        {
            AddAccount(NewAccountWindow.AccountContext); 
        }

        private void AddAccount(AccountStructure acc)
        {
            AccountListItem ali = new AccountListItem();
            ali.DataContext = acc;
            ali.ShowContentWindowCallback = ShowAccContentWindow;

            Accounts.Add(ali);
        }

        private void ShowAddAccountWindow() { NewAccountWindow.Show(); }

        private void EditAccount()
        {
            if (SelectedAccountStructure != null)
            {
                SetEditWndContext();
                EditAccountWindow.Show();
            }
        }

        private void ShowEditAccountWindow()
        {
            SetEditWndContext();
            EditAccountWindow.Show();
        }

        private void SetEditWndContext()
        {
            EditAccountWindow.DataContext = SelectedAccountStructure;
        }


        private void DeleteAccount()
        {
            if (AccountSelected)
            {
                Accounts.RemoveAt(SelectedIndex);
                SaveAccounts();
            }
        }
    }
}
