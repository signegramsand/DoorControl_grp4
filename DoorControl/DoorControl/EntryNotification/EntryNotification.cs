using System;
using System.Collections.Generic;
using System.Text;

namespace DoorControl
{
    public class EntryNotification : IEntryNotification
    {
        public void NotifyEntryGranted(string id)
        {
            throw new NotImplementedException();
        }

        public void NotifyEntryDenied(string id)
        {
            throw new NotImplementedException();
        }
    }
}
