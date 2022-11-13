using Microsoft.Extensions.Logging;
using Moq;
using TextFinderAPI.Controllers;

namespace TextFinderControllerTests
{
    public class Tests
    {
        private Mock<ILogger<TextFinderController>> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<TextFinderController>>();
        }

        [TestCase(@"C:\Work\test", "you", 2)]
        public void GetReturnsWordOccurencesinFile(string path, string word, int count)
        {
            var controller = new TextFinderController(_logger.Object);
            var result = controller.Get(new TextFinderAPI.GetRequest() { Path = path, Word = word }).ToList();
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(1));
            var item = result.First();
            Assert.That(item.Filepath.Contains(path));
            Assert.That(item.Count, Is.EqualTo(count));
        }

        [TestCase(@"C:\Work\test", "")]
        [TestCase(@"C:\Work\test", "mike")]
        public void GetReturnsNoWordOccurenceInFiles(string path, string word)
        {
            var controller = new TextFinderController(_logger.Object);
            var result = controller.Get(new TextFinderAPI.GetRequest() { Path = path, Word = word });
            Assert.That(result, Is.Null.Or.Empty);
        }
    }
}