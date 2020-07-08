using System;
using System.Collections.Generic;
using System.Text;

namespace AccountWebApi.Logger.Contract
{
    /// <summary>
    /// This is the contract defining logging Operations.
    /// </summary>
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
