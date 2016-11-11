using System;
using UIKit;
using AppodealBinding;
using System.Drawing;
using Foundation;
using CoreGraphics;

namespace demoAppodeal
{

	public class MyDelegate : APDNativeAdLoaderDelegate
	{
		ViewController _controller = null;

		public MyDelegate(ViewController controller)
 		{		
 			_controller = controller;		
 		}
		
		public override void NativeAdLoader(APDNativeAdLoader loader, APDNativeAd nativeAd)
		{
			_controller.MyDelegateServiceDidLoad(nativeAd);
			//	base.BannerDidLoadAd();
		}

				
 	

		//public override void BannerDidLoadAdIsPrecache(bool precache)
		//{
		//	Console.WriteLine("banner height:" + Appodeal.Banner.Frame.Size.Height.ToString());
		////	base.BannerDidLoadAdIsPrecache(precache);
		//}

		//public override void BannerDidRefresh()
		//{
		////	base.BannerDidRefresh();
		//}

		/*public override void BannerDidShow()
		{
			//	base.BannerDidShow();
		}*/
	}
	public partial class ViewController : UIViewController
	{

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		APDNativeAdLoader nativeAdLoader;
		APDNativeAd nativeAd;
		APDMediaView myMediaView;

		public void MyDelegateServiceDidLoad(APDNativeAd nativeAd)
		{
			this.nativeAd = nativeAd;
			UIView view = new UIView();
			view.Frame = new System.Drawing.Rectangle(10, 350, 200, 200);
			view.BackgroundColor = UIColor.FromRGB(96, 36, 36);
			View.AddSubview(view);
			this.nativeAd.AttachToView(view, UIApplication.SharedApplication.Windows[0].RootViewController);
			this.myMediaView.SetNativeAd(this.nativeAd, this);
			View.AddSubview(this.myMediaView);
			Console.WriteLine(this.nativeAd.Title);


		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			Appodeal.SetBannerBackgroundVisible(true);
			Appodeal.SetFramework(APDFramework.APDFrameworkXamarin);
			Appodeal.InitializeWithApiKey("dee74c5129f53fc629a44a690a02296694e3eef99f2d3a5f", AppodealAdType.All);
			Appodeal.CacheAd(AppodealAdType.Banner);
			BannerButton.TouchUpInside += (object sender, EventArgs e) => {
				Appodeal.ShowAd(AppodealShowStyle.BannerTop, UIApplication.SharedApplication.Windows[0].RootViewController);
			};

			InterstitialButton.TouchUpInside += (object sender, EventArgs e) => {
				Appodeal.ShowAd(AppodealShowStyle.Interstitial, UIApplication.SharedApplication.Windows[0].RootViewController);
			};

			VideoButton.TouchUpInside += (object sender, EventArgs e) => {
				Appodeal.ShowAd(AppodealShowStyle.SkippableVideo, UIApplication.SharedApplication.Windows[0].RootViewController);
			};

			LoadButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				this.nativeAdLoader = new APDNativeAdLoader();

				//this.myMediaView.Frame = new System.Drawing.Rectangle(10, 350, 200, 200);

				this.myMediaView = new APDMediaView(new CGRect(10, 350, 200, 200));
				this.nativeAdLoader.Delegate = new MyDelegate(this);
				this.nativeAdLoader.LoadAdWithType(APDNativeAdType.APDNativeAdTypeAuto);
			};
		}
		/*public void Include(APDMediaView mediaView)
		{
			mediaView.Frame = new System.Drawing.Rectangle(10, 350, 200, 200);
		}*/
		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

