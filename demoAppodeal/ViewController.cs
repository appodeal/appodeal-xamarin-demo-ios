using System;
using Foundation;
using UIKit;
using AppodealBinding;
using System.Drawing;

namespace demoAppodeal
{

	public class MyDelegate : AppodealNativeAdServiceDelegate
	{
		ViewController _controller = null;

		public MyDelegate(ViewController controller)
		{
			_controller = controller;
		}

		public override void NativeAdServiceDidLoad(AppodealNativeAd nativeAd)
		{
			_controller.MyDelegateServiceDidLoad(nativeAd);
		}
	}

	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		//AppodealNativeAdViewAttributes attributes;
		//AppodealNativeAdView adView;
		AppodealNativeAdService adService;
		AppodealNativeAd ad;

		public void MyDelegateServiceDidLoad(AppodealNativeAd nativeAd)
		{
//			this.ad = new AppodealNativeAd ();
//			this.ad = nativeAd;
//
//			this.attributes = new AppodealNativeAdViewAttributes();
//			this.attributes.Width=320;
//			this.attributes.Heigth=50;
//
//			this.adView = AppodealNativeAdView.NativeAdViewWithType(AppodealNativeAdViewType.ContentStream, this.ad, this.attributes, UIApplication.SharedApplication.Windows[0].RootViewController);
//			UIView view = new UIView ();
//			view.Frame = new System.Drawing.Rectangle(10, 400, 320, 50);
//			view.AddSubview(this.adView);
//			View.AddSubview(view);

			this.ad = new AppodealNativeAd ();
			this.ad = nativeAd;

			UIView view = new UIView ();
			view.Frame = new System.Drawing.Rectangle(10, 350, 200, 200);

			var data = NSData.FromUrl(this.ad.Image.ImageUrl);
	
			UIImageView imageview = new UIImageView (UIImage.LoadFromData (data));
			imageview.Frame = new System.Drawing.Rectangle(0 ,0, 50,50);

			view.AddSubview(imageview);

			View.AddSubview(view);
			this.ad.AttachToView(view, UIApplication.SharedApplication.Windows[0].RootViewController);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			Appodeal.DisableNetworkForAdType(AppodealAdType.All, NetworkNames.kAppodealFacebookNetworkName);
			Appodeal.InitializeWithApiKey("dee74c5129f53fc629a44a690a02296694e3eef99f2d3a5f", AppodealAdType.All);

			BannerButton.TouchUpInside += (object sender, EventArgs e) => {
				Appodeal.ShowAd(AppodealShowStyle.BannerTop, UIApplication.SharedApplication.Windows[0].RootViewController);
			};

			InterstitialButton.TouchUpInside += (object sender, EventArgs e) => {
				Appodeal.ShowAd(AppodealShowStyle.Interstitial, UIApplication.SharedApplication.Windows[0].RootViewController);
			};

			VideoButton.TouchUpInside += (object sender, EventArgs e) => {
				Appodeal.ShowAd(AppodealShowStyle.RewardedVideo, UIApplication.SharedApplication.Windows[0].RootViewController);
			};

			LoadButton.TouchUpInside += (object sender, EventArgs e) => {
				adService = new AppodealNativeAdService ();
				adService.Delegate = new MyDelegate(this);
				adService.LoadAd();
			};
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

