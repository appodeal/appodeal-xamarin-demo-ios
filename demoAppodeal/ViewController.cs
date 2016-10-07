using System;
using Foundation;
using UIKit;
using AppodealBinding;
using System.Drawing;

namespace demoAppodeal
{

	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			Appodeal.InitializeWithApiKey("dee74c5129f53fc629a44a690a02296694e3eef99f2d3a5f", AppodealAdType.Interstitial);

			BannerButton.TouchUpInside += (object sender, EventArgs e) => {
				Appodeal.ShowAd(AppodealShowStyle.BannerTop, UIApplication.SharedApplication.Windows[0].RootViewController);
			};

			InterstitialButton.TouchUpInside += (object sender, EventArgs e) => {
				Appodeal.ShowAd(AppodealShowStyle.Interstitial, UIApplication.SharedApplication.Windows[0].RootViewController);
			};

			VideoButton.TouchUpInside += (object sender, EventArgs e) => {
				Appodeal.ShowAd(AppodealShowStyle.RewardedVideo, UIApplication.SharedApplication.Windows[0].RootViewController);
			};
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

