using System;

namespace BirthdayReminder.Models
{
    public class BirthdayRecord
    {
        public string? Name;
        public DateTime BirthdayDate;

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
