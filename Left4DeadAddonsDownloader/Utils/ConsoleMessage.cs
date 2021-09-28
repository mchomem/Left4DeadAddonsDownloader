using System;

namespace Left4DeadAddonsDownloader.Utils
{
    public enum TypeMessage
    {
        INFORMATION,
        SUCCESS,
        WARNING,
        ERROR,
        DEFAULT
    }


    public static class ConsoleMessage
    {


        public static void Write(string text, TypeMessage typeMessage = TypeMessage.DEFAULT, bool prefixLogTime = true, bool recordLog = true)
        {
            string logTime = $"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}]: ";

            if (prefixLogTime)
                Console.Write(logTime);

            switch (typeMessage)
            {
                case TypeMessage.INFORMATION:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;

                case TypeMessage.SUCCESS:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case TypeMessage.WARNING:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case TypeMessage.ERROR:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }

            Console.WriteLine(text);

            if (recordLog)
            {
                if (prefixLogTime)
                    Log.Add($"{logTime}{text}");
                else
                    Log.Add(text);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
