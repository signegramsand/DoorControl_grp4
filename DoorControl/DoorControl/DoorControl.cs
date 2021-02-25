using System;
using System.Collections.Generic;
using System.Text;

namespace DoorControl
{
    public class DoorControl
    {
        public enum Doorstate
        {
            DoorClosed,
            DoorOpening,
            DoorClosing,
            DoorBreached
        }

        public Doorstate state;

        public IDoor door { get; set; }

        public IAlarm alarm { get; set; }

        public IUserValidation userValidation { get; set; }

        public IEntryNotification entryNotification { get; set; }


        public void RequestEntry(string id)
        {
            if (state == Doorstate.DoorClosed)
            {
                bool status = userValidation.ValidateEntryRequest(id);

                if (status)
                {
                    door.Open();
                    entryNotification.NotifyEntryGranted(id);
                    state = Doorstate.DoorOpening;
                }
                else
                {
                    entryNotification.NotifyEntryDenied(id);
                }
            }
        }

        public void DoorOpened()
        {

        }

        public void DoorClosing()
        {

        }


    }
}
