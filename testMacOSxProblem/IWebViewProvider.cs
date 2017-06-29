using System;

namespace VRG.Core.Interfaces
{
	public interface IWebViewProvider
	{
		void SetWebViewObject(object webView);

		Uri CurrentUri { get; set; }

		Func<string, bool> IsLinkClickable { get; set; }

		void OpenUri(Uri url);

		void SignOut();

		event EventHandler DidEndLoading;

		event EventHandler DidStartLoading;
	}
}
