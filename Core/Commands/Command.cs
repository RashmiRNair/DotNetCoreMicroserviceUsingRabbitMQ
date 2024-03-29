﻿using Core.Events;
using System;

namespace Core.Commands
{
    public abstract class Command: Message
    {
         public DateTime TimeStamp { get; protected set; }

        protected Command()
        {
            TimeStamp = DateTime.Now;
        }
    }
}