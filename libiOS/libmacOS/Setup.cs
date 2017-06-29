using AppKit;
using MvvmCross.Core.ViewModels;
using MvvmCross.Mac.Platform;
using MvvmCross.Mac.Views.Presenters;
using MvvmCross.Platform.Platform;

namespace VRG.Library.macOS
{
	public class Setup : MvxMacSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, NSWindow window)
			: base(applicationDelegate, window)
		{
		}

		public Setup(MvxApplicationDelegate applicationDelegate, IMvxMacViewPresenter presenter)
		   : base(applicationDelegate, presenter)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new testMacOSxProblem.App();
		}

		protected override IMvxTrace CreateDebugTrace()
		{
			return new DebugTrace();
		}
	}
}
