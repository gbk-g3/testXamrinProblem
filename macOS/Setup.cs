using AppKit;
using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Mac.Platform;
using MvvmCross.Mac.Views.Presenters;
using MvvmCross.Platform.Platform;
using VRG.Library.macOS;

namespace Ringorang.macOS
{
    public class Setup : MvxMacSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, NSWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected override IMvxApplication CreateApp ()
        {
            return new testMacOSxProblem.App();
        }
        
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}
