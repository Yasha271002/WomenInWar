﻿using System;

namespace WomenInWar.Helpers.Logging
{
    public interface ILoggingService
    {
        void Log(string message);

        void Log(Exception exception, string message = null);
    }

}
