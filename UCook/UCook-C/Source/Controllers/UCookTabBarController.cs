using System;
using UIKit;
using CoreGraphics;
using System.Diagnostics;
using System.Drawing;

namespace UCookC
{
	public class UCookTabBarController : UITabBarController
	{
		UIViewController _menuViewController, _counterViewController, _accountViewController;
		UCookNavController _menuNavController, _counterNavController, _accountNavCountroller;

		public UCookTabBarController ()
		{
			SetCustomStyle ();
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
			_menuViewController.View.BackgroundColor = UIColor.White;
			_menuViewController.Title = "Menu";
			_menuViewController.TabBarItem.Image = UIImage.FromFile ("Images/icon_bookmark.png").Scale (new CGSize (30, 30));


			_counterViewController = new CounterViewController ();
			_counterViewController.View.BackgroundColor = UIColor.White;
			_counterViewController.Title = "Counter";
			_counterViewController.TabBarItem.Image = UIImage.FromFile ("Images/icon_counter.png").Scale (new CGSize (30, 30));

			_accountViewController = new AccountViewController ();
			//			_accountViewController.View.BackgroundColor = UIColor.White;UIUtils.BeginImageProcess("Images/BG_Foods.jpg", this)
			_accountViewController.View.BackgroundColor = UIColor.FromPatternImage (UIImage.FromFile("Images/BG_Foods_1.jpg"));
			_accountViewController.Title = "Account";
			_accountViewController.TabBarItem.Image = UIImage.FromFile ("Images/icon_account.png").Scale (new CGSize (30, 30));

			SetMenuNavController ();
			_counterNavController = new UCookNavController (_counterViewController);
			_accountNavCountroller = new UCookNavController (_accountViewController);

			var tabs = new UIViewController [] {
				_menuNavController, _counterNavController, _accountNavCountroller
			};

			ViewControllers = tabs;
		}

		protected void SetCustomStyle () {
			this.TabBarItem.SetTitleTextAttributes (new UITextAttributes(){TextColor = UIConstant.TabBarTextSelectedColor}, UIControlState.Selected);
			this.TabBarItem.SetTitleTextAttributes (new UITextAttributes(){TextColor = UIConstant.TabBarTextUnselectedColor}, UIControlState.Normal);
		}

		private void SetMenuNavController () {
			_menuNavController = new UCookNavController (_menuViewController);
//			UIButton menuButton = new UIButton (UIButtonType.Custom);
////			menuButton.SetImage (UIImage.FromBundle ("Images/icon_menu.png"), UIControlState.Normal);
//			menuButton.BackgroundColor = UIColor.Black;
//			menuButton.Frame = new CGRect (0, 0, 30, 30);
//			menuButton.TouchUpInside += (object sender, EventArgs e) => {
//				
//			};
//			UIBarButtonItem menuItem = new UIBarButtonItem (menuButton);
			_menuNavController.NavigationItem.LeftBarButtonItem = new UIBarButtonItem(UIImage.FromFile("Images/icon_menu.png"), UIBarButtonItemStyle.Plain, (sender, args)=> {
				Debug.Print ("Tap Tap Tap");
			});
		}
	}
}

