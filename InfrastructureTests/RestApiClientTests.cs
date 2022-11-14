using Infrastructure.Client;
using Infrastructure.Model;
using System.Web;

namespace InfrastructureTests
{
    public class Tests
    {
        [Test]
        public async Task RestApiClientReturnsWordCOuntItems()
        {
            // Arrange
            var client = new RestAPIClient();
            var text = HttpUtility.UrlEncode("you");
            var filepath = HttpUtility.UrlEncode(@"C:\Work\test");
            var requestParam = new Uri($"https://localhost:5001/api/TextFinder?Path={filepath}&Word={text}");
            
            // Act
            var result = (List<WordCount>)await client.GetResponseAsync(requestParam);
            
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(2));
        }
    }
}