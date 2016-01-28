using System;
using UIKit;
using Foundation;
using CoreGraphics;

namespace UCookC
{
	public class UCookTextFiled : UITextField
	{
		public UCookTextFiled ()
		{
			SetCustomStyle ();
		}

		private void SetCustomStyle () {
			this.Layer.BorderColor = UIConstant.ThemeColor.CGColor;
			this.Layer.BorderWidth = 2;
			this.Layer.CornerRadius = 0;
			this.Layer.BackgroundColor = UIColor.White.CGColor;
			this.BorderStyle = UITextBorderStyle.Line;
			this.Frame = UIConstant.TextFieldBorderRect;

		}
	}
}

