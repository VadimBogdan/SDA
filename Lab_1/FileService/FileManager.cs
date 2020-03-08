using FileService.FileFactory;
using FileService.Files;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileService
{
    public class FileManager
    {
        private static FileManager _fileManager = new FileManager();

        private Dictionary<string, FileCreator> creators = new Dictionary<string, FileCreator>();
        private FileManager()
        {
            creators.Add(JpegFileCreator.Format, new JpegFileCreator());
            creators.Add(DocFileCreator.Format, new DocFileCreator());
            creators.Add(RtfFileCreator.Format, new RtfFileCreator());
            creators.Add(TxtFileCreator.Format, new TxtFileCreator());
        }
        public static FileManager GetInstance()
        {
            return _fileManager;
        }

        public CustomFile CreateFile(string fileName, string fileExtension)
        {
            if (string.IsNullOrWhiteSpace(fileName) ||
                string.IsNullOrWhiteSpace(fileExtension))
            {
                throw new ArgumentNullException();
            }

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName + "." + fileExtension);

            if (File.Exists(filePath))
            {
                throw new ArgumentException("Файл з таким ім'ям вже існує");
            }


            try
            {
                foreach (var creator in creators)
                {
                    if (creator.Key.Equals(fileExtension))
                    {

                        return creator.Value.CreateFile(filePath);
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
