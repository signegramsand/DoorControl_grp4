using System;
using System.Collections.Generic;
using System.Text;

namespace DoorControl
{
    public class DoorControl
    {
        enum Doorstate
        {
            DoorClosed,
            DoorOpening,
            DoorClosing,
            DoorBreached
        }

        private Doorstate state = Doorstate.DoorClosed;
        public IDoor door { get; set; }

        public IAlarm alarm { get; set; }

        public IUserValidation userValidation { get; set; }

        public IEntryNotification entryNotification { get; set; }


        public void RequestEntry(string id)
        {

        }

        public void DoorOpened()
        {

        }

        public void DoorClosing()
        {

        }


    }
}
