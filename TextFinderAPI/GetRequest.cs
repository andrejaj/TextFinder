using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TextFinderAPI
{
    [BindProperties]
    public class GetRequest
    {
        [Required]
        public string Path { get; set; }
        [Required]
        public string Word { get; set; }
    }
}
