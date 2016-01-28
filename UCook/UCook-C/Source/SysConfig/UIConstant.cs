using System;
using UIKit;
using CoreGraphics;

namespace UCookC
{
	public class UIConstant
	{
		//System
		public static UIColor ThemeColor = UIColor.FromRGB (25, 181, 254);

		//Tab Bar
		public static UIColor TabBarTextSelectedColor = UIColor.FromRGB (25, 181, 254);
		public static UIColor TabBarTextUnselectedColor = UIColor.FromRGB (236, 240, 241);

		//Text Field
		public static CGRect TextFieldBorderRect = new CGRect (0, 0, TextFieldWidth, TextFieldHeight);

		//Account View Controller
		public const double ControlSpacing = 45;
		public const double ControlSpacingSpecial = 10;

		public const double TextFieldWidth = 200;
		public const double TextFieldHeight = 31;

		public const double LoginButtonWidth = 200;
		public const double LoginButtonHeight = 31;

		public const double SignUpButtonWidth = 66.6;
		public const double SignUpButtonHeight = 25;
	}
}

