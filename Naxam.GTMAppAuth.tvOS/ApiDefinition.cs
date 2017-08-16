using System;
using AppAuth;
using Foundation;
using GTMSessionFetcherLib;

namespace GTMAppAuth
{
	[Static]
	//[Verify(ConstantsInterfaceAssociation)]
	partial interface GTMAppAuthFetcherAuthorizationConstants
	{
		// extern int *const GTMAppAuthFetcherAuthorizationErrorDomain;
		[Field("GTMAppAuthFetcherAuthorizationErrorDomain", "__Internal")]
        unsafe NSString ErrorDomain { get; }
	}

	// typedef void (^GTMAppAuthFetcherAuthorizationCompletion)(int * _Nullable);
	unsafe delegate void GTMAppAuthFetcherAuthorizationCompletion([NullAllowed] ref int arg0);

	// @interface GTMAppAuthFetcherAuthorization
	[BaseType(typeof(NSObject))]
    interface GTMAppAuthFetcherAuthorization : IGTMFetcherAuthorizationProtocol, INSSecureCoding
	{
		// @property (readonly, nonatomic) OIDAuthState * authState;
		[Export("authState")]
		OIDAuthState AuthState { get; }

		// @property (readonly, nonatomic) int * _Nullable serviceProvider;
		[NullAllowed, Export("serviceProvider")]
        unsafe NSObject ServiceProvider { get; }

		// @property (readonly, nonatomic) int * _Nullable userID;
		[NullAllowed, Export("userID")]
		unsafe NSObject UserID { get; }

		// @property (readonly, nonatomic) int * _Nullable userEmailIsVerified;
		[NullAllowed, Export("userEmailIsVerified")]
		unsafe NSObject UserEmailIsVerified { get; }

		// -(instancetype)initWithAuthState:(OIDAuthState *)authState;
		[Export("initWithAuthState:")]
		IntPtr Constructor(OIDAuthState authState);

		// -(instancetype)initWithAuthState:(OIDAuthState *)authState serviceProvider:(id)serviceProvider userID:(id)userID userEmail:(id)userEmail userEmailIsVerified:(id)userEmailIsVerified;
		[Export("initWithAuthState:serviceProvider:userID:userEmail:userEmailIsVerified:")]
		IntPtr Constructor(OIDAuthState authState, NSObject serviceProvider, NSObject userID, NSObject userEmail, NSObject userEmailIsVerified);

		// +(OIDServiceConfiguration *)configurationForGoogle;
		[Static]
		[Export("configurationForGoogle")]
		//[Verify(MethodToProperty)]
		OIDServiceConfiguration ConfigurationForGoogle { get; }

		// -(void)authorizeRequest:(id)request completionHandler:(GTMAppAuthFetcherAuthorizationCompletion)handler;
		[Export("authorizeRequest:completionHandler:")]
		void AuthorizeRequest(NSObject request, GTMAppAuthFetcherAuthorizationCompletion handler);

        // -(id)canAuthorize;
        [Export("canAuthorize")]
        //[Verify(MethodToProperty)]
        bool CanAuthorize();
	}

