# appodeal-xamarin-demo

1) Install Xamarin https://www.xamarin.com/   
2) Download https://bitbucket.org/appodeal/appodeal-xamarin-binding   
3) Right-click on solution and select "Add Existing Project"   
Add AppodealBinding.csproj to demo project   
4) Download Appodeal SDK (framework and resources) https://github.com/appodeal/appodeal-ios-demo/wiki/Getting-Started   
Extract Appodeal from Appodeal.framework and add the extension *.a   
5) Drag and drop Appodeal.a to AppodealBinding project   
Xamarin will create Appodeal.linkwith.cs file   
Replace the code by these lines:   
using System;   
using ObjCRuntime;  
[assembly: LinkWith ("Appodeal.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.Arm64, SmartLink = true, Frameworks = "AdSupport AudioToolbox AVFoundation CFNetwork CoreFoundation CoreGraphics CoreImage CoreLocation CoreMedia CoreMotion CoreTelephony EventKit EventKitUI JavaScriptCore MediaPlayer MessageUI MobileCoreServices QuartzCore SafariServices Security Social StoreKit SystemConfiguration Twitter UIKit WebKit CoreBluetooth", ForceLoad = true, LinkerFlags = "-lz -lsqlite3 -lxml2.2 -lc++ -ObjC")]   
6) Build binding project. Then you may delete it from solution   
7) Select main project, then in main menu choose "Project -> Edit References" and enable AppodealBinding reference or choose .Net tab and locate AppodealBinding.dll in the bin folder of AppodealBinding project, if you have deleted AppodealBinding from demoAppodeal solution in the previous step   
8) Right-click on the Resources folder of demoAppodeal project and select "Add files from folder". Add Resources from Appodeal SDK   
9) Build and run demo project   
