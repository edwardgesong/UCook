﻿using System;
using UIKit;
using CoreGraphics;
using System.Diagnostics;
using System.Threading.Tasks;

namespace UCookC
{
	public class AccountViewController : UIViewController
	{
		UCookTextFiled _usernameTextField;
		UCookTextFiled _passwordTextField;
		UIButton _loginButton;
		UIButton _signupButton;
		LoadingView _loadindView;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			InitViewComponent ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		private void OnLoginClicked () {
			if (InfoIsValid ()) {
				ShowLoadingView ();
				ManagerUserProfile.Instance.StartLogin (_usernameTextField.Text, _passwordTextField.Text, HideLoadingView);
			}
		}

		private void OnSignUpClicked () {
			this.NavigationController.PushViewController (new SignUpViewController (), true);
		}

		private void ShowLoadingView () {
			BeginInvokeOnMainThread (async () => {
				_loadindView = new LoadingView (View.Frame, "Login...");
				this.TabBarController.View.AddSubview (_loadindView);
			});
		}

		private void HideLoadingView () {
			BeginInvokeOnMainThread (async () => {
				_loadindView.Hide ();
			});
		}

		private bool InfoIsValid () {
			bool isValid = true;
			if (string.IsNullOrEmpty (_usernameTextField.Text)) {
				isValid = false;
				var alert = UIAlertController.Create ("Warning", "Please Enter Username", UIAlertControllerStyle.Alert);
				alert.AddAction(UIAlertAction.Create ("OK", UIAlertActionStyle.Cancel, null));

				BeginInvokeOnMainThread (async () => {
					await PresentViewControllerAsync (alert, true);
				});
			}

			if (string.IsNullOrEmpty (_passwordTextField.Text)) {
				isValid = false;
				var alert = UIAlertController.Create ("Warning", "Please Enter Password", UIAlertControllerStyle.Alert);
				alert.AddAction(UIAlertAction.Create ("OK", UIAlertActionStyle.Cancel, null));

				BeginInvokeOnMainThread (async () => {
					await PresentViewControllerAsync (alert, true);
				});
			}
			return isValid;
		}

		private void InitViewComponent () {
			_usernameTextField = new UCookTextFiled();
			_usernameTextField.Center = new CGPoint (View.Frame.Width * 0.5, View.Frame.Height * 0.3);
			_usernameTextField.Placeholder = "User Name";

			_passwordTextField = new UCookTextFiled();
			_passwordTextField.Center = new CGPoint (View.Frame.Width * 0.5, _usernameTextField.Frame.Bottom + UIConstant.ControlSpacing);
			_passwordTextField.Placeholder = "Password";
			_passwordTextField.SecureTextEntry = true;

			_loginButton = new UIButton ();
			_loginButton.Frame = new CGRect (0, 0, UIConstant.LoginButtonWidth, UIConstant.LoginButtonHeight);
			_loginButton.Center = new CGPoint (View.Frame.Width * 0.5, _passwordTextField.Frame.Bottom + UIConstant.ControlSpacing);
			_loginButton.SetTitle ("Log In", UIControlState.Normal);
			_loginButton.BackgroundColor = UIConstant.ThemeColor;
			_loginButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			_loginButton.VerticalAlignment = UIControlContentVerticalAlignment.Center;
			_loginButton.Layer.CornerRadius = 5;
			_loginButton.TouchUpInside += (object sender, EventArgs e) => {
				OnLoginClicked ();
			};

			_signupButton = new UIButton ();
			_signupButton.Frame = new CGRect (_loginButton.Frame.Right - UIConstant.SignUpButtonWidth, _loginButton.Frame.Bottom + UIConstant.ControlSpacingSpecial, UIConstant.SignUpButtonWidth, UIConstant.SignUpButtonHeight);
			_signupButton.SetTitle ("New", UIControlState.Normal);
			_signupButton.SetTitleColor (UIConstant.ThemeColor, UIControlState.Normal);
			_signupButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			_signupButton.VerticalAlignment = UIControlContentVerticalAlignment.Center;
			_signupButton.TouchUpInside += (object sender, EventArgs e) => {
				OnSignUpClicked ();
			};
				
			this.View.AddSubview (_usernameTextField);
			this.View.AddSubview (_passwordTextField);
			this.View.AddSubview (_loginButton);
			this.View.AddSubview (_signupButton);
		}
	}
}

