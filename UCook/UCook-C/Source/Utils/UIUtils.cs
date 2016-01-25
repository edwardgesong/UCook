using System;
using CoreGraphics;
using UIKit;

namespace UCookC
{
	public class UIUtils
	{
		public static UIImage BeginImageProcess (string _imageUrl, UIViewController _view) {
			UIGraphics.BeginImageContext (_view.View.Frame.Size);
			UIImage.FromFile (_imageUrl).Draw (_view.View.Bounds);
			UIImage image = UIGraphics.GetImageFromCurrentImageContext ();
			UIGraphics.EndImageContext ();
			return image;
		}
	}
}

