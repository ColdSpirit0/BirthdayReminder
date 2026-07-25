namespace BirthdayReminder.Models
{
    public interface IDataProvider
    {
        void Save(BirthdayRecord[] records);
        BirthdayRecord[] Load();
    }
}