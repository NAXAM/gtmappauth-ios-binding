﻿using System;
using Foundation;
using ObjCRuntime;

namespace AppAuth
{
	// typedef void (^OIDAuthStateAction)(NSString * _Nullable, NSString * _Nullable, NSError * _Nullable);
	delegate void OIDAuthStateAction ([NullAllowed] string arg0, [NullAllowed] string arg1, [NullAllowed] NSError arg2);

	// typedef void (^OIDAuthStateAuthorizationCallback)(OIDAuthState * _Nullable, NSError * _Nullable);
	delegate void OIDAuthStateAuthorizationCallback ([NullAllowed] OIDAuthState arg0, [NullAllowed] NSError arg1);

	// @interface OIDAuthState : NSObject <NSSecureCoding>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface OIDAuthState : INSSecureCoding
	{
		// @property (readonly, nonatomic) NSString * _Nullable refreshToken;
		[NullAllowed, Export ("refreshToken")]
		string RefreshToken { get; }

		// @property (readonly, nonatomic) NSString * _Nullable scope;
		[NullAllowed, Export ("scope")]
		string Scope { get; }

		// @property (readonly, nonatomic) OIDAuthorizationResponse * _Nonnull lastAuthorizationResponse;
		[Export ("lastAuthorizationResponse")]
		OIDAuthorizationResponse LastAuthorizationResponse { get; }

		// @property (readonly, nonatomic) OIDTokenResponse * _Nullable lastTokenResponse;
		[NullAllowed, Export ("lastTokenResponse")]
		OIDTokenResponse LastTokenResponse { get; }

		// @property (readonly, nonatomic) OIDRegistrationResponse * _Nullable lastRegistrationResponse;
		[NullAllowed, Export ("lastRegistrationResponse")]
		OIDRegistrationResponse LastRegistrationResponse { get; }

		// @property (readonly, nonatomic) NSError * _Nullable authorizationError;
		[NullAllowed, Export ("authorizationError")]
		NSError AuthorizationError { get; }

		// @property (readonly, nonatomic) BOOL isAuthorized;
		[Export ("isAuthorized")]
		bool IsAuthorized { get; }

		[Wrap ("WeakStateChangeDelegate")]
		[NullAllowed]
		OIDAuthStateChangeDelegate StateChangeDelegate { get; set; }

		// @property (nonatomic, weak) id<OIDAuthStateChangeDelegate> _Nullable stateChangeDelegate;
		[NullAllowed, Export ("stateChangeDelegate", ArgumentSemantic.Weak)]
		NSObject WeakStateChangeDelegate { get; set; }

		[Wrap ("WeakErrorDelegate")]
		[NullAllowed]
		OIDAuthStateErrorDelegate ErrorDelegate { get; set; }

		// @property (nonatomic, weak) id<OIDAuthStateErrorDelegate> _Nullable errorDelegate;
		[NullAllowed, Export ("errorDelegate", ArgumentSemantic.Weak)]
		NSObject WeakErrorDelegate { get; set; }

		// +(id<OIDAuthorizationFlowSession> _Nonnull)authStateByPresentingAuthorizationRequest:(OIDAuthorizationRequest * _Nonnull)authorizationRequest UICoordinator:(id<OIDAuthorizationUICoordinator> _Nonnull)UICoordinator callback:(OIDAuthStateAuthorizationCallback _Nonnull)callback;
		[Static]
		[Export ("authStateByPresentingAuthorizationRequest:UICoordinator:callback:")]
		OIDAuthorizationFlowSession AuthStateByPresentingAuthorizationRequest (OIDAuthorizationRequest authorizationRequest, OIDAuthorizationUICoordinator UICoordinator, OIDAuthStateAuthorizationCallback callback);

		// -(instancetype _Nonnull)initWithAuthorizationResponse:(OIDAuthorizationResponse * _Nonnull)authorizationResponse;
		[Export ("initWithAuthorizationResponse:")]
		IntPtr Constructor (OIDAuthorizationResponse authorizationResponse);

		// -(instancetype _Nonnull)initWithAuthorizationResponse:(OIDAuthorizationResponse * _Nonnull)authorizationResponse tokenResponse:(OIDTokenResponse * _Nullable)tokenResponse;
		[Export ("initWithAuthorizationResponse:tokenResponse:")]
		IntPtr Constructor (OIDAuthorizationResponse authorizationResponse, [NullAllowed] OIDTokenResponse tokenResponse);

		// -(instancetype _Nonnull)initWithRegistrationResponse:(OIDRegistrationResponse * _Nonnull)registrationResponse;
		[Export ("initWithRegistrationResponse:")]
		IntPtr Constructor (OIDRegistrationResponse registrationResponse);

		// -(instancetype _Nonnull)initWithAuthorizationResponse:(OIDAuthorizationResponse * _Nullable)authorizationResponse tokenResponse:(OIDTokenResponse * _Nullable)tokenResponse registrationResponse:(OIDRegistrationResponse * _Nullable)registrationResponse __attribute__((objc_designated_initializer));
		[Export ("initWithAuthorizationResponse:tokenResponse:registrationResponse:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] OIDAuthorizationResponse authorizationResponse, [NullAllowed] OIDTokenResponse tokenResponse, [NullAllowed] OIDRegistrationResponse registrationResponse);

		// -(void)updateWithAuthorizationResponse:(OIDAuthorizationResponse * _Nullable)authorizationResponse error:(NSError * _Nullable)error;
		[Export ("updateWithAuthorizationResponse:error:")]
		void UpdateWithAuthorizationResponse ([NullAllowed] OIDAuthorizationResponse authorizationResponse, [NullAllowed] NSError error);

		// -(void)updateWithTokenResponse:(OIDTokenResponse * _Nullable)tokenResponse error:(NSError * _Nullable)error;
		[Export ("updateWithTokenResponse:error:")]
		void UpdateWithTokenResponse ([NullAllowed] OIDTokenResponse tokenResponse, [NullAllowed] NSError error);

		// -(void)updateWithRegistrationResponse:(OIDRegistrationResponse * _Nullable)registrationResponse;
		[Export ("updateWithRegistrationResponse:")]
		void UpdateWithRegistrationResponse ([NullAllowed] OIDRegistrationResponse registrationResponse);

		// -(void)updateWithAuthorizationError:(NSError * _Nonnull)authorizationError;
		[Export ("updateWithAuthorizationError:")]
		void UpdateWithAuthorizationError (NSError authorizationError);

		// -(void)performActionWithFreshTokens:(OIDAuthStateAction _Nonnull)action;
		[Export ("performActionWithFreshTokens:")]
		void PerformActionWithFreshTokens (OIDAuthStateAction action);

		// -(void)performActionWithFreshTokens:(OIDAuthStateAction _Nonnull)action additionalRefreshParameters:(NSDictionary<NSString *,NSString *> * _Nullable)additionalParameters;
		[Export ("performActionWithFreshTokens:additionalRefreshParameters:")]
		void PerformActionWithFreshTokens (OIDAuthStateAction action, [NullAllowed] NSDictionary<NSString, NSString> additionalParameters);

		// -(void)setNeedsTokenRefresh;
		[Export ("setNeedsTokenRefresh")]
		void SetNeedsTokenRefresh ();

		// -(OIDTokenRequest * _Nullable)tokenRefreshRequest;
		[NullAllowed, Export ("tokenRefreshRequest")]
		
		OIDTokenRequest TokenRefreshRequest { get; }

		// -(OIDTokenRequest * _Nullable)tokenRefreshRequestWithAdditionalParameters:(NSDictionary<NSString *,NSString *> * _Nullable)additionalParameters;
		[Export ("tokenRefreshRequestWithAdditionalParameters:")]
		[return: NullAllowed]
		OIDTokenRequest TokenRefreshRequestWithAdditionalParameters ([NullAllowed] NSDictionary<NSString, NSString> additionalParameters);

		// -(void)withFreshTokensPerformAction:(OIDAuthStateAction _Nonnull)action __attribute__((deprecated("Use OIDAuthState.performActionWithFreshTokens:")));
		[Export ("withFreshTokensPerformAction:")]
		void WithFreshTokensPerformAction (OIDAuthStateAction action);
	}

	// @protocol OIDAuthStateChangeDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface OIDAuthStateChangeDelegate
	{
		// @required -(void)didChangeState:(OIDAuthState * _Nonnull)state;
		[Abstract]
		[Export ("didChangeState:")]
		void DidChangeState (OIDAuthState state);
	}

	// @protocol OIDAuthStateErrorDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface OIDAuthStateErrorDelegate
	{
		// @required -(void)authState:(OIDAuthState * _Nonnull)state didEncounterAuthorizationError:(NSError * _Nonnull)error;
		[Abstract]
		[Export ("authState:didEncounterAuthorizationError:")]
		void DidEncounterAuthorizationError (OIDAuthState state, NSError error);

		// @optional -(void)authState:(OIDAuthState * _Nonnull)state didEncounterTransientError:(NSError * _Nonnull)error;
		[Export ("authState:didEncounterTransientError:")]
		void DidEncounterTransientError (OIDAuthState state, NSError error);
	}

    //[Static]
	partial interface Constants
	{
		// extern NSString *const OIDResponseTypeCode;
		[Field("OIDResponseTypeCode", "__Internal")]
		NSString OIDResponseTypeCode { get; }

		// extern NSString *const OIDResponseTypeToken;
		[Field("OIDResponseTypeToken", "__Internal")]
		NSString OIDResponseTypeToken { get; }

		// extern NSString *const OIDResponseTypeIDToken;
		[Field("OIDResponseTypeIDToken", "__Internal")]
		NSString OIDResponseTypeIDToken { get; }

		// extern NSString *const OIDScopeOpenID;
		[Field("OIDScopeOpenID", "__Internal")]
		NSString OIDScopeOpenID { get; }

		// extern NSString *const OIDScopeProfile;
		[Field("OIDScopeProfile", "__Internal")]
		NSString OIDScopeProfile { get; }

		// extern NSString *const OIDScopeEmail;
		[Field("OIDScopeEmail", "__Internal")]
		NSString OIDScopeEmail { get; }

		// extern NSString *const OIDScopeAddress;
		[Field("OIDScopeAddress", "__Internal")]
		NSString OIDScopeAddress { get; }

		// extern NSString *const OIDScopePhone;
		//[Export("OIDScopePhone")]
		//NSString OIDScopePhone { get; }

		// extern NSString *const _Nonnull OIDOAuthorizationRequestCodeChallengeMethodS256;
		[Field("OIDOAuthorizationRequestCodeChallengeMethodS256", "__Internal")]
		NSString OIDOAuthorizationRequestCodeChallengeMethodS256 { get; }
	}

	// @interface OIDAuthorizationRequest : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface OIDAuthorizationRequest : INSCopying, INSSecureCoding
	{
		// @property (readonly, nonatomic) OIDServiceConfiguration * _Nonnull configuration;
		[Export ("configuration")]
		OIDServiceConfiguration Configuration { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull responseType;
		[Export ("responseType")]
		string ResponseType { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull clientID;
		[Export ("clientID")]
		string ClientID { get; }

		// @property (readonly, nonatomic) NSString * _Nullable clientSecret;
		[NullAllowed, Export ("clientSecret")]
		string ClientSecret { get; }

		// @property (readonly, nonatomic) NSString * _Nullable scope;
		[NullAllowed, Export ("scope")]
		string Scope { get; }

		// @property (readonly, nonatomic) NSURL * _Nullable redirectURL;
		[NullAllowed, Export ("redirectURL")]
		NSUrl RedirectURL { get; }

		// @property (readonly, nonatomic) NSString * _Nullable state;
		[NullAllowed, Export ("state")]
		string State { get; }

		// @property (readonly, nonatomic) NSString * _Nullable codeVerifier;
		[NullAllowed, Export ("codeVerifier")]
		string CodeVerifier { get; }

		// @property (readonly, nonatomic) NSString * _Nullable codeChallenge;
		[NullAllowed, Export ("codeChallenge")]
		string CodeChallenge { get; }

		// @property (readonly, nonatomic) NSString * _Nullable codeChallengeMethod;
		[NullAllowed, Export ("codeChallengeMethod")]
		string CodeChallengeMethod { get; }

		// @property (readonly, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable additionalParameters;
		[NullAllowed, Export ("additionalParameters")]
		NSDictionary<NSString, NSString> AdditionalParameters { get; }

		// -(instancetype _Nonnull)initWithConfiguration:(OIDServiceConfiguration * _Nonnull)configuration clientId:(NSString * _Nonnull)clientID scopes:(NSArray<NSString *> * _Nullable)scopes redirectURL:(NSURL * _Nonnull)redirectURL responseType:(NSString * _Nonnull)responseType additionalParameters:(NSDictionary<NSString *,NSString *> * _Nullable)additionalParameters;
		[Export ("initWithConfiguration:clientId:scopes:redirectURL:responseType:additionalParameters:")]
		IntPtr Constructor (OIDServiceConfiguration configuration, string clientID, [NullAllowed] string[] scopes, NSUrl redirectURL, string responseType, [NullAllowed] NSDictionary<NSString, NSString> additionalParameters);

		// -(instancetype _Nonnull)initWithConfiguration:(OIDServiceConfiguration * _Nonnull)configuration clientId:(NSString * _Nonnull)clientID clientSecret:(NSString * _Nullable)clientSecret scopes:(NSArray<NSString *> * _Nullable)scopes redirectURL:(NSURL * _Nonnull)redirectURL responseType:(NSString * _Nonnull)responseType additionalParameters:(NSDictionary<NSString *,NSString *> * _Nullable)additionalParameters;
		[Export ("initWithConfiguration:clientId:clientSecret:scopes:redirectURL:responseType:additionalParameters:")]
		IntPtr Constructor (OIDServiceConfiguration configuration, string clientID, [NullAllowed] string clientSecret, [NullAllowed] string[] scopes, NSUrl redirectURL, string responseType, [NullAllowed] NSDictionary<NSString, NSString> additionalParameters);

		// -(instancetype _Nonnull)initWithConfiguration:(OIDServiceConfiguration * _Nonnull)configuration clientId:(NSString * _Nonnull)clientID clientSecret:(NSString * _Nullable)clientSecret scope:(NSString * _Nullable)scope redirectURL:(NSURL * _Nullable)redirectURL responseType:(NSString * _Nonnull)responseType state:(NSString * _Nullable)state codeVerifier:(NSString * _Nullable)codeVerifier codeChallenge:(NSString * _Nullable)codeChallenge codeChallengeMethod:(NSString * _Nullable)codeChallengeMethod additionalParameters:(NSDictionary<NSString *,NSString *> * _Nullable)additionalParameters __attribute__((objc_designated_initializer));
		[Export ("initWithConfiguration:clientId:clientSecret:scope:redirectURL:responseType:state:codeVerifier:codeChallenge:codeChallengeMethod:additionalParameters:")]
		[DesignatedInitializer]
		IntPtr Constructor (OIDServiceConfiguration configuration, string clientID, [NullAllowed] string clientSecret, [NullAllowed] string scope, [NullAllowed] NSUrl redirectURL, string responseType, [NullAllowed] string state, [NullAllowed] string codeVerifier, [NullAllowed] string codeChallenge, [NullAllowed] string codeChallengeMethod, [NullAllowed] NSDictionary<NSString, NSString> additionalParameters);

		// -(NSURL * _Nonnull)authorizationRequestURL;
		[Export ("authorizationRequestURL")]
		
		NSUrl AuthorizationRequestURL { get; }

		// +(NSString * _Nullable)generateState;
		[Static]
		[NullAllowed, Export ("generateState")]
		
		string GenerateState { get; }

		// +(NSString * _Nullable)generateCodeVerifier;
		[Static]
		[NullAllowed, Export ("generateCodeVerifier")]
	
		string GenerateCodeVerifier { get; }

		// +(NSString * _Nullable)codeChallengeS256ForVerifier:(NSString * _Nullable)codeVerifier;
		[Static]
		[Export ("codeChallengeS256ForVerifier:")]
		[return: NullAllowed]
		string CodeChallengeS256ForVerifier ([NullAllowed] string codeVerifier);
	}

	// @interface OIDAuthorizationResponse : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface OIDAuthorizationResponse : INSCopying, INSSecureCoding
	{
		// @property (readonly, nonatomic) OIDAuthorizationRequest * _Nonnull request;
		[Export ("request")]
		OIDAuthorizationRequest Request { get; }

		// @property (readonly, nonatomic) NSString * _Nullable authorizationCode;
		[NullAllowed, Export ("authorizationCode")]
		string AuthorizationCode { get; }

		// @property (readonly, nonatomic) NSString * _Nullable state;
		[NullAllowed, Export ("state")]
		string State { get; }

		// @property (readonly, nonatomic) NSString * _Nullable accessToken;
		[NullAllowed, Export ("accessToken")]
		string AccessToken { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable accessTokenExpirationDate;
		[NullAllowed, Export ("accessTokenExpirationDate")]
		NSDate AccessTokenExpirationDate { get; }

		// @property (readonly, nonatomic) NSString * _Nullable tokenType;
		[NullAllowed, Export ("tokenType")]
		string TokenType { get; }

		// @property (readonly, nonatomic) NSString * _Nullable idToken;
		[NullAllowed, Export ("idToken")]
		string IdToken { get; }

		// @property (readonly, nonatomic) NSString * _Nullable scope;
		[NullAllowed, Export ("scope")]
		string Scope { get; }

		// @property (readonly, nonatomic) NSDictionary<NSString *,NSObject<NSCopying> *> * _Nullable additionalParameters;
		[NullAllowed, Export ("additionalParameters")]
		NSDictionary<NSString, NSCopying> AdditionalParameters { get; }

		// -(instancetype _Nonnull)initWithRequest:(OIDAuthorizationRequest * _Nonnull)request parameters:(NSDictionary<NSString *,NSObject<NSCopying> *> * _Nonnull)parameters __attribute__((objc_designated_initializer));
		[Export ("initWithRequest:parameters:")]
		[DesignatedInitializer]
		IntPtr Constructor (OIDAuthorizationRequest request, NSDictionary<NSString, NSCopying> parameters);

		// -(OIDTokenRequest * _Nullable)tokenExchangeRequest;
		[NullAllowed, Export ("tokenExchangeRequest")]
		
		OIDTokenRequest TokenExchangeRequest { get; }

		// -(OIDTokenRequest * _Nullable)tokenExchangeRequestWithAdditionalParameters:(NSDictionary<NSString *,NSString *> * _Nullable)additionalParameters;
		[Export ("tokenExchangeRequestWithAdditionalParameters:")]
		[return: NullAllowed]
		OIDTokenRequest TokenExchangeRequestWithAdditionalParameters ([NullAllowed] NSDictionary<NSString, NSString> additionalParameters);
	}

	// typedef void (^OIDDiscoveryCallback)(OIDServiceConfiguration * _Nullable, NSError * _Nullable);
	delegate void OIDDiscoveryCallback ([NullAllowed] OIDServiceConfiguration arg0, [NullAllowed] NSError arg1);

	// typedef void (^OIDAuthorizationCallback)(OIDAuthorizationResponse * _Nullable, NSError * _Nullable);
	delegate void OIDAuthorizationCallback ([NullAllowed] OIDAuthorizationResponse arg0, [NullAllowed] NSError arg1);

	// typedef void (^OIDTokenCallback)(OIDTokenResponse * _Nullable, NSError * _Nullable);
	delegate void OIDTokenCallback ([NullAllowed] OIDTokenResponse arg0, [NullAllowed] NSError arg1);

	// typedef void (^OIDRegistrationCompletion)(OIDRegistrationResponse * _Nullable, NSError * _Nullable);
	delegate void OIDRegistrationCompletion ([NullAllowed] OIDRegistrationResponse arg0, [NullAllowed] NSError arg1);

	// @interface OIDAuthorizationService : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface OIDAuthorizationService
	{
		// @property (readonly, nonatomic) OIDServiceConfiguration * _Nonnull configuration;
		[Export ("configuration")]
		OIDServiceConfiguration Configuration { get; }

		// +(void)discoverServiceConfigurationForIssuer:(NSURL * _Nonnull)issuerURL completion:(OIDDiscoveryCallback _Nonnull)completion;
		[Static]
		[Export ("discoverServiceConfigurationForIssuer:completion:")]
		void DiscoverServiceConfigurationForIssuer (NSUrl issuerURL, OIDDiscoveryCallback completion);

		// +(void)discoverServiceConfigurationForDiscoveryURL:(NSURL * _Nonnull)discoveryURL completion:(OIDDiscoveryCallback _Nonnull)completion;
		[Static]
		[Export ("discoverServiceConfigurationForDiscoveryURL:completion:")]
		void DiscoverServiceConfigurationForDiscoveryURL (NSUrl discoveryURL, OIDDiscoveryCallback completion);

		// +(id<OIDAuthorizationFlowSession> _Nonnull)presentAuthorizationRequest:(OIDAuthorizationRequest * _Nonnull)request UICoordinator:(id<OIDAuthorizationUICoordinator> _Nonnull)UICoordinator callback:(OIDAuthorizationCallback _Nonnull)callback;
		[Static]
		[Export ("presentAuthorizationRequest:UICoordinator:callback:")]
		OIDAuthorizationFlowSession PresentAuthorizationRequest (OIDAuthorizationRequest request, OIDAuthorizationUICoordinator UICoordinator, OIDAuthorizationCallback callback);

		// +(void)performTokenRequest:(OIDTokenRequest * _Nonnull)request callback:(OIDTokenCallback _Nonnull)callback;
		[Static]
		[Export ("performTokenRequest:callback:")]
		void PerformTokenRequest (OIDTokenRequest request, OIDTokenCallback callback);

		// +(void)performRegistrationRequest:(OIDRegistrationRequest * _Nonnull)request completion:(OIDRegistrationCompletion _Nonnull)completion;
		[Static]
		[Export ("performRegistrationRequest:completion:")]
		void PerformRegistrationRequest (OIDRegistrationRequest request, OIDRegistrationCompletion completion);
	}

	// @protocol OIDAuthorizationFlowSession <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface OIDAuthorizationFlowSession
	{
		// @required -(void)cancel;
		[Abstract]
		[Export ("cancel")]
		void Cancel ();

		// @required -(BOOL)resumeAuthorizationFlowWithURL:(NSURL * _Nonnull)URL;
		[Abstract]
		[Export ("resumeAuthorizationFlowWithURL:")]
		bool ResumeAuthorizationFlowWithURL (NSUrl URL);

		// @required -(void)failAuthorizationFlowWithError:(NSError * _Nonnull)error;
		[Abstract]
		[Export ("failAuthorizationFlowWithError:")]
		void FailAuthorizationFlowWithError (NSError error);
	}

	// @protocol OIDAuthorizationUICoordinator <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface OIDAuthorizationUICoordinator
	{
		// @required -(BOOL)presentAuthorizationWithURL:(NSURL * _Nonnull)URL session:(id<OIDAuthorizationFlowSession> _Nonnull)session;
		[Abstract]
		[Export ("presentAuthorizationWithURL:session:")]
		bool PresentAuthorizationWithURL (NSUrl URL, OIDAuthorizationFlowSession session);

		// @required -(void)dismissAuthorizationAnimated:(BOOL)animated completion:(void (^ _Nonnull)(void))completion;
		[Abstract]
		[Export ("dismissAuthorizationAnimated:completion:")]
		void DismissAuthorizationAnimated (bool animated, Action completion);
	}

	[Static]
	partial interface Constants
	{
		// extern NSString *const _Nonnull OIDGeneralErrorDomain;
		[Field("OIDGeneralErrorDomain", "__Internal")]
		NSString OIDGeneralErrorDomain { get; }

		// extern NSString *const _Nonnull OIDOAuthAuthorizationErrorDomain;
		[Field("OIDOAuthAuthorizationErrorDomain", "__Internal")]
		NSString OIDOAuthAuthorizationErrorDomain { get; }

		// extern NSString *const _Nonnull OIDOAuthTokenErrorDomain;
		[Field("OIDOAuthTokenErrorDomain", "__Internal")]
		NSString OIDOAuthTokenErrorDomain { get; }

		// extern NSString *const _Nonnull OIDOAuthRegistrationErrorDomain;
		[Field("OIDOAuthRegistrationErrorDomain", "__Internal")]
		NSString OIDOAuthRegistrationErrorDomain { get; }

		// extern NSString *const _Nonnull OIDResourceServerAuthorizationErrorDomain;
		[Field("OIDResourceServerAuthorizationErrorDomain", "__Internal")]
		NSString OIDResourceServerAuthorizationErrorDomain { get; }

		// extern NSString *const _Nonnull OIDHTTPErrorDomain;
		[Field("OIDHTTPErrorDomain", "__Internal")]
		NSString OIDHTTPErrorDomain { get; }

		// extern NSString *const _Nonnull OIDOAuthErrorResponseErrorKey;
		[Field("OIDOAuthErrorResponseErrorKey", "__Internal")]
		NSString OIDOAuthErrorResponseErrorKey { get; }

		// extern NSString *const _Nonnull OIDOAuthErrorFieldError;
		[Field("OIDOAuthErrorFieldError", "__Internal")]
		NSString OIDOAuthErrorFieldError { get; }

		// extern NSString *const _Nonnull OIDOAuthErrorFieldErrorDescription;
		[Field("OIDOAuthErrorFieldErrorDescription", "__Internal")]
		NSString OIDOAuthErrorFieldErrorDescription { get; }

		// extern NSString *const _Nonnull OIDOAuthErrorFieldErrorURI;
		[Field("OIDOAuthErrorFieldErrorURI", "__Internal")]
		NSString OIDOAuthErrorFieldErrorURI { get; }
	}

	
	partial interface Constants
	{
		// extern NSString *const _Nonnull OIDOAuthExceptionInvalidAuthorizationFlow;
		[Field("OIDOAuthExceptionInvalidAuthorizationFlow", "__Internal")]
		NSString OIDOAuthExceptionInvalidAuthorizationFlow { get; }
	}

	// @interface OIDErrorUtilities : NSObject
	[BaseType (typeof(NSObject))]
	interface OIDErrorUtilities
	{
		// +(NSError * _Nonnull)errorWithCode:(OIDErrorCode)code underlyingError:(NSError * _Nullable)underlyingError description:(NSString * _Nullable)description;
		[Static]
		[Export ("errorWithCode:underlyingError:description:")]
		NSError ErrorWithCode (OIDErrorCode code, [NullAllowed] NSError underlyingError, [NullAllowed] string description);

		// +(NSError * _Nonnull)OAuthErrorWithDomain:(NSString * _Nonnull)OAuthErrorDomain OAuthResponse:(NSDictionary * _Nonnull)errorResponse underlyingError:(NSError * _Nullable)underlyingError;
		[Static]
		[Export ("OAuthErrorWithDomain:OAuthResponse:underlyingError:")]
		NSError OAuthErrorWithDomain (string OAuthErrorDomain, NSDictionary errorResponse, [NullAllowed] NSError underlyingError);

		// +(NSError * _Nonnull)resourceServerAuthorizationErrorWithCode:(NSInteger)code errorResponse:(NSDictionary * _Nullable)errorResponse underlyingError:(NSError * _Nullable)underlyingError;
		[Static]
		[Export ("resourceServerAuthorizationErrorWithCode:errorResponse:underlyingError:")]
		NSError ResourceServerAuthorizationErrorWithCode (nint code, [NullAllowed] NSDictionary errorResponse, [NullAllowed] NSError underlyingError);

		// +(NSError * _Nonnull)HTTPErrorWithHTTPResponse:(NSHTTPURLResponse * _Nonnull)HTTPURLResponse data:(NSData * _Nullable)data;
		[Static]
		[Export ("HTTPErrorWithHTTPResponse:data:")]
		NSError HTTPErrorWithHTTPResponse (NSHttpUrlResponse HTTPURLResponse, [NullAllowed] NSData data);

		// +(void)raiseException:(NSString * _Nonnull)name;
		[Static]
		[Export ("raiseException:")]
		void RaiseException (string name);

		// +(void)raiseException:(NSString * _Nonnull)name message:(NSString * _Nonnull)message;
		[Static]
		[Export ("raiseException:message:")]
		void RaiseException (string name, string message);

		// +(OIDErrorCodeOAuth)OAuthErrorCodeFromString:(NSString * _Nonnull)errorCode;
		[Static]
		[Export ("OAuthErrorCodeFromString:")]
		OIDErrorCodeOAuth OAuthErrorCodeFromString (string errorCode);

		// +(BOOL)isOAuthErrorDomain:(NSString * _Nonnull)errorDomain;
		[Static]
		[Export ("isOAuthErrorDomain:")]
		bool IsOAuthErrorDomain (string errorDomain);
	}

	partial interface Constants
	{
		// extern NSString *const OIDGrantTypeAuthorizationCode;
		[Field("OIDGrantTypeAuthorizationCode", "__Internal")]
		NSString OIDGrantTypeAuthorizationCode { get; }

		// extern NSString *const OIDGrantTypeRefreshToken;
		[Field("OIDGrantTypeRefreshToken", "__Internal")]
		NSString OIDGrantTypeRefreshToken { get; }

		// extern NSString *const OIDGrantTypePassword;
		[Field("OIDGrantTypePassword", "__Internal")]
		NSString OIDGrantTypePassword { get; }

		// extern NSString *const OIDGrantTypeClientCredentials;
		[Field("OIDGrantTypeClientCredentials", "__Internal")]
		NSString OIDGrantTypeClientCredentials { get; }
	}

	// @interface OIDRegistrationRequest : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface OIDRegistrationRequest : INSCopying, INSSecureCoding
	{
		// @property (readonly, nonatomic) OIDServiceConfiguration * _Nonnull configuration;
		[Export ("configuration")]
		OIDServiceConfiguration Configuration { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull applicationType;
		[Export ("applicationType")]
		string ApplicationType { get; }

		// @property (readonly, nonatomic) NSArray<NSURL *> * _Nonnull redirectURIs;
		[Export ("redirectURIs")]
		NSUrl[] RedirectURIs { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable responseTypes;
		[NullAllowed, Export ("responseTypes")]
		string[] ResponseTypes { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable grantTypes;
		[NullAllowed, Export ("grantTypes")]
		string[] GrantTypes { get; }

		// @property (readonly, nonatomic) NSString * _Nullable subjectType;
		[NullAllowed, Export ("subjectType")]
		string SubjectType { get; }

		// @property (readonly, nonatomic) NSString * _Nullable tokenEndpointAuthenticationMethod;
		[NullAllowed, Export ("tokenEndpointAuthenticationMethod")]
		string TokenEndpointAuthenticationMethod { get; }

		// @property (readonly, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable additionalParameters;
		[NullAllowed, Export ("additionalParameters")]
		NSDictionary<NSString, NSString> AdditionalParameters { get; }

		// -(instancetype _Nonnull)initWithConfiguration:(OIDServiceConfiguration * _Nonnull)configuration redirectURIs:(NSArray<NSURL *> * _Nonnull)redirectURIs responseTypes:(NSArray<NSString *> * _Nullable)responseTypes grantTypes:(NSArray<NSString *> * _Nullable)grantTypes subjectType:(NSString * _Nullable)subjectType tokenEndpointAuthMethod:(NSString * _Nullable)tokenEndpointAuthMethod additionalParameters:(NSDictionary<NSString *,NSString *> * _Nullable)additionalParameters __attribute__((objc_designated_initializer));
		[Export ("initWithConfiguration:redirectURIs:responseTypes:grantTypes:subjectType:tokenEndpointAuthMethod:additionalParameters:")]
		[DesignatedInitializer]
		IntPtr Constructor (OIDServiceConfiguration configuration, NSUrl[] redirectURIs, [NullAllowed] string[] responseTypes, [NullAllowed] string[] grantTypes, [NullAllowed] string subjectType, [NullAllowed] string tokenEndpointAuthMethod, [NullAllowed] NSDictionary<NSString, NSString> additionalParameters);

		// -(NSURLRequest * _Nonnull)URLRequest;
		[Export ("URLRequest")]
		NSUrlRequest URLRequest { get; }
	}

	
	partial interface Constants
	{
		// extern NSString *const _Nonnull OIDClientIDParam;
		[Field("OIDClientIDParam", "__Internal")]
		NSString OIDClientIDParam { get; }

		// extern NSString *const _Nonnull OIDClientIDIssuedAtParam;
		[Field("OIDClientIDIssuedAtParam", "__Internal")]
		NSString OIDClientIDIssuedAtParam { get; }

		// extern NSString *const _Nonnull OIDClientSecretParam;
		[Field("OIDClientSecretParam", "__Internal")]
		NSString OIDClientSecretParam { get; }

		// extern NSString *const _Nonnull OIDClientSecretExpirestAtParam;
		[Field("OIDClientSecretExpirestAtParam", "__Internal")]
		NSString OIDClientSecretExpirestAtParam { get; }

		// extern NSString *const _Nonnull OIDRegistrationAccessTokenParam;
		[Field("OIDRegistrationAccessTokenParam", "__Internal")]
		NSString OIDRegistrationAccessTokenParam { get; }

		// extern NSString *const _Nonnull OIDRegistrationClientURIParam;
		[Field("OIDRegistrationClientURIParam", "__Internal")]
		NSString OIDRegistrationClientURIParam { get; }
	}

	// @interface OIDRegistrationResponse : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface OIDRegistrationResponse : INSCopying, INSSecureCoding
	{
		// @property (readonly, nonatomic) OIDRegistrationRequest * _Nonnull request;
		[Export ("request")]
		OIDRegistrationRequest Request { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull clientID;
		[Export ("clientID")]
		string ClientID { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable clientIDIssuedAt;
		[NullAllowed, Export ("clientIDIssuedAt")]
		NSDate ClientIDIssuedAt { get; }

		// @property (readonly, nonatomic) NSString * _Nullable clientSecret;
		[NullAllowed, Export ("clientSecret")]
		string ClientSecret { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable clientSecretExpiresAt;
		[NullAllowed, Export ("clientSecretExpiresAt")]
		NSDate ClientSecretExpiresAt { get; }

		// @property (readonly, nonatomic) NSString * _Nullable registrationAccessToken;
		[NullAllowed, Export ("registrationAccessToken")]
		string RegistrationAccessToken { get; }

		// @property (readonly, nonatomic) NSURL * _Nullable registrationClientURI;
		[NullAllowed, Export ("registrationClientURI")]
		NSUrl RegistrationClientURI { get; }

		// @property (readonly, nonatomic) NSString * _Nullable tokenEndpointAuthenticationMethod;
		[NullAllowed, Export ("tokenEndpointAuthenticationMethod")]
		string TokenEndpointAuthenticationMethod { get; }

		// @property (readonly, nonatomic) NSDictionary<NSString *,NSObject<NSCopying> *> * _Nullable additionalParameters;
		[NullAllowed, Export ("additionalParameters")]
		NSDictionary<NSString, NSCopying> AdditionalParameters { get; }

		// -(instancetype _Nonnull)initWithRequest:(OIDRegistrationRequest * _Nonnull)request parameters:(NSDictionary<NSString *,NSObject<NSCopying> *> * _Nonnull)parameters __attribute__((objc_designated_initializer));
		[Export ("initWithRequest:parameters:")]
		[DesignatedInitializer]
		IntPtr Constructor (OIDRegistrationRequest request, NSDictionary<NSString, NSCopying> parameters);
	}

	// @interface OIDScopeUtilities : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface OIDScopeUtilities
	{
		// +(NSString * _Nonnull)scopesWithArray:(NSArray<NSString *> * _Nonnull)scopes;
		[Static]
		[Export ("scopesWithArray:")]
		string ScopesWithArray (string[] scopes);

		// +(NSArray<NSString *> * _Nonnull)scopesArrayWithString:(NSString * _Nonnull)scopes;
		[Static]
		[Export ("scopesArrayWithString:")]
		string[] ScopesArrayWithString (string scopes);
	}

	// typedef void (^OIDServiceConfigurationCreated)(OIDServiceConfiguration * _Nullable, NSError * _Nullable);
	delegate void OIDServiceConfigurationCreated ([NullAllowed] OIDServiceConfiguration arg0, [NullAllowed] NSError arg1);

	// @interface OIDServiceConfiguration : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface OIDServiceConfiguration : INSCopying, INSSecureCoding
	{
		// @property (readonly, nonatomic) NSURL * _Nonnull authorizationEndpoint;
		[Export ("authorizationEndpoint")]
		NSUrl AuthorizationEndpoint { get; }

		// @property (readonly, nonatomic) NSURL * _Nonnull tokenEndpoint;
		[Export ("tokenEndpoint")]
		NSUrl TokenEndpoint { get; }

		// @property (readonly, nonatomic) NSURL * _Nullable registrationEndpoint;
		[NullAllowed, Export ("registrationEndpoint")]
		NSUrl RegistrationEndpoint { get; }

		// @property (readonly, nonatomic) OIDServiceDiscovery * _Nullable discoveryDocument;
		[NullAllowed, Export ("discoveryDocument")]
		OIDServiceDiscovery DiscoveryDocument { get; }

		// -(instancetype _Nonnull)initWithAuthorizationEndpoint:(NSURL * _Nonnull)authorizationEndpoint tokenEndpoint:(NSURL * _Nonnull)tokenEndpoint;
		[Export ("initWithAuthorizationEndpoint:tokenEndpoint:")]
		IntPtr Constructor (NSUrl authorizationEndpoint, NSUrl tokenEndpoint);

		// -(instancetype _Nonnull)initWithAuthorizationEndpoint:(NSURL * _Nonnull)authorizationEndpoint tokenEndpoint:(NSURL * _Nonnull)tokenEndpoint registrationEndpoint:(NSURL * _Nullable)registrationEndpoint;
		[Export ("initWithAuthorizationEndpoint:tokenEndpoint:registrationEndpoint:")]
		IntPtr Constructor (NSUrl authorizationEndpoint, NSUrl tokenEndpoint, [NullAllowed] NSUrl registrationEndpoint);

		// -(instancetype _Nonnull)initWithDiscoveryDocument:(OIDServiceDiscovery * _Nonnull)discoveryDocument;
		[Export ("initWithDiscoveryDocument:")]
		IntPtr Constructor (OIDServiceDiscovery discoveryDocument);
	}

	// @interface OIDServiceDiscovery : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface OIDServiceDiscovery : INSCopying, INSSecureCoding
	{
		// @property (readonly, nonatomic) NSDictionary<NSString *,id> * _Nonnull discoveryDictionary;
		[Export ("discoveryDictionary")]
		NSDictionary<NSString, NSObject> DiscoveryDictionary { get; }

		// @property (readonly, nonatomic) NSURL * _Nonnull issuer;
		[Export ("issuer")]
		NSUrl Issuer { get; }

		// @property (readonly, nonatomic) NSURL * _Nonnull authorizationEndpoint;
		[Export ("authorizationEndpoint")]
		NSUrl AuthorizationEndpoint { get; }

		// @property (readonly, nonatomic) NSURL * _Nonnull tokenEndpoint;
		[Export ("tokenEndpoint")]
		NSUrl TokenEndpoint { get; }

		// @property (readonly, nonatomic) NSURL * _Nullable userinfoEndpoint;
		[NullAllowed, Export ("userinfoEndpoint")]
		NSUrl UserinfoEndpoint { get; }

		// @property (readonly, nonatomic) NSURL * _Nonnull jwksURL;
		[Export ("jwksURL")]
		NSUrl JwksURL { get; }

		// @property (readonly, nonatomic) NSURL * _Nullable registrationEndpoint;
		[NullAllowed, Export ("registrationEndpoint")]
		NSUrl RegistrationEndpoint { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable scopesSupported;
		[NullAllowed, Export ("scopesSupported")]
		string[] ScopesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nonnull responseTypesSupported;
		[Export ("responseTypesSupported")]
		string[] ResponseTypesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable responseModesSupported;
		[NullAllowed, Export ("responseModesSupported")]
		string[] ResponseModesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable grantTypesSupported;
		[NullAllowed, Export ("grantTypesSupported")]
		string[] GrantTypesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable acrValuesSupported;
		[NullAllowed, Export ("acrValuesSupported")]
		string[] AcrValuesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nonnull subjectTypesSupported;
		[Export ("subjectTypesSupported")]
		string[] SubjectTypesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nonnull IDTokenSigningAlgorithmValuesSupported;
		[Export ("IDTokenSigningAlgorithmValuesSupported")]
		string[] IDTokenSigningAlgorithmValuesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable IDTokenEncryptionAlgorithmValuesSupported;
		[NullAllowed, Export ("IDTokenEncryptionAlgorithmValuesSupported")]
		string[] IDTokenEncryptionAlgorithmValuesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable IDTokenEncryptionEncodingValuesSupported;
		[NullAllowed, Export ("IDTokenEncryptionEncodingValuesSupported")]
		string[] IDTokenEncryptionEncodingValuesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable userinfoSigningAlgorithmValuesSupported;
		[NullAllowed, Export ("userinfoSigningAlgorithmValuesSupported")]
		string[] UserinfoSigningAlgorithmValuesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable userinfoEncryptionAlgorithmValuesSupported;
		[NullAllowed, Export ("userinfoEncryptionAlgorithmValuesSupported")]
		string[] UserinfoEncryptionAlgorithmValuesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable userinfoEncryptionEncodingValuesSupported;
		[NullAllowed, Export ("userinfoEncryptionEncodingValuesSupported")]
		string[] UserinfoEncryptionEncodingValuesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable requestObjectSigningAlgorithmValuesSupported;
		[NullAllowed, Export ("requestObjectSigningAlgorithmValuesSupported")]
		string[] RequestObjectSigningAlgorithmValuesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable requestObjectEncryptionAlgorithmValuesSupported;
		[NullAllowed, Export ("requestObjectEncryptionAlgorithmValuesSupported")]
		string[] RequestObjectEncryptionAlgorithmValuesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable requestObjectEncryptionEncodingValuesSupported;
		[NullAllowed, Export ("requestObjectEncryptionEncodingValuesSupported")]
		string[] RequestObjectEncryptionEncodingValuesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable tokenEndpointAuthMethodsSupported;
		[NullAllowed, Export ("tokenEndpointAuthMethodsSupported")]
		string[] TokenEndpointAuthMethodsSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable tokenEndpointAuthSigningAlgorithmValuesSupported;
		[NullAllowed, Export ("tokenEndpointAuthSigningAlgorithmValuesSupported")]
		string[] TokenEndpointAuthSigningAlgorithmValuesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable displayValuesSupported;
		[NullAllowed, Export ("displayValuesSupported")]
		string[] DisplayValuesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable claimTypesSupported;
		[NullAllowed, Export ("claimTypesSupported")]
		string[] ClaimTypesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable claimsSupported;
		[NullAllowed, Export ("claimsSupported")]
		string[] ClaimsSupported { get; }

		// @property (readonly, nonatomic) NSURL * _Nullable serviceDocumentation;
		[NullAllowed, Export ("serviceDocumentation")]
		NSUrl ServiceDocumentation { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable claimsLocalesSupported;
		[NullAllowed, Export ("claimsLocalesSupported")]
		string[] ClaimsLocalesSupported { get; }

		// @property (readonly, nonatomic) NSArray<NSString *> * _Nullable UILocalesSupported;
		[NullAllowed, Export ("UILocalesSupported")]
		string[] UILocalesSupported { get; }

		// @property (readonly, nonatomic) BOOL claimsParameterSupported;
		[Export ("claimsParameterSupported")]
		bool ClaimsParameterSupported { get; }

		// @property (readonly, nonatomic) BOOL requestParameterSupported;
		[Export ("requestParameterSupported")]
		bool RequestParameterSupported { get; }

		// @property (readonly, nonatomic) BOOL requestURIParameterSupported;
		[Export ("requestURIParameterSupported")]
		bool RequestURIParameterSupported { get; }

		// @property (readonly, nonatomic) BOOL requireRequestURIRegistration;
		[Export ("requireRequestURIRegistration")]
		bool RequireRequestURIRegistration { get; }

		// @property (readonly, nonatomic) NSURL * _Nullable OPPolicyURI;
		[NullAllowed, Export ("OPPolicyURI")]
		NSUrl OPPolicyURI { get; }

		// @property (readonly, nonatomic) NSURL * _Nullable OPTosURI;
		[NullAllowed, Export ("OPTosURI")]
		NSUrl OPTosURI { get; }

		// -(instancetype _Nullable)initWithJSON:(NSString * _Nonnull)serviceDiscoveryJSON error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithJSON:error:")]
		IntPtr Constructor (string serviceDiscoveryJSON, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithJSONData:(NSData * _Nonnull)serviceDiscoveryJSONData error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithJSONData:error:")]
		IntPtr Constructor (NSData serviceDiscoveryJSONData, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithDictionary:(NSDictionary * _Nonnull)serviceDiscoveryDictionary error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithDictionary:error:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSDictionary serviceDiscoveryDictionary, [NullAllowed] out NSError error);
	}

	// @interface OIDTokenRequest : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface OIDTokenRequest : INSCopying, INSSecureCoding
	{
		// @property (readonly, nonatomic) OIDServiceConfiguration * _Nonnull configuration;
		[Export ("configuration")]
		OIDServiceConfiguration Configuration { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull grantType;
		[Export ("grantType")]
		string GrantType { get; }

		// @property (readonly, nonatomic) NSString * _Nullable authorizationCode;
		[NullAllowed, Export ("authorizationCode")]
		string AuthorizationCode { get; }

		// @property (readonly, nonatomic) NSURL * _Nonnull redirectURL;
		[Export ("redirectURL")]
		NSUrl RedirectURL { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull clientID;
		[Export ("clientID")]
		string ClientID { get; }

		// @property (readonly, nonatomic) NSString * _Nullable clientSecret;
		[NullAllowed, Export ("clientSecret")]
		string ClientSecret { get; }

		// @property (readonly, nonatomic) NSString * _Nullable scope;
		[NullAllowed, Export ("scope")]
		string Scope { get; }

		// @property (readonly, nonatomic) NSString * _Nullable refreshToken;
		[NullAllowed, Export ("refreshToken")]
		string RefreshToken { get; }

		// @property (readonly, nonatomic) NSString * _Nullable codeVerifier;
		[NullAllowed, Export ("codeVerifier")]
		string CodeVerifier { get; }

		// @property (readonly, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable additionalParameters;
		[NullAllowed, Export ("additionalParameters")]
		NSDictionary<NSString, NSString> AdditionalParameters { get; }

		// -(instancetype _Nonnull)initWithConfiguration:(OIDServiceConfiguration * _Nonnull)configuration grantType:(NSString * _Nonnull)grantType authorizationCode:(NSString * _Nullable)code redirectURL:(NSURL * _Nonnull)redirectURL clientID:(NSString * _Nonnull)clientID clientSecret:(NSString * _Nullable)clientSecret scopes:(NSArray<NSString *> * _Nullable)scopes refreshToken:(NSString * _Nullable)refreshToken codeVerifier:(NSString * _Nullable)codeVerifier additionalParameters:(NSDictionary<NSString *,NSString *> * _Nullable)additionalParameters;
		[Export ("initWithConfiguration:grantType:authorizationCode:redirectURL:clientID:clientSecret:scopes:refreshToken:codeVerifier:additionalParameters:")]
		IntPtr Constructor (OIDServiceConfiguration configuration, string grantType, [NullAllowed] string code, NSUrl redirectURL, string clientID, [NullAllowed] string clientSecret, [NullAllowed] string[] scopes, [NullAllowed] string refreshToken, [NullAllowed] string codeVerifier, [NullAllowed] NSDictionary<NSString, NSString> additionalParameters);

		// -(instancetype _Nonnull)initWithConfiguration:(OIDServiceConfiguration * _Nonnull)configuration grantType:(NSString * _Nonnull)grantType authorizationCode:(NSString * _Nullable)code redirectURL:(NSURL * _Nonnull)redirectURL clientID:(NSString * _Nonnull)clientID clientSecret:(NSString * _Nullable)clientSecret scope:(NSString * _Nullable)scope refreshToken:(NSString * _Nullable)refreshToken codeVerifier:(NSString * _Nullable)codeVerifier additionalParameters:(NSDictionary<NSString *,NSString *> * _Nullable)additionalParameters __attribute__((objc_designated_initializer));
		[Export ("initWithConfiguration:grantType:authorizationCode:redirectURL:clientID:clientSecret:scope:refreshToken:codeVerifier:additionalParameters:")]
		[DesignatedInitializer]
		IntPtr Constructor (OIDServiceConfiguration configuration, string grantType, [NullAllowed] string code, NSUrl redirectURL, string clientID, [NullAllowed] string clientSecret, [NullAllowed] string scope, [NullAllowed] string refreshToken, [NullAllowed] string codeVerifier, [NullAllowed] NSDictionary<NSString, NSString> additionalParameters);

		// -(NSURLRequest * _Nonnull)URLRequest;
		[Export ("URLRequest")]
		
		NSUrlRequest URLRequest { get; }
	}

	// @interface OIDTokenResponse : NSObject <NSCopying, NSSecureCoding>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface OIDTokenResponse : INSCopying, INSSecureCoding
	{
		// @property (readonly, nonatomic) OIDTokenRequest * _Nonnull request;
		[Export ("request")]
		OIDTokenRequest Request { get; }

		// @property (readonly, nonatomic) NSString * _Nullable accessToken;
		[NullAllowed, Export ("accessToken")]
		string AccessToken { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable accessTokenExpirationDate;
		[NullAllowed, Export ("accessTokenExpirationDate")]
		NSDate AccessTokenExpirationDate { get; }

		// @property (readonly, nonatomic) NSString * _Nullable tokenType;
		[NullAllowed, Export ("tokenType")]
		string TokenType { get; }

		// @property (readonly, nonatomic) NSString * _Nullable idToken;
		[NullAllowed, Export ("idToken")]
		string IdToken { get; }

		// @property (readonly, nonatomic) NSString * _Nullable refreshToken;
		[NullAllowed, Export ("refreshToken")]
		string RefreshToken { get; }

		// @property (readonly, nonatomic) NSString * _Nullable scope;
		[NullAllowed, Export ("scope")]
		string Scope { get; }

		// @property (readonly, nonatomic) NSDictionary<NSString *,NSObject<NSCopying> *> * _Nullable additionalParameters;
		[NullAllowed, Export ("additionalParameters")]
		NSDictionary<NSString, NSCopying> AdditionalParameters { get; }

		// -(instancetype _Nonnull)initWithRequest:(OIDTokenRequest * _Nonnull)request parameters:(NSDictionary<NSString *,NSObject<NSCopying> *> * _Nonnull)parameters __attribute__((objc_designated_initializer));
		[Export ("initWithRequest:parameters:")]
		[DesignatedInitializer]
		IntPtr Constructor (OIDTokenRequest request, NSDictionary<NSString, NSCopying> parameters);
	}

	// @interface OIDTokenUtilities : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface OIDTokenUtilities
	{
		// +(NSString * _Nonnull)encodeBase64urlNoPadding:(NSData * _Nonnull)data;
		[Static]
		[Export ("encodeBase64urlNoPadding:")]
		string EncodeBase64urlNoPadding (NSData data);

		// +(NSString * _Nullable)randomURLSafeStringWithSize:(NSUInteger)size;
		[Static]
		[Export ("randomURLSafeStringWithSize:")]
		[return: NullAllowed]
		string RandomURLSafeStringWithSize (nuint size);

		// +(NSData * _Nonnull)sha265:(NSString * _Nonnull)inputString;
		[Static]
		[Export ("sha265:")]
		NSData Sha265 (string inputString);
	}

	partial interface Constants
	{
		// extern NSString *const _Nonnull OIDTokenEndpointAuthenticationMethodParam;
		[Field("OIDTokenEndpointAuthenticationMethodParam", "__Internal")]
		NSString OIDTokenEndpointAuthenticationMethodParam { get; }

		// extern NSString *const _Nonnull OIDApplicationTypeParam;
		[Field("OIDApplicationTypeParam", "__Internal")]
		NSString OIDApplicationTypeParam { get; }

		// extern NSString *const _Nonnull OIDRedirectURIsParam;
		[Field("OIDRedirectURIsParam", "__Internal")]
		NSString OIDRedirectURIsParam { get; }

		// extern NSString *const _Nonnull OIDResponseTypesParam;
		[Field("OIDResponseTypesParam", "__Internal")]
		NSString OIDResponseTypesParam { get; }

		// extern NSString *const _Nonnull OIDGrantTypesParam;
		[Field("OIDGrantTypesParam", "__Internal")]
		NSString OIDGrantTypesParam { get; }

		// extern NSString *const _Nonnull OIDSubjectTypeParam;
		[Field("OIDSubjectTypeParam", "__Internal")]
		NSString OIDSubjectTypeParam { get; }

		// extern NSString *const _Nonnull OIDApplicationTypeNative;
		[Field("OIDApplicationTypeNative", "__Internal")]
		NSString OIDApplicationTypeNative { get; }
	}

	// typedef id _Nullable (^OIDFieldMappingConversionFunction)(NSObject * _Nullable);
	delegate NSObject OIDFieldMappingConversionFunction ([NullAllowed] NSObject arg0);

	// @interface OIDFieldMapping : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface OIDFieldMapping
	{
		// @property (readonly, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) Class _Nonnull expectedType;
		[Export ("expectedType")]
		Class ExpectedType { get; }

		// @property (readonly, nonatomic) OIDFieldMappingConversionFunction _Nullable conversion;
		[NullAllowed, Export ("conversion")]
		OIDFieldMappingConversionFunction Conversion { get; }

		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name type:(Class _Nonnull)type conversion:(OIDFieldMappingConversionFunction _Nullable)conversion __attribute__((objc_designated_initializer));
		[Export ("initWithName:type:conversion:")]
		[DesignatedInitializer]
		IntPtr Constructor (string name, Class type, [NullAllowed] OIDFieldMappingConversionFunction conversion);

		// -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name type:(Class _Nonnull)type;
		[Export ("initWithName:type:")]
		IntPtr Constructor (string name, Class type);

		// +(NSDictionary<NSString *,NSObject<NSCopying> *> * _Nonnull)remainingParametersWithMap:(NSDictionary<NSString *,OIDFieldMapping *> * _Nonnull)map parameters:(NSDictionary<NSString *,NSObject<NSCopying> *> * _Nonnull)parameters instance:(id _Nonnull)instance;
		[Static]
		[Export ("remainingParametersWithMap:parameters:instance:")]
		NSDictionary<NSString, NSCopying> RemainingParametersWithMap (  NSDictionary map, NSDictionary<NSString, NSCopying> parameters, NSObject instance);

		// +(void)encodeWithCoder:(NSCoder * _Nonnull)aCoder map:(NSDictionary<NSString *,OIDFieldMapping *> * _Nonnull)map instance:(id _Nonnull)instance;
		[Static]
		[Export ("encodeWithCoder:map:instance:")]
		void EncodeWithCoder (NSCoder aCoder, NSDictionary map, NSObject instance);

		// +(void)decodeWithCoder:(NSCoder * _Nonnull)aCoder map:(NSDictionary<NSString *,OIDFieldMapping *> * _Nonnull)map instance:(id _Nonnull)instance;
		[Static]
		[Export ("decodeWithCoder:map:instance:")]
		void DecodeWithCoder (NSCoder aCoder, NSDictionary map, NSObject instance);

		// +(NSSet * _Nonnull)JSONTypes;
		[Static]
		[Export ("JSONTypes")]
		
		NSSet JSONTypes { get; }

		// +(OIDFieldMappingConversionFunction _Nonnull)URLConversion;
		[Static]
		[Export ("URLConversion")]
		
		OIDFieldMappingConversionFunction URLConversion { get; }

		// +(OIDFieldMappingConversionFunction _Nonnull)dateSinceNowConversion;
		[Static]
		[Export ("dateSinceNowConversion")]
		
		OIDFieldMappingConversionFunction DateSinceNowConversion { get; }

		// +(OIDFieldMappingConversionFunction _Nonnull)dateEpochConversion;
		[Static]
		[Export ("dateEpochConversion")]
		
		OIDFieldMappingConversionFunction DateEpochConversion { get; }
	}

	//partial interface Constants
	//{
	//	// extern BOOL gOIDURLQueryComponentForceIOS7Handling;
	//	[Field("gOIDURLQueryComponentForceIOS7Handling", "__Internal")]
	//	bool gOIDURLQueryComponentForceIOS7Handling { get; }
	//}

	// @interface OIDURLQueryComponent : NSObject
	[BaseType (typeof(NSObject))]
	interface OIDURLQueryComponent
	{
		// @property (readonly, nonatomic) NSArray<NSString *> * _Nonnull parameters;
		[Export ("parameters")]
		string[] Parameters { get; }

		// @property (readonly, nonatomic) NSDictionary<NSString *,NSObject<NSCopying> *> * _Nonnull dictionaryValue;
		[Export ("dictionaryValue")]
		NSDictionary<NSString, NSCopying> DictionaryValue { get; }

		// -(instancetype _Nullable)initWithURL:(NSURL * _Nonnull)URL;
		[Export ("initWithURL:")]
		IntPtr Constructor (NSUrl URL);

		// -(NSArray<NSString *> * _Nonnull)valuesForParameter:(NSString * _Nonnull)parameter;
		[Export ("valuesForParameter:")]
		string[] ValuesForParameter (string parameter);

		// -(void)addParameter:(NSString * _Nonnull)parameter value:(NSString * _Nonnull)value;
		[Export ("addParameter:value:")]
		void AddParameter (string parameter, string value);

		// -(void)addParameters:(NSDictionary<NSString *,NSString *> * _Nonnull)parameters;
		[Export ("addParameters:")]
		void AddParameters (NSDictionary<NSString, NSString> parameters);

		// -(NSURL * _Nonnull)URLByReplacingQueryInURL:(NSURL * _Nonnull)URL;
		[Export ("URLByReplacingQueryInURL:")]
		NSUrl URLByReplacingQueryInURL (NSUrl URL);

		// -(NSString * _Nonnull)URLEncodedParameters;
		[Export ("URLEncodedParameters")]
		
		string URLEncodedParameters { get; }
	}
}
