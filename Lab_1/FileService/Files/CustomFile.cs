namespace FileService.Files
{
    public abstract class CustomFile
    {
        public string FileName { get; private set; }

        public string FileExtension { get; private set; }

        // file creation time in milliseconds UTC
        public long CreationTime { get; private set; }


        public CustomFile(string fileName, string fileExtension, long timeCreation)
        {
            FileName = fileName;
            FileExtension = fileExtension;
            CreationTime = timeCreation;
        }

        public void setFileName(string fileName)
        {
            FileName = fileName;
        }

        public void setFileExtension(string fileExtension)
        {
            FileExtension = fileExtension;
        }

        public void setCreationTime(long timeCreation)
        {
            CreationTime = timeCreation;
        }
    }
}
