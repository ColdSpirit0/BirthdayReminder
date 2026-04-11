using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace BirthdayReminder.Models
{
    public partial class BirthdayRecordWrap : ObservableObject
    {
        private BirthdayRecord _record;

        public BirthdayRecordWrap(BirthdayRecord record)
        {
            _record = record;
        }

        public string? Name
        {
            get => _record.Name;
            set
            {
                if (_record.Name != value)
                {
                    var newRecord = new BirthdayRecord { Name = value, BirthdayDate= _record.BirthdayDate };
                    _record = newRecord;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public DateTime BirthdayDate
        {
            get => _record.BirthdayDate;
            set
            {
                if (_record.BirthdayDate != value)
                {
                    var newRecord = new BirthdayRecord { Name = _record.Name, BirthdayDate = value };
                    _record = newRecord;
                    OnPropertyChanged(nameof(BirthdayDate));
                    OnPropertyChanged(nameof(DaysToBirthday));
                }

            }
        }      

        public TimeSpan DaysToBirthday => new TimeSpan();

        public int Age => 20;

        public BirthdayRecord Record
        {
            get => _record;
            set
            {    
                _record = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(BirthdayDate));
                OnPropertyChanged(nameof(DaysToBirthday));
                //Name = value.Name;
                //BirthdayDate = value.BirthdayDate;
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, Birthday: {BirthdayDate}";
        }

    }
}
