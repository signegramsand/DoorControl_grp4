﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DoorControl
{
    public interface IEntryNotification
    {
        void NotifyEntryGrante(string id);
    }
}
