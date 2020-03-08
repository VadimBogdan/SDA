using FileService.Files;
using System.Text.RegularExpressions;

namespace FileService.FileFactory
{
    public abstract class FileCreator
    {
        public abstract CustomFile FactoryMethod(string filePath);

        public static bool isAvailableExtension(string fileExtension)
        {
            Regex r = new Regex(
                @"jpeg|txt|doc|rtf$"
                );
            return r.IsMatch(fileExtension);
        }
        public CustomFile CreateFile(string filePath)
        {
            return FactoryMethod(filePath);
        }
    }
}
