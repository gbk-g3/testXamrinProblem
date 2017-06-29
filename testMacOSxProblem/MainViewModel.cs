using MvvmCross.Core.ViewModels;
using System;
using System.Linq;
using VRG.Core.Interfaces;

namespace testMacOSxProblem.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
        private const string PlayGameUrl = "google.com";

		public IWebViewProvider Provider { get; set; }


		public bool ValidateLink(string link)
		{
			if (link.Contains(PlayGameUrl))
			{
				var arguments = new Uri(link).Query
				.Substring(1) // Remove '?'
				.Split('&')
				.Select(q => q.Split('='))
				.ToDictionary(q => q.FirstOrDefault(), q => q.Skip(1).FirstOrDefault());

				NavigateNext();
				return false;
			}
		
			return true;
		}
		public Func<string, bool> IsLinkClickable
		{
			get
			{
				return ValidateLink;
			}
		}

		public Uri LoginUri
		{
			get
			{
				return new Uri("https://google.com");
			}
		}

		public IMvxCommand NavigateNextCommand => new MvxCommand(NavigateNext);

		private void NavigateNext()
		{
			ShowViewModel<MainViewModel>();
		}
	}
}
