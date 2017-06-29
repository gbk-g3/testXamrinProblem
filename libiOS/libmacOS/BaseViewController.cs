using AppKit;
using Foundation;
using testMacOSxProblem;
using MvvmCross.Mac.Views;
using testMacOSxProblem.ViewModels;

namespace VRG.Library.macOS
{
	public partial class BaseViewController<V> : MvxViewController where V : BaseViewModel
	{
		public new V ViewModel => base.ViewModel as V;

		public BaseViewController(string nibName, NSBundle bundle) : base(nibName, bundle)
		{

		}

	}
}
