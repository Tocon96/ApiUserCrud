﻿namespace ApiUserCrud.Client.BusinessLogic.Utils
{
    public interface ILogger
    {
        public void Info(string message);
        public void Debug(string message);
        public void Error(string message);
        public void Warning(string message);
    }
}
