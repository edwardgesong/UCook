using System;
using UIKit;
using CoreGraphics;
using System.Threading.Tasks;

namespace UCookC
{
	public class SignUpViewController : UIViewController
	{
		UCookTextFiled _usernameTextField, _passwordTextField, _passwordConfirmTextField;
		UIButton _signUpButton;
		LoadingView _loadingView;

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			ParentViewController.TabBarController.TabBar.Hidden = true;
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			ParentViewController.TabBarController.TabBar.Hidden = false;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			this.View.BackgroundColor = UIColor.White;
			SetupUIComponent ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		private bool PasswordIsMatch () {
			bool isMatch = false;
			if (_passwordTextField.Text.Equals (_passwordConfirmTextField.Text))
				isMatch = true;
			return isMatch;
		}

		private void OnSignUpButtonClicked () {
			if (InfoIsValid()) {
				ShowLoadingView();
				ManagerUserProfile.Instance.StartSignUp (_usernameTextField.Text, _passwordTextField.Text, HideLoadingView);
			}
		}

		private bool InfoIsValid () {
			bool isValid = true;
			if (string.IsNullOrEmpty (_usernameTextField.Text)) {
				isValid = false;
				var alert = UIAlertController.Create ("Warning", "Please Enter User Name", UIAlertControllerStyle.Alert);
				alert.AddAction(UIAlertAction.Create ("OK", UIAlertActionStyle.Cancel, null));

				BeginInvokeOnMainThread (async () => {
					await PresentViewControllerAsync (alert, true);
				});
			}

			if (string.IsNullOrEmpty (_passwordTextField.Text) || string.IsNullOrEmpty (_passwordConfirmTextField.Text)) {
				isValid = false;
				var alert = UIAlertController.Create ("Warning", "Please Enter Password", UIAlertControllerStyle.Alert);
				alert.AddAction(UIAlertAction.Create ("OK", UIAlertActionStyle.Cancel, null));

				BeginInvokeOnMainThread (async () => {
					await PresentViewControllerAsync (alert, true);
				});
			}

			if (!PasswordIsMatch ()) {
				_passwordTextField.Text = string.Empty;
				_passwordConfirmTextField.Text = string.Empty;
				isValid = false;
				var alert = UIAlertController.Create ("Warning", "Password do not match!", UIAlertControllerStyle.Alert);
				alert.AddAction(UIAlertAction.Create ("OK", UIAlertActionStyle.Cancel, null));

				BeginInvokeOnMainThread (async () => {
					await PresentViewControllerAsync (alert, true);
				});
			}
			return isValid;
		}

		private void ShowLoadingView () {
			BeginInvokeOnMainThread (async () => {
				_loadingView = new LoadingView (View.Frame, "Sign Up...");
				this.TabBarController.View.AddSubview (_loadingView);
			});
		}

		private void HideLoadingView () {
			BeginInvokeOnMainThread (async () => {
				_loadingView.Hide ();
			});
		}

		private void SetupUIComponent () {
			_usernameTextField = new UCookTextFiled();
			_usernameTextField.Center = new CGPoint (View.Frame.Width * 0.5, View.Frame.Height * 0.4);
			_usernameTextField.Placeholder = "User Name";

			_passwordTextField = new UCookTextFiled();
			_passwordTextField.Center = new CGPoint (View.Frame.Width * 0.5, _usernameTextField.Frame.Bottom + UIConstant.ControlSpacing);
			_passwordTextField.Placeholder = "Password";
			_passwordTextField.SecureTextEntry = true;

			_passwordConfirmTextField = new UCookTextFiled();
			_passwordConfirmTextField.Center = new CGPoint (View.Frame.Width * 0.5, _passwordTextField.Frame.Bottom + UIConstant.ControlSpacing);
			_passwordConfirmTextField.Placeholder = "Confirm Password";
			_passwordConfirmTextField.SecureTextEntry = true;

			_signUpButton = new UIButton ();
			_signUpButton.Frame = new CGRect (0, 0, UIConstant.LoginButtonWidth, UIConstant.LoginButtonHeight);
			_signUpButton.Center = new CGPoint (View.Frame.Width * 0.5, _passwordConfirmTextField.Frame.Bottom + UIConstant.ControlSpacing);
			_signUpButton.SetTitle ("Sign Up", UIControlState.Normal);
			_signUpButton.BackgroundColor = UIConstant.ThemeColor;
			_signUpButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			_signUpButton.VerticalAlignment = UIControlContentVerticalAlignment.Center;
			_signUpButton.Layer.CornerRadius = 5;
			_signUpButton.TouchUpInside += (object sender, EventArgs e) => {
				OnSignUpButtonClicked ();
			};

			this.View.BackgroundColor = UIColor.White;
			this.View.AddSubview (_usernameTextField);
			this.View.AddSubview (_passwordTextField);
			this.View.AddSubview (_passwordConfirmTextField);
			this.View.AddSubview (_signUpButton);
		}
	}
}

