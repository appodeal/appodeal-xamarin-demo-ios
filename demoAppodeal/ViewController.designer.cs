// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace demoAppodeal
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton BannerButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton InterstitialButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton LoadButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton VideoButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (BannerButton != null) {
				BannerButton.Dispose ();
				BannerButton = null;
			}
			if (InterstitialButton != null) {
				InterstitialButton.Dispose ();
				InterstitialButton = null;
			}
			if (LoadButton != null) {
				LoadButton.Dispose ();
				LoadButton = null;
			}
			if (VideoButton != null) {
				VideoButton.Dispose ();
				VideoButton = null;
			}
		}
	}
}
