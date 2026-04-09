using BirthdayReminder.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayReminder.ViewModels
{
    internal partial class EditorWindowViewModel:ViewModelBase
    {
        [ObservableProperty]
        private BirthdayRecordWrap _record;

        public EditorWindowViewModel(BirthdayRecord record)
        {
            Record = new BirthdayRecordWrap(record);
        }
    }
}
