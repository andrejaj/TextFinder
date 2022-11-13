using System.Runtime.CompilerServices;

namespace Infrastructure.Model
{
    public class WordCount
    {
        public int Count { get; set; }
        public string Filepath { get; }

        public WordCount(string filepath, int count)
        {
            Filepath = filepath;
            Count = count;
        }
    }
}