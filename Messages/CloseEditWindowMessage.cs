using BirthdayReminder.Models;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace BirthdayReminder.Messages
{
    internal class CloseEditWindowMessage:AsyncRequestMessage<BirthdayRecord?>
    {
        public readonly BirthdayRecord? record;

        public CloseEditWindowMessage(BirthdayRecord? record)
        {
            this.record = record;
        }
    }
}
