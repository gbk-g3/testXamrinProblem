using Foundation;
using System;
using VRG.Core.Interfaces;
using WebKit;

namespace VRG.Library.macOS.Provider
{
	public class WebViewProvider : WKNavigationDelegate, IWebViewProvider
	{
		private const string EmptyPage = "about:blank";
		public Uri CurrentUri
		{
			get
			{
				var urlString = this.WebView.Url.AbsoluteString;
				return urlString == EmptyPage ? null : new Uri(urlString);
			}

			set
			{
				OpenUri(value);
			}
		}

		public Func<string, bool> IsLinkClickable { get; set; }
		public event EventHandler DidEndLoading;
		public event EventHandler DidStartLoading;

		public void OpenUri(Uri url)
		{
			WebView.LoadRequest(new NSUrlRequest(new NSUrl(url.ToString())));
		}

		public override void DecidePolicy(WKWebView webView, WKNavigationAction navigationAction, Action<WKNavigationActionPolicy> decisionHandler)
		{
			var link = navigationAction.Request.Url.ToString();

			if ((navigationAction.NavigationType == WKNavigationType.LinkActivated)
				&& !this.IsLinkClickable(link))
			{
				decisionHandler.Invoke(WKNavigationActionPolicy.Cancel);
			}
			else
			{
				decisionHandler.Invoke(WKNavigationActionPolicy.Allow);
			}
		}

		public WKWebView WebView { get; set; }
		public void SetWebViewObject(object webView)
		{
			WebView = (WKWebView)webView;
			WebView.NavigationDelegate = this;
		}

		public void SignOut()
		{
			//TODO Clear cache if necesorry
		}
	}
}
