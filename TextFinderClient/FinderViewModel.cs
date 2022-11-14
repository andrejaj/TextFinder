using Infrastructure.Client;
using Infrastructure.Extension;
using Infrastructure.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Web;

namespace TextFinderClient
{
    public class FinderViewModel : INotifyPropertyChanged
    {
        public string Filename { get; set; }
        public string TextToFind { get; set; }

        public ObservableCollection<WordCount> Data { get; set; }

        private readonly RestAPIClient _client;

        public event PropertyChangedEventHandler? PropertyChanged;

        public FinderViewModel() 
        { 
            _client = new RestAPIClient(); 
            Data = new ObservableCollection<WordCount>();
        }
        public async Task FindText()
        {
            Data.Clear();
            var text = HttpUtility.UrlEncode(TextToFind);
            var filepath = HttpUtility.UrlEncode(Filename);
            var requestParam = new Uri($"https://localhost:5001/api/TextFinder?Path={filepath}&Word={text}");
            var data = await _client.GetResponseAsync(requestParam);
            Data.AddRange<WordCount>(data);
        }
    }
}
