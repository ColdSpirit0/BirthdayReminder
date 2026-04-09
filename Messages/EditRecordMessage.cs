using BirthdayReminder.Models;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace BirthdayReminder.Messages
{
    internal class EditRecordMessage: AsyncRequestMessage<BirthdayRecord?>
    {
        public readonly BirthdayRecord? record;
       

        public EditRecordMessage(BirthdayRecord? record)
        {
            this.record = record;
        }
    }
}
