using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QM_BetterCompanions
{
    /// <summary>
    /// A Unity Debug Logger that includes the assembly name.
    /// Makes finding the mod that created the log entry easy to find.
    /// Calls the Unity.Debug functions that match the function names.
    /// </summary>
    public class Logger
    {
        public bool IsEnabled 
        {
            get { return Plugin.Config?.DebugLog ?? false; }
            set { Plugin.Config.DebugLog = value; }
        }

        /// <summary>
        /// The identifier to include at the start of every line.
        /// If not set, defaults to this assembly's name.
        /// </summary>
        public string LogPrefix { get; set; }

        public Logger(string logPrefix = "")
        {
            if (string.IsNullOrEmpty(logPrefix))
            {
                logPrefix = Assembly.GetExecutingAssembly().GetName().Name;
            }

            LogPrefix = logPrefix;
        }

        public void Log(string message)
        {
            if (IsEnabled)
            {
                Debug.Log($"[{LogPrefix}] {message}");
            }
        }

        public void LogWarning(string message)
        {
            if (IsEnabled)
            {
                Debug.LogWarning($"[{LogPrefix}] {message}");
            }
        }

        public void LogError(string message)
        {
            if (IsEnabled)
            {
                Debug.LogError($"[{LogPrefix}] {message}");
            }
        }

        public void LogException(Exception ex)
        {
            if (IsEnabled)
            {
                Debug.LogError($"[{LogPrefix}] Exception Logged:");
                Debug.LogException(ex);
            }
        }
    }
}
