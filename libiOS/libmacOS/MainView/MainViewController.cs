using testMacOSxProblem;
using MvvmCross.Binding.BindingContext;
using WebKit;
using MvvmCross.Platform;
using AppKit;
using VRG.Core.Interfaces;
using VRG.Library.macOS.Provider;
using testMacOSxProblem.ViewModels;

namespace VRG.Library.macOS.Views.MainViewController
{
    public partial class MainViewController : BaseViewController<MainViewModel>
    {
        private WKWebView webView;
        private IWebViewProvider provider;

        public MainViewController() : base("MainView", null)
        {
        
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            webView = new WKWebView(View.Frame, new WKWebViewConfiguration());
            webView.AutoresizingMask = NSViewResizingMask.WidthSizable | NSViewResizingMask.HeightSizable;
            View.AddSubview(webView);

            provider = new WebViewProvider();
            provider.SetWebViewObject(webView);
            ViewModel.Provider = provider;

            var set = this.CreateBindingSet<MainViewController, MainViewModel>();
            set.Bind(this.provider).For(be => be.CurrentUri).To(vm => vm.LoginUri);
            set.Bind(this.provider).For(be => be.IsLinkClickable).To(vm => vm.IsLinkClickable);
            set.Apply();
        }
    }
}
