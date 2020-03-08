using FileService.Files;
using System;
using System.IO;

namespace FileService.FileFactory
{
    public class DocFileCreator : TextFileCreator
    {
        public static string Format { get; set; } = "doc";


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
            int creationTime = File.GetCreationTimeUtc(filePath).Millisecond;


            return new TextDocument(fileName, Format, creationTime);
        }
    }
}
