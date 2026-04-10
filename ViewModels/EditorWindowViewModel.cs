using BirthdayReminder.Messages;
using BirthdayReminder.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace BirthdayReminder.ViewModels
{
    internal partial class EditorWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private BirthdayRecordWrap _record;

        public EditorWindowViewModel(BirthdayRecord? record)
        {
            if (record != null)
            {
                Record = new BirthdayRecordWrap(record);
            }
            else
            {
                Record = new BirthdayRecordWrap(new BirthdayRecord { Name = "" });
            }
        }

        [RelayCommand]
        public void Save()
        {
            WeakReferenceMessenger.Default.Send(new CloseEditWindowMessage(Record.Record));
        }

        [RelayCommand]
        public void Cancel()
        {
            WeakReferenceMessenger.Default.Send(new CloseEditWindowMessage(null));
        }
    }
}
