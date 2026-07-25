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
                    OnPropertyChanged(nameof(Age));
                }
            }
        }

        public int DaysToBirthday
        {
            get
            {
                var now = DateTime.Today;
                var birthdayDate = new DateTime(now.Year, BirthdayDate.Month, BirthdayDate.Day);

                if (birthdayDate < now)
                {
                    birthdayDate = new DateTime(birthdayDate.Year + 1, BirthdayDate.Month, BirthdayDate.Day);
                }

                return (birthdayDate - now).Days;
            }
        }

        public int Age
        {
            get
            {
                var now = DateTime.Today;
                var yearsOld = now.Year - BirthdayDate.Year;
                var birthdayDate = new DateTime(now.Year, BirthdayDate.Month, BirthdayDate.Day);

                if (birthdayDate > now)
                {
                    yearsOld--;
                }

                return yearsOld;
            }
        }

        public BirthdayRecord Record
        {
            get => _record;
            set
            {
                _record = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(BirthdayDate));
                OnPropertyChanged(nameof(DaysToBirthday));
                OnPropertyChanged(nameof(Age));
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, Birthday: {BirthdayDate}";
        }

    }
}
