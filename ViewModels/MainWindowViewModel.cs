using BirthdayReminder.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;

namespace BirthdayReminder.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {

        public string Greeting { get; } = "Welcome to Avalonia!";

        [ObservableProperty]
        private ObservableCollection<BirthdayRecordWrap> _records = new();
                
        //private ObservableCollection<BirthdayRecordWrap> _selectedRecords = new();

        [ObservableProperty]
        public int _counter = 0;

        //public BirthdayRecordWrap? SelectedRecord { get; set; }

        [RelayCommand]
        public void Increment()
        {
            Counter++;
        }

        [RelayCommand]
        public void OpenEditWindow()
        {
            Console.WriteLine("EDIT WINDOW");
        }

        public MainWindowViewModel()
        {
                       
            _records =
            [
                new BirthdayRecordWrap(new BirthdayRecord { Name = "FFG", BirthdayDate = new DateTime() }),
                new BirthdayRecordWrap(new BirthdayRecord { Name = "Boba", BirthdayDate = new DateTime() }),
            ];
        }
    }
}
