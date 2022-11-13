using FileHelper;
using Moq;

namespace FileHelperTests
{
    public class DirectoryTests
    {
        private Mock<IDirectoryWrapper> _directoryWrapper;
        private Mock<IFileWrapper> _fileWrapper;

        [SetUp]
        public void Setup()
        {
            this._directoryWrapper = new Mock<IDirectoryWrapper>();
            this._fileWrapper = new Mock<IFileWrapper>();
        }

        [Test]
        public void DirectoryReturnsFileWithStringOccurence()
        {
            // Arrange
            var path = "file.txt";
            var word = "you";
            _directoryWrapper.Setup(x => x.GetFiles(It.IsAny<string>())).Returns(new[] { path });
            _fileWrapper.Setup(x => x.GetContent(It.Is<string>(x => x.Equals(path)))).Returns("you should be and you shell be.");
            var directoryHelper = new DirectoryHelper(_directoryWrapper.Object, _fileWrapper.Object);

            // Act
            var fileWordCount = directoryHelper.GetFilesContainingWord(path, word).First();

            // Assert
            Assert.That(fileWordCount.Filepath, Is.EqualTo(path));
            Assert.That(fileWordCount.Count, Is.EqualTo(2));
        }
    }
}