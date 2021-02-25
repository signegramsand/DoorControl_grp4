using System;
using System.Collections.Generic;
using System.Text;

namespace DoorControl
{
    public interface IEntryNotification
    {
        void NotifyEntryGranted(string id);

        void NotifyEntryDenied(string id);
    }
}
