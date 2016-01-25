﻿using System;
using UIKit;
using CoreGraphics;
using System.Diagnostics;
using System.Threading.Tasks;

namespace UCookC
{
	public class AccountViewController : UIViewController
	{
		UITextField _usernameTextField;
		UITextField _passwordTextField;
		UIButton _loginButton;
		UIButton _signupButton;
		LoadingView _loadindView;

		public AccountViewController ()
		{
			
		}

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
			BeginInvokeOnMainThread (async () => {
				ShowLoadingView ();
				await Task.Delay (5000);
				HideLoadingView ();
			});

			Task.Run (async () => {
				await ManagerUserProfile.Instance.StartLoadUserProfile (_usernameTextField.Text, _passwordTextField.Text);
			});
		}

		private void OnSignUpClicked () {
			this.NavigationController.PushViewController (new SignUpViewController (), true);
		}

		private void ShowLoadingView () {
			_loadindView = new LoadingView (View.Frame, "Login...");
			this.TabBarController.View.AddSubview (_loadindView);
		}

		private void HideLoadingView () {
			_loadindView.Hide ();
		}

		private void InitViewComponent () {
			_usernameTextField = new UITextField();
			_usernameTextField.Frame = new CGRect (0, 0, UIConstant.TextFieldWidth, UIConstant.LoginButtonHeight);
			_usernameTextField.Center = new CGPoint (View.Frame.Width * 0.5, View.Frame.Height * 0.3);
			_usernameTextField.Layer.BorderColor = UIColor.Black.CGColor;
			_usernameTextField.Layer.BorderWidth = 1;
			_usernameTextField.Layer.CornerRadius = 5;
			_usernameTextField.BorderStyle = UITextBorderStyle.RoundedRect;
			_usernameTextField.Placeholder = "User Name";
			_usernameTextField.BackgroundColor = UIColor.White;

			_passwordTextField = new UITextField();
			_passwordTextField.Frame = new CGRect (0, 0, UIConstant.TextFieldWidth, UIConstant.LoginButtonHeight);
			_passwordTextField.Center = new CGPoint (View.Frame.Width * 0.5, _usernameTextField.Frame.Bottom + UIConstant.ControlSpacing);
			_passwordTextField.Layer.BorderColor = UIColor.Black.CGColor;
			_passwordTextField.Layer.BorderWidth = 1;
			_passwordTextField.Layer.CornerRadius = 5;
			_passwordTextField.BorderStyle = UITextBorderStyle.RoundedRect;
			_passwordTextField.Placeholder = "Password";
			_passwordTextField.BackgroundColor = UIColor.White;
			_passwordTextField.SecureTextEntry = true;

			_loginButton = new UIButton ();
			_loginButton.Frame = new CGRect (0, 0, UIConstant.LoginButtonWidth, UIConstant.LoginButtonHeight);
			_loginButton.Center = new CGPoint (View.Frame.Width * 0.5, _passwordTextField.Frame.Bottom + UIConstant.ControlSpacing);
			_loginButton.SetTitle ("Log In", UIControlState.Normal);
			_loginButton.BackgroundColor = UIColor.Brown;
			_loginButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			_loginButton.VerticalAlignment = UIControlContentVerticalAlignment.Center;
			_loginButton.Layer.CornerRadius = 5;
			_loginButton.TouchUpInside += (object sender, EventArgs e) => {
				OnLoginClicked ();
			};

			_signupButton = new UIButton ();
			_signupButton.Frame = new CGRect (_loginButton.Frame.Right - UIConstant.SignUpButtonWidth, _loginButton.Frame.Bottom + UIConstant.ControlSpacingSpecial, UIConstant.SignUpButtonWidth, UIConstant.SignUpButtonHeight);
			_signupButton.SetTitle ("Sign Up", UIControlState.Normal);
			_signupButton.SetTitleColor (UIColor.Brown, UIControlState.Normal);
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
