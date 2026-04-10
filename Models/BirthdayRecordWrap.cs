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

        public string Name
        {
            get => _record.Name;
            set
            {
                if (_record.Name != value)
                {
                    _record.Name = value;
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
                    _record.BirthdayDate = value;
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
