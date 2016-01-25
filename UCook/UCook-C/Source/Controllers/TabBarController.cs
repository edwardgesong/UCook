using System;
using CoreGraphics;
using UIKit;
using System.Collections;
using System.Diagnostics;

namespace UCookC
{
	public partial class TabBarController : UITabBarController
	{
		UIViewController _menuViewController, _counterViewController, _accountViewController;
		UINavigationController _menuNavController, _counterNavController, _accountNavCountroller;

		public TabBarController () {
			
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			SetupBottomTabBarView ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		private void SetupBottomTabBarView () {
			_menuViewController = new MenuViewController();
			_menuViewController.View.BackgroundColor = UIColor.Orange;
			_menuViewController.Title = "Menu";

			_counterViewController = new CounterViewController ();
			_counterViewController.View.BackgroundColor = UIColor.Red;
			_counterViewController.Title = "Counter";

			_accountViewController = new AccountViewController ();
			_accountViewController.View.BackgroundColor = UIColor.FromPatternImage (UIUtils.BeginImageProcess("Images/logInPage_bg.png", this));
			_accountViewController.Title = "Account";

			_menuNavController = new UINavigationController (_menuViewController);
			_counterNavController = new UINavigationController (_counterViewController);
			_accountNavCountroller = new UINavigationController (_accountViewController);

			var tabs = new UIViewController [] {
				_menuNavController, _counterNavController, _accountNavCountroller
			};

			ViewControllers = tabs;
		}

//		private UIImage BeginImageProcess (string _imageUrl) {
//			UIGraphics.BeginImageContext (this.View.Frame.Size);
//			UIImage.FromFile (_imageUrl).Draw (this.View.Bounds);
//			UIImage image = UIGraphics.GetImageFromCurrentImageContext ();
//			UIGraphics.EndImageContext ();
//			return image;
//		}
	}
}

