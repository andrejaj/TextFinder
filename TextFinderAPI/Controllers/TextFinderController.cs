using FileHelper;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
// Note: to test api run TextFinderAPI project
// You can directly add values and test response as it supports swagger
namespace TextFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextFinderController : ControllerBase
    {
        private readonly ILogger<TextFinderController> _logger;
        private readonly DirectoryHelper _directoryHelper;

        public TextFinderController(ILogger<TextFinderController> logger)
        {
            _logger = logger;
            _directoryHelper = DirectoryHelper.DirectoryHelperCreator();
        }

        // GET api/<TextFinderController>/5
        [HttpGet]
        public IEnumerable<WordCount> Get([FromQuery] GetRequest request)
        {          
            _logger.LogInformation($"Call Id: {new Random().Next(10)} - Fetch Get with Folderpath: {request.Path} and Text: {request.Word}");

            if (string.IsNullOrEmpty(request.Word) || string.IsNullOrEmpty(request.Path))
            {
                return Enumerable.Empty<WordCount>();
            }

            ///make GetFilesContainingWord async!
            var result = _directoryHelper.GetFilesContainingWord(request.Path, request.Word);
            return result;
        }
    }
}
