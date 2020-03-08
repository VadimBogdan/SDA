using FileService;
using FileService.FileFactory;
using System;
using System.Text;

namespace IO
{
    public class ConsoleIO
    {
        private static ConsoleIO _consoleIO = new ConsoleIO();

        private ConsoleIO()
        {
            Console.OutputEncoding = new UTF8Encoding();
        }

        public static ConsoleIO GetInstance()
        {
            return _consoleIO;
        }

        public void Interact()
        {
            string input;
            string[] splitted;

            Console.WriteLine("Для роботи, введіть ім'я та формат файлу.");

            while (true)
            {

                try
                {
                    input = Console.ReadLine().Trim();
                }
                catch (NullReferenceException e)
                {
                    break;
                }
                catch (Exception e)
                {
                    WriteError(e.Message);
                    continue;
                }


                splitted = input.Split('.');

                if (splitted.Length > 2 || splitted.Length <= 1)
                {
                    WriteError("Невірний запис");
                    continue;
                }


                if (FileCreator.isAvailableExtension(splitted[1]))
                {
                    string name = splitted[0];
                    string ext = splitted[1];

                    try
                    {
                        FileManager.GetInstance().CreateFile(name, ext);
                    }
                    catch (Exception e)
                    {
                        WriteError(e.Message);
                    }
                }
                else
                {
                    WriteError("Формат " + splitted[1] + " не підтримується");
                }
            }
        }

        private void WriteError(string errorMessage)
        {
            Console.Error.WriteLine(errorMessage);
        }
    }
}
