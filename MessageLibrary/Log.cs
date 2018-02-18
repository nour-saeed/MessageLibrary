using System;
using System.IO;

namespace MessageLibrary
{
    public static class Log
    {
        public static bool StatusOk = true;
        public static LogConfigurations Configuration;

        public static void Write(
            string Message,
            Exception ex = null,
            MessageType type = MessageType.None,
            LogConfigurations log = null
            )
        {
            try
            {
                log = log ?? Configuration;

                using (StreamWriter sw = new StreamWriter(log.FilePath + "\\" + log.FileName, true))
                {
                    sw.WriteLine(log.GetPrevious(type) + Message);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
                StatusOk = false;
            }
        }

        public static void Write(Exception ex)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Log.txt", true))
                {
                    sw.WriteLine(DateTime.Now.ToString() + ": " + ex.Source.ToString().Trim() + ";" + ex.Message.ToString().Trim());
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
                StatusOk = false;
            }
        }

        public static void Write(string Message, Exception ex)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Log.txt", true))
                {
                    sw.WriteLine(DateTime.Now.ToString() + ": " + Message + " ;  ##Exception: " + ex.Source.ToString().Trim() + ";" + ex.Message.ToString().Trim());
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
                StatusOk = false;
            }
        }
    }
}