	//[Static]
	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern int NS_ASSUME_NONNULL_BEGIN;
		[Field("NS_ASSUME_NONNULL_BEGIN", "__Internal")]
		nint NS_ASSUME_NONNULL_BEGIN { get; }
	}

	// @interface GTMTVAuthorizationRequest
    [BaseType(typeof(NSObject))]
	interface GTMTVAuthorizationRequest
	{
		// -(instancetype _Nonnull)initWithConfiguration:(GTMTVServiceConfiguration * _Nonnull)configuration clientId:(NSString * _Nonnull)clientID clientSecret:(NSString * _Nonnull)clientSecret scopes:(NSArray<NSString *> * _Nullable)scopes additionalParameters:(NSDictionary<NSString *,NSString *> * _Nullable)additionalParameters;
		[Export("initWithConfiguration:clientId:clientSecret:scopes:additionalParameters:")]
		IntPtr Constructor(GTMTVServiceConfiguration configuration, string clientID, string clientSecret, [NullAllowed] string[] scopes, [NullAllowed] NSDictionary<NSString, NSString> additionalParameters);

		// -(NSURLRequest * _Nonnull)URLRequest;
		[Export("URLRequest")]
		//[Verify(MethodToProperty)]
		NSUrlRequest URLRequest { get; }
	}

	[Static]
	//[Verify(ConstantsInterfaceAssociation)]
	partial interface GTMTVDeviceTokenConstants
	{
		// extern NSString *const _Nonnull GTMTVDeviceTokenGrantType;
		[Field("GTMTVDeviceTokenGrantType", "__Internal")]
		NSString GrantType { get; }
	}

	// @interface GTMTVAuthorizationResponse
    [BaseType(typeof(NSObject))]
	interface GTMTVAuthorizationResponse
	{
		// @property (readonly, nonatomic) NSString * _Nullable verificationURL;
		[NullAllowed, Export("verificationURL")]
		string VerificationURL { get; }

		// @property (readonly, nonatomic) NSString * _Nullable userCode;
		[NullAllowed, Export("userCode")]
		string UserCode { get; }

		// @property (readonly, nonatomic) NSString * _Nullable deviceCode;
		[NullAllowed, Export("deviceCode")]
		string DeviceCode { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable interval;
		[NullAllowed, Export("interval")]
		NSNumber Interval { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable expirationDate;
		[NullAllowed, Export("expirationDate")]
		NSDate ExpirationDate { get; }

		// -(instancetype _Nonnull)initWithRequest:(GTMTVAuthorizationRequest * _Nonnull)request parameters:(NSDictionary<NSString *,NSObject<NSCopying> *> * _Nonnull)parameters __attribute__((objc_designated_initializer));
		[Export("initWithRequest:parameters:")]
		[DesignatedInitializer]
		IntPtr Constructor(GTMTVAuthorizationRequest request, NSDictionary<NSString, NSCopying> parameters);

		// -(OIDTokenRequest * _Nullable)tokenPollRequest;
		[NullAllowed, Export("tokenPollRequest")]
		//[Verify(MethodToProperty)]
		OIDTokenRequest TokenPollRequest { get; }

		// -(OIDTokenRequest * _Nullable)tokenPollRequestWithAdditionalParameters:(NSDictionary<NSString *,NSString *> * _Nullable)additionalParameters;
		[Export("tokenPollRequestWithAdditionalParameters:")]
		[return: NullAllowed]
		OIDTokenRequest TokenPollRequestWithAdditionalParameters([NullAllowed] NSDictionary<NSString, NSString> additionalParameters);
	}

	// typedef void (^GTMTVAuthorizationInitialization)(GTMTVAuthorizationResponse * _Nullable, NSError * _Nullable);
	delegate void GTMTVAuthorizationInitialization([NullAllowed] GTMTVAuthorizationResponse arg0, [NullAllowed] NSError arg1);

	// typedef void (^GTMTVAuthorizationCompletion)(GTMAppAuthFetcherAuthorization * _Nullable, NSError * _Nullable);
	delegate void GTMTVAuthorizationCompletion([NullAllowed] GTMAppAuthFetcherAuthorization arg0, [NullAllowed] NSError arg1);

	// typedef void (^GTMTVAuthorizationCancelBlock)();
	delegate void GTMTVAuthorizationCancelBlock();

	// @interface GTMTVAuthorizationService : NSObject
	[BaseType(typeof(NSObject))]
	interface GTMTVAuthorizationService
	{
		// +(GTMTVServiceConfiguration * _Nonnull)TVConfigurationForGoogle;
		[Static]
		[Export("TVConfigurationForGoogle")]
		//[Verify(MethodToProperty)]
		GTMTVServiceConfiguration TVConfigurationForGoogle { get; }

		// +(GTMTVAuthorizationCancelBlock _Nonnull)authorizeTVRequest:(GTMTVAuthorizationRequest * _Nonnull)request initializaiton:(GTMTVAuthorizationInitialization _Nonnull)initialization completion:(GTMTVAuthorizationCompletion _Nonnull)completion;
		[Static]
		[Export("authorizeTVRequest:initializaiton:completion:")]
		GTMTVAuthorizationCancelBlock AuthorizeTVRequest(GTMTVAuthorizationRequest request, GTMTVAuthorizationInitialization initialization, GTMTVAuthorizationCompletion completion);
	}

	// @interface GTMKeychain : NSObject
	[BaseType(typeof(NSObject))]
	interface GTMKeychain
	{
		// +(BOOL)savePasswordToKeychainForName:(NSString * _Nonnull)keychainItemName password:(NSString * _Nonnull)password;
		[Static]
		[Export("savePasswordToKeychainForName:password:")]
		bool SavePasswordToKeychainForName(string keychainItemName, string password);

		// +(NSString * _Nullable)passwordFromKeychainForName:(NSString * _Nonnull)keychainItemName;
		[Static]
		[Export("passwordFromKeychainForName:")]
		[return: NullAllowed]
		string PasswordFromKeychainForName(string keychainItemName);

		// +(BOOL)savePasswordDataToKeychainForName:(NSString * _Nonnull)keychainItemName passwordData:(NSData * _Nonnull)passwordData;
		[Static]
		[Export("savePasswordDataToKeychainForName:passwordData:")]
		bool SavePasswordDataToKeychainForName(string keychainItemName, NSData passwordData);

		// +(NSData * _Nullable)passwordDataFromKeychainForName:(NSString * _Nonnull)keychainItemName;
		[Static]
		[Export("passwordDataFromKeychainForName:")]
		[return: NullAllowed]
		NSData PasswordDataFromKeychainForName(string keychainItemName);

		// +(BOOL)removePasswordFromKeychainForName:(NSString * _Nonnull)keychainItemName;
		[Static]
		[Export("removePasswordFromKeychainForName:")]
		bool RemovePasswordFromKeychainForName(string keychainItemName);
	}

	// @interface GTMTVServiceConfiguration
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface GTMTVServiceConfiguration
	{
		// @property (readonly, nonatomic) NSURL * _Nonnull TVAuthorizationEndpoint;
		[Export("TVAuthorizationEndpoint")]
		NSUrl TVAuthorizationEndpoint { get; }

		// -(instancetype _Nonnull)initWithAuthorizationEndpoint:(NSURL * _Nonnull)authorizationEndpoint TVAuthorizationEndpoint:(NSURL * _Nonnull)TVAuthorizationEndpoint tokenEndpoint:(NSURL * _Nonnull)tokenEndpoint __attribute__((objc_designated_initializer));
		[Export("initWithAuthorizationEndpoint:TVAuthorizationEndpoint:tokenEndpoint:")]
		[DesignatedInitializer]
		IntPtr Constructor(NSUrl authorizationEndpoint, NSUrl TVAuthorizationEndpoint, NSUrl tokenEndpoint);
	}

    [Category]
	[BaseType(typeof(GTMAppAuthFetcherAuthorization))]
	interface GTMAppAuthFetcherAuthorization_Keychain
	{
        // + (nullable GTMAppAuthFetcherAuthorization *) authorizationFromKeychainForName:(NSString*) keychainItemName;
        [Static]
        [Export("authorizationFromKeychainForName:")]
        [return: NullAllowed]
        GTMAppAuthFetcherAuthorization AuthorizationFromKeychainForName(string keychainItemName);

		//+ (BOOL)removeAuthorizationFromKeychainForName:(NSString *)keychainItemName;
		[Static]
		[Export("removeAuthorizationFromKeychainForName:")]
		bool RemoveAuthorizationFromKeychainForName(string keychainItemName);

        //+ (BOOL) saveAuthorization:(GTMAppAuthFetcherAuthorization*) auth toKeychainForName:(NSString*) keychainItemName;
		[Static]
        [Export("saveAuthorization:toKeychainForName:")]
		bool SaveAuthorization(GTMAppAuthFetcherAuthorization auth, string keychainItemName);
	}
}
