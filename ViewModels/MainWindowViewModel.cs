using BirthdayReminder.Messages;
using BirthdayReminder.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BirthdayReminder.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {

        public string Greeting { get; } = "Welcome to Avalonia!";

        [ObservableProperty]
        private ObservableCollection<BirthdayRecordWrap> _records = new();

        public BirthdayRecordWrap? SelectedRecord { get; set; }

        [RelayCommand]
        public async Task OpenEditWindow()
        {
            Console.WriteLine(SelectedRecord);

            //var responce = await WeakReferenceMessenger.Default.Send(new EditRecordMessage(new BirthdayRecord { Name = "Dale" }));
        }

        [RelayCommand]
        public void RemoveRecord(BirthdayRecordWrap record)
        {
            _records.Remove(record);
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
