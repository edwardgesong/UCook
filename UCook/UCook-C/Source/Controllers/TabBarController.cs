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
		UCookNavController _menuNavController, _counterNavController, _accountNavCountroller;

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
			_menuViewController.View.BackgroundColor = UIColor.Black;
			_menuViewController.Title = "Menu";

			_counterViewController = new CounterViewController ();
			_counterViewController.View.BackgroundColor = UIColor.White;
			_counterViewController.Title = "Counter";

			_accountViewController = new AccountViewController ();
			_accountViewController.View.BackgroundColor = UIColor.FromPatternImage (UIUtils.BeginImageProcess("Images/icon_menu.png", this));
			_accountViewController.Title = "Account";

			SetMenuNavController ();
			_counterNavController = new UCookNavController (_counterViewController);
			_accountNavCountroller = new UCookNavController (_accountViewController);

			var tabs = new UIViewController [] {
				_menuNavController, _counterNavController, _accountNavCountroller
			};

			ViewControllers = tabs;
		}

		private void SetMenuNavController () {
			_menuNavController = new UCookNavController (_menuViewController);
//			UIImageView menuImgView = new UIImageView ();
//			
//			menuImgView.Image = menuImg;
//			menuImgView.Frame = new CGRect (0, 0, 20, 20);
			UIImage menuImg = UIImage.FromFile ("Images/icon_menu.png");
			UIButton menuButton = new UIButton();
			menuButton = UIButton.FromType (UIButtonType.Custom);
			menuButton.SetBackgroundImage (menuImg, UIControlState.Normal);
			menuButton.Frame = new CGRect (0, 0, 30, 30);
			menuButton.TouchUpInside += (object sender, EventArgs e) => {
				Debug.Print ("Tap Tap Tap");
			};
			_menuNavController.TopViewController.NavigationItem.LeftBarButtonItem = new UIBarButtonItem (menuButton);
		}
	}
}

