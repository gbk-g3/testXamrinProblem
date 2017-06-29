using AppKit;
using Foundation;
using MvvmCross.Mac.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Mac.Platform;
using testMacOSxProblem;

namespace Ringorang.macOS
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate
    {
        public NSWindowController mainWindowController;

        public override void DidFinishLaunching(NSNotification notification)
        {
            mainWindowController = NSStoryboard.FromName("Main", NSBundle.MainBundle).InstantiateInitialController() as NSWindowController;

			MvxMacViewPresenter presenter = new MvxMacViewPresenter(this, mainWindowController.Window);
			var setup = new VRG.Library.macOS.Setup(this, presenter);
			setup.Initialize();

			var startup = Mvx.Resolve<IMvxAppStart>();
			startup.Start();

			mainWindowController.Window.MakeKeyAndOrderFront(this);
		}

    }
}
