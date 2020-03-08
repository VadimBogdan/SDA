namespace FileService.Files
{
    public class TextDocument : CustomFile
    {
        public TextDocument(string fileName, string fileExtension, long timeCreation)
            : base(fileName, fileExtension, timeCreation) { }
    }
}
