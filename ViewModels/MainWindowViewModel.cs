using BirthdayReminder.Messages;
using BirthdayReminder.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BirthdayReminder.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<BirthdayRecordWrap> Records { get; private set; } = new();

        [ObservableProperty]
        public BirthdayRecordWrap? _selectedRecord;

        [RelayCommand]
        public async Task EditRecord()
        {
            if (SelectedRecord == null) return;
            var responce = await WeakReferenceMessenger.Default.Send(new EditRecordMessage(new BirthdayRecord(SelectedRecord.Record)));
            Console.WriteLine(responce.Name);

            if (!responce.IsInvalid) SelectedRecord.Record = new BirthdayRecord(responce);
        }

        [RelayCommand]
        public async Task AddRecord()
        {
            var responce = await WeakReferenceMessenger.Default.Send(new EditRecordMessage(new BirthdayRecord()));
            Console.WriteLine(responce.Name);

            if (!responce.IsInvalid) Records.Add(new BirthdayRecordWrap(new BirthdayRecord(responce)));
        }

        [RelayCommand]
        public void RemoveRecord(BirthdayRecordWrap record)
        {
            Records.Remove(record);
        }

        public MainWindowViewModel()
        {

            Records =
            [
                new BirthdayRecordWrap(new BirthdayRecord { Name = "Frank", BirthdayDate = new DateTime() }),
                new BirthdayRecordWrap(new BirthdayRecord { Name = "Boba", BirthdayDate = DateTime.Now }),
                new BirthdayRecordWrap(new BirthdayRecord { Name = "Rita", BirthdayDate = new DateTime() }),
            ];
        }
    }
}
