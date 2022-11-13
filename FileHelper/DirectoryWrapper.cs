namespace FileHelper
{
    internal class DirectoryWrapper : IDirectoryWrapper
    {
        private const string FileExtension = "*.txt"; 
        public string[] GetFiles(string path)
        {
            return Directory.GetFiles(path, FileExtension, SearchOption.AllDirectories);
        }
    }
}
