using Infrastructure.Model;

namespace FileHelper
{
    public class DirectoryHelper
    {
        private readonly IDirectoryWrapper _directoryWrapper;
        private readonly IFileWrapper _fileWrapper;

        public DirectoryHelper(IDirectoryWrapper directoryWrapper, IFileWrapper fileWrapper)
        {

            _directoryWrapper = directoryWrapper ?? throw new ArgumentNullException(nameof(directoryWrapper));
            _fileWrapper = fileWrapper ?? throw new ArgumentNullException(nameof(fileWrapper));
        }

        public IEnumerable<WordCount> GetFilesContainingWord(string rootPath, string word)
        {
            var FilesFound = new List<WordCount>();

            foreach (var file in _directoryWrapper.GetFiles(rootPath))
            {
                var content = _fileWrapper.GetContent(file);
                var count = word.Occurence(content);
                if (count > 0)
                {
                    FilesFound.Add(new WordCount(file, count));
                }
            }
            return FilesFound;
        }
    }
}
