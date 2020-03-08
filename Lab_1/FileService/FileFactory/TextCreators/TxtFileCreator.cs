using FileService.Files;
using System;
using System.IO;

namespace FileService.FileFactory
{
    public class TxtFileCreator : TextFileCreator
    {
        public static string Format { get; set; } = "txt";


        public override CustomFile FactoryMethod(string filePath)
        {
            try
            {
                File.Create(filePath);
            }
            catch (Exception e)
            {
                throw e;
            }
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            long creationTime = File.GetCreationTimeUtc(filePath).ToFileTimeUtc();


            return new TextDocument(fileName, Format, creationTime);
        }
    }
}
