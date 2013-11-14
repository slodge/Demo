using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace Demo.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        public FirstViewModel()
        {
        }

        private async Task GoAsync()
        {
            var client = new HttpClient();
            var result = client.GetAsync("http://bing.com");
            var stream = await result.Result.Content.ReadAsStreamAsync();
            using (var streamReader = new StreamReader(stream))
            {
                Hello = streamReader.ReadToEnd().Length.ToString();
            }
        }

        public ICommand Go
        {
            get { return new MvxCommand(() => GoAsync());}
        }

		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}
    }
}
