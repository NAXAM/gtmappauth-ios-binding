// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using GTMAppAuth;
using GTMSessionFetcherLib;
using UIKit;

namespace GTMAppAuthQs
{
    public partial class GTMAppAuthTVDemoViewController : UIViewController
    {
        public GTMAppAuthTVDemoViewController(IntPtr handle) : base(handle)
        {
        }
        GTMAppAuthFetcherAuthorization _authorization;
        static string kClientID = @"563411199755-d02qno89tblqvv7bl34e894nr8954722.apps.googleusercontent.com";
        static string kClientSecret = @"vmGry0t2Up6BmEPuZ9LJdYU4";
        static string kExampleAuthorizerKey = @"authorization";

        GTMTVAuthorizationCancelBlock _cancelBlock;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            tvLog.Text = @"";
            signInView.Hidden = true;
            cancelSignInButton.Hidden = true;
            tvLog.Selectable = true;
            //tvLog.PanGestureRecognizer.AllowedTouchTypes = new[] { NSNumber.FromLong(UITouchType.Indirect);
            LoadState();
            UpdateUI();
        }

        partial void signin(NSObject sender)
        {
            if (_cancelBlock != null) { cancelSignIn(null); }
            GTMTVServiceConfiguration configuration = GTMTVAuthorizationService.TVConfigurationForGoogle;
            GTMTVAuthorizationRequest request =
                new GTMTVAuthorizationRequest(configuration,
                                              kClientID,
                                              kClientSecret,
                                              new[] { AppAuth.Constants.OIDScopeOpenID.ToString(), AppAuth.Constants.OIDScopeProfile },
                                              null);
            _cancelBlock = GTMTVAuthorizationService.AuthorizeTVRequest(request, (GTMTVAuthorizationResponse response, NSError error) =>
            {
                if (response != null)
                {
                    //TODO: log
                    signInView.Hidden = false;
                    cancelSignInButton.Hidden = false;
                    verificationURLLabel.Text = response.VerificationURL; ;
                    userCodeLabel.Text = response.UserCode;
                }
                else
                {
                    //TODO: log
                }
            }, (GTMAppAuthFetcherAuthorization authorization, NSError error) =>
            {
                signInView.Hidden = true;
                if (authorization != null)
                {
                    SetAuthorization(authorization);
                    //TODO: log
                }
                else
                {

                    SetAuthorization(null);
                    //TODO: log
                }
            });
        }

        partial void cancelSignIn(NSObject sender)
        {
            if (_cancelBlock != null)
            {
                _cancelBlock();
                _cancelBlock = null;
            }
            signInView.Hidden = true;
            cancelSignInButton.Hidden = true;
        }

        void SetAuthorization(GTMAppAuthFetcherAuthorization authorization)
        {
            _authorization = authorization;
            SaveState();
            UpdateUI();
        }

        private void UpdateUI()
        {
            if(_authorization==null){
                signInButtons.Hidden = false;
            }else
            {
				signInButtons.Hidden = _authorization.CanAuthorize();
            }

            signedInButtons.Hidden = !signInButtons.Hidden;
        }
        partial void clearAuthState(NSObject sender)
        {
            SetAuthorization(null);
            //TODO log
        }

        partial void userinfo(NSObject sender)
        {
            //TODO log
            GTMSessionFetcherService fetcherService = new GTMSessionFetcherService();
            fetcherService.Authorizer = this._authorization;
            NSUrl userinfoEndpoint = NSUrl.FromString("https://www.googleapis.com/oauth2/v3/userinfo");
            GTMSessionFetcher fetcher = fetcherService.FetcherWithURL(userinfoEndpoint);
            fetcher.BeginFetchWithCompletionHandler((NSData data, NSError error) =>
            {
                if (error != null)
                {
                    if (error.Domain.Equals(AppAuth.Constants.OIDOAuthTokenErrorDomain))
                    {
                        SetAuthorization(null);
                        //TODO log
                    }
                    else
                    {
                        //TODO log
                    }
                    return;
                }
                NSError jsonError = null;
                var jsonDictionaryOrArray = NSJsonSerialization.Deserialize(data, 0, out jsonError);
                if (jsonError != null)
                {
                    //TODO log
                    return;
                }
                //TODO log
                tvLog.Text = (jsonDictionaryOrArray as NSDictionary)["family_name"].ToString() + " " + (jsonDictionaryOrArray as NSDictionary)["given_name"].ToString();
            });
        }

        private void LoadState()
        {
            GTMAppAuthFetcherAuthorization authorization = GTMAppAuthFetcherAuthorization_Keychain.AuthorizationFromKeychainForName(_authorization, kExampleAuthorizerKey);
            SetAuthorization(authorization);
            if (authorization != null)
            {
                //TODO log
            }
        }

        private void SaveState()
        {
            if (_authorization != null)
            {
                if (_authorization.CanAuthorize())
                {
                    _authorization.SaveAuthorization(_authorization, kExampleAuthorizerKey);
                }
                else
                {
                    _authorization.RemoveAuthorizationFromKeychainForName(kExampleAuthorizerKey);
                }
            }
        }

        //void logMessage(string format)
        //{
        //    NSDateFormatter dateFormatter = new NSDateFormatter();
        //    dateFormatter.DateFormat = "hh:mm:ss";

        //}
    }
}