using BirthdayReminder.Messages;
using BirthdayReminder.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayReminder.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<BirthdayRecordWrap> Records { get; private set; } = new();
        private IDataProvider _dataProvider;

        [ObservableProperty]
        public BirthdayRecordWrap? _selectedRecord;

        [RelayCommand]
        public async Task EditRecord()
        {
            if (SelectedRecord == null) return;
            var responce = await WeakReferenceMessenger.Default.Send(new EditRecordMessage(new BirthdayRecord(SelectedRecord.Record)));
            Console.WriteLine(responce?.Name);

            if (responce != null)
            {
                SelectedRecord.Record = new BirthdayRecord(responce);
                SaveChanges();
            }
        }

        [RelayCommand]
        public async Task AddRecord()
        {
            var responce = await WeakReferenceMessenger.Default.Send(new EditRecordMessage(null));
            Console.WriteLine(responce?.Name);

            if (responce != null)
            {
                Records.Add(new BirthdayRecordWrap(new BirthdayRecord(responce)));
                SaveChanges();

            }
        }

        [RelayCommand]
        public void RemoveRecord(BirthdayRecordWrap record)
        {
            Records.Remove(record);
            SaveChanges();
        }

        public MainWindowViewModel()
        {

            // Records =
            // [
            //     new BirthdayRecordWrap(new BirthdayRecord { Name = "Frank", BirthdayDate = new DateTime(1998, 3, 20) }),
            //     new BirthdayRecordWrap(new BirthdayRecord { Name = "Boba", BirthdayDate = new DateTime(2002, 7, 23) }),
            //     new BirthdayRecordWrap(new BirthdayRecord { Name = "Rita", BirthdayDate = new DateTime(1989, 7,25) }),
            // ];

            _dataProvider = new CsvDataProvider();
            Records = new ObservableCollection<BirthdayRecordWrap>(_dataProvider.Load().Select(r => new BirthdayRecordWrap(r)));
        }

        private void SaveChanges()
        {
            Console.WriteLine("Save Data");
            _dataProvider.Save(Records.Select(w => w.Record).ToArray());
        }
    }
}
