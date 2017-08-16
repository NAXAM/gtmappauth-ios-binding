// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace GTMAppAuthQs
{
	[Register ("GTMAppAuthTVDemoViewController")]
	partial class GTMAppAuthTVDemoViewController
	{
		[Outlet]
		UIKit.UIButton cancelSignInButton { get; set; }

		[Outlet]
		UIKit.UIView signedInButtons { get; set; }

		[Outlet]
		UIKit.UIView signInButtons { get; set; }

		[Outlet]
		UIKit.UIView signInView { get; set; }

		[Outlet]
		UIKit.UITextView tvLog { get; set; }

		[Outlet]
		UIKit.UILabel userCodeLabel { get; set; }

		[Outlet]
		UIKit.UILabel verificationURLLabel { get; set; }

		[Action ("cancelSignIn:")]
		partial void cancelSignIn (Foundation.NSObject sender);

		[Action ("clearAuthState:")]
		partial void clearAuthState (Foundation.NSObject sender);

		[Action ("signin:")]
		partial void signin (Foundation.NSObject sender);

		[Action ("userinfo:")]
		partial void userinfo (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (signedInButtons != null) {
				signedInButtons.Dispose ();
				signedInButtons = null;
			}

			if (cancelSignInButton != null) {
				cancelSignInButton.Dispose ();
				cancelSignInButton = null;
			}

			if (signInButtons != null) {
				signInButtons.Dispose ();
				signInButtons = null;
			}

			if (signInView != null) {
				signInView.Dispose ();
				signInView = null;
			}

			if (tvLog != null) {
				tvLog.Dispose ();
				tvLog = null;
			}

			if (userCodeLabel != null) {
				userCodeLabel.Dispose ();
				userCodeLabel = null;
			}

			if (verificationURLLabel != null) {
				verificationURLLabel.Dispose ();
				verificationURLLabel = null;
			}
		}
	}
}
