using System;
using UIKit;
using System.Diagnostics;

namespace UCookC
{
	public class UCookNavController : UINavigationController
	{
		public UCookNavController ()
		{
			SetCustomStyle ();
		}

		public UCookNavController (UIViewController rootViewController) 
			: base (rootViewController)
		{
			SetCustomStyle ();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		protected void SetCustomStyle (){
			this.NavigationBar.BarTintColor = UIConstant.ThemeColor;
			this.NavigationBar.Translucent = false;
			this.NavigationBar.BarStyle = UIBarStyle.Black;
		}
	}
}

