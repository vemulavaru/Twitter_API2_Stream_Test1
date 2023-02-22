using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Twitter_API2_Stream_Test
{
    public static class Log
    {
        enum LogType
        {
            info,
            error
        }

        #region LogException

        public static void LogError(string errorMessage)
        {
            string logFilePath = "C:\\error.log";
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine(DateTime.Now.ToString() + Environment.NewLine + LogType.error + ": " + errorMessage + Environment.NewLine);
            }
        }
        public static void LogError(int statusCode, string errorMessage)
        {
            string logFilePath = "C:\\error.log";
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine(DateTime.Now.ToString() + Environment.NewLine + LogType.error + ": " + errorMessage + Environment.NewLine);
                if (statusCode != 0)
                    sw.WriteLine("Status Code: " + statusCode);
            }
        }

        #endregion

        #region LogInfo

        public static void LogInfo(string message)
        {
            string logFilePath = "C:\\error.log";
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine(DateTime.Now.ToString() + LogType.info + ": " + message + Environment.NewLine);
            }
        }
        public static void LogInfo(string statusCode, string message)
        {
            string logFilePath = "C:\\error.log";
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine(DateTime.Now.ToString() + LogType.info + ": " + message + Environment.NewLine);
                if (statusCode != string.Empty)
                    sw.WriteLine("Status Code: " + statusCode);
            }
        }

        #endregion



    }
}
