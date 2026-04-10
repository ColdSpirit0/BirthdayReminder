using System;

namespace BirthdayReminder.Models
{
    public class BirthdayRecord
    {
        public string? Name;
        public DateTime BirthdayDate = DateTime.Today;

        public BirthdayRecord(BirthdayRecord record)
        {
            Name = record.Name;
            BirthdayDate = record.BirthdayDate;
        }

        public BirthdayRecord()
        {
            
        }
    }
}
