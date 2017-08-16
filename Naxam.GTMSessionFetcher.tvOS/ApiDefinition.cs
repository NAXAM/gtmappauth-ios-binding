using System;
using CoreFoundation;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace GTMSessionFetcherLib
{
	// @interface GTMGatherInputStream : NSInputStream <NSStreamDelegate>
	[BaseType (typeof(NSInputStream))]
	interface GTMGatherInputStream : INSStreamDelegate
	{
		// +(NSInputStream *)streamWithArray:(NSArray *)dataArray __attribute__((nonnull(0)));
		[Static]
		[Export ("streamWithArray:")]
		//[Verify (StronglyTypedNSArray)]
		NSInputStream StreamWithArray (NSObject[] dataArray);
	}

	// @interface GTMMIMEDocumentPart : NSObject
	[BaseType (typeof(NSObject))]
	interface GTMMIMEDocumentPart
	{
        
		// @property (readonly, nonatomic) NSDictionary<NSString *,NSString *> * headers;
		[Export ("headers")]
		NSDictionary<NSString, NSString> Headers { get; }

		// @property (readonly, nonatomic) NSData * headerData;
		[Export ("headerData")]
		NSData HeaderData { get; }

		// @property (readonly, nonatomic) NSData * body;
		[Export ("body")]
		NSData Body { get; }

		// @property (readonly, nonatomic) NSUInteger length;
		[Export ("length")]
		nuint Length { get; }

		// +(instancetype)partWithHeaders:(NSDictionary *)headers body:(NSData *)body;
		[Static]
		[Export ("partWithHeaders:body:")]
		GTMMIMEDocumentPart PartWithHeaders (NSDictionary headers, NSData body);
	}

	// @interface GTMMIMEDocument : NSObject
	[BaseType (typeof(NSObject))]
	interface GTMMIMEDocument
	{
		// @property (copy, nonatomic) NSString * boundary;
		[Export ("boundary")]
		string Boundary { get; set; }

		// +(instancetype)MIMEDocument;
		[Static]
		[Export ("MIMEDocument")]
		GTMMIMEDocument MIMEDocument ();

		// -(void)addPartWithHeaders:(NSDictionary<NSString *,NSString *> *)headers body:(NSData *)body __attribute__((nonnull(0, 1)));
		[Export ("addPartWithHeaders:body:")]
		void AddPartWithHeaders (NSDictionary<NSString, NSString> headers, NSData body);

		// -(void)generateInputStream:(NSInputStream **)outStream length:(unsigned long long *)outLength boundary:(NSString **)outBoundary;
		[Export ("generateInputStream:length:boundary:")]
		unsafe void GenerateInputStream (out NSInputStream outStream, ref ulong outLength, out string outBoundary);

		// -(void)generateDispatchData:(dispatch_data_t *)outDispatchData length:(unsigned long long *)outLength boundary:(NSString **)outBoundary;
		[Export ("generateDispatchData:length:boundary:")]
		unsafe void GenerateDispatchData (out NSObject outDispatchData, ref ulong outLength, out string outBoundary);

		// +(NSData *)dataWithHeaders:(NSDictionary<NSString *,NSString *> *)headers;
		[Static]
		[Export ("dataWithHeaders:")]
		NSData DataWithHeaders (NSDictionary<NSString, NSString> headers);

		// +(NSArray<GTMMIMEDocumentPart *> *)MIMEPartsWithBoundary:(NSString *)boundary data:(NSData *)fullDocumentData;
		[Static]
		[Export ("MIMEPartsWithBoundary:data:")]
		GTMMIMEDocumentPart[] MIMEPartsWithBoundary (string boundary, NSData fullDocumentData);

		// +(void)searchData:(NSData *)data targetBytes:(const void *)targetBytes targetLength:(NSUInteger)targetLength foundOffsets:(NSArray<NSNumber *> **)outFoundOffsets;
		[Static]
		[Export ("searchData:targetBytes:targetLength:foundOffsets:")]
        unsafe void SearchData (NSData data, ref NSObject targetBytes, nuint targetLength, ref NSArray outFoundOffsets);

		// +(NSDictionary<NSString *,NSString *> *)headersWithData:(NSData *)data;
		[Static]
		[Export ("headersWithData:")]
		NSDictionary<NSString, NSString> HeadersWithData (NSData data);

		// -(void)seedRandomWith:(u_int32_t)seed;
		[Export ("seedRandomWith:")]
		void SeedRandomWith (uint seed);

		// +(NSUInteger)findBytesWithNeedle:(const unsigned char *)needle needleLength:(NSUInteger)needleLength haystack:(const unsigned char *)haystack haystackLength:(NSUInteger)haystackLength foundOffset:(NSUInteger *)foundOffset;
		[Static]
		[Export ("findBytesWithNeedle:needleLength:haystack:haystackLength:foundOffset:")]
		unsafe nuint FindBytesWithNeedle (ref byte needle, nuint needleLength, ref byte haystack, nuint haystackLength, ref nuint foundOffset);

		// +(void)searchData:(NSData *)data targetBytes:(const void *)targetBytes targetLength:(NSUInteger)targetLength foundOffsets:(NSArray<NSNumber *> **)outFoundOffsets foundBlockNumbers:(NSArray<NSNumber *> **)outFoundBlockNumbers;
		[Static]
		[Export ("searchData:targetBytes:targetLength:foundOffsets:foundBlockNumbers:")]
        unsafe void SearchData (NSData data, ref NSObject targetBytes, nuint targetLength, ref NSArray outFoundOffsets, ref NSArray outFoundBlockNumbers);
	}

	// @interface GTMReadMonitorInputStream : NSInputStream <NSStreamDelegate>
	[BaseType (typeof(NSInputStream))]
	interface GTMReadMonitorInputStream : INSStreamDelegate
	{
		// +(instancetype)inputStreamWithStream:(NSInputStream *)input __attribute__((nonnull(0)));
		[Static]
		[Export ("inputStreamWithStream:")]
		GTMReadMonitorInputStream InputStreamWithStream (NSInputStream input);

		// -(instancetype)initWithStream:(NSInputStream *)input __attribute__((nonnull(0)));
		[Export ("initWithStream:")]
		IntPtr Constructor (NSInputStream input);

		[Wrap ("WeakReadDelegate")]
		NSObject ReadDelegate { get; set; }

		// @property (atomic, weak) id readDelegate;
		[NullAllowed, Export ("readDelegate", ArgumentSemantic.Weak)]
		NSObject WeakReadDelegate { get; set; }

		// @property (assign, atomic) SEL readSelector;
		[Export ("readSelector", ArgumentSemantic.Assign)]
		Selector ReadSelector { get; set; }

		// @property (atomic, strong) NSArray * runLoopModes;
		[Export ("runLoopModes", ArgumentSemantic.Strong)]
		//[Verify (StronglyTypedNSArray)]
		NSObject[] RunLoopModes { get; set; }
	}

	[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull kGTMSessionFetcherStartedNotification;
		[Field("kGTMSessionFetcherStartedNotification",  "__Internal")]
		NSString kGTMSessionFetcherStartedNotification { get; }

		// extern NSString *const _Nonnull kGTMSessionFetcherStoppedNotification;
		[Field("kGTMSessionFetcherStoppedNotification",  "__Internal")]
		NSString kGTMSessionFetcherStoppedNotification { get; }

		// extern NSString *const _Nonnull kGTMSessionFetcherRetryDelayStartedNotification;
		[Field("kGTMSessionFetcherRetryDelayStartedNotification",  "__Internal")]
		NSString kGTMSessionFetcherRetryDelayStartedNotification { get; }

		// extern NSString *const _Nonnull kGTMSessionFetcherRetryDelayStoppedNotification;
		[Field("kGTMSessionFetcherRetryDelayStoppedNotification",  "__Internal")]
		NSString kGTMSessionFetcherRetryDelayStoppedNotification { get; }

		// extern NSString *const _Nonnull kGTMSessionFetcherCompletionInvokedNotification;
		[Field("kGTMSessionFetcherCompletionInvokedNotification",  "__Internal")]
		NSString kGTMSessionFetcherCompletionInvokedNotification { get; }

		// extern NSString *const _Nonnull kGTMSessionFetcherCompletionDataKey;
		[Field("kGTMSessionFetcherCompletionDataKey",  "__Internal")]
		NSString kGTMSessionFetcherCompletionDataKey { get; }

		// extern NSString *const _Nonnull kGTMSessionFetcherCompletionErrorKey;
		[Field("kGTMSessionFetcherCompletionErrorKey",  "__Internal")]
		NSString kGTMSessionFetcherCompletionErrorKey { get; }

		// extern NSString *const _Nonnull kGTMSessionFetcherErrorDomain;
		[Field("kGTMSessionFetcherErrorDomain",  "__Internal")]
		NSString kGTMSessionFetcherErrorDomain { get; }

		// extern NSString *const _Nonnull kGTMSessionFetcherStatusDomain;
		[Field("kGTMSessionFetcherStatusDomain",  "__Internal")]
		NSString kGTMSessionFetcherStatusDomain { get; }

		// extern NSString *const _Nonnull kGTMSessionFetcherStatusDataKey;
		[Field("kGTMSessionFetcherStatusDataKey",  "__Internal")]
		NSString kGTMSessionFetcherStatusDataKey { get; }

		// extern NSString *const _Nonnull kGTMSessionFetcherNumberOfRetriesDoneKey;
		[Field("kGTMSessionFetcherNumberOfRetriesDoneKey",  "__Internal")]
		NSString kGTMSessionFetcherNumberOfRetriesDoneKey { get; }

		// extern NSString *const _Nonnull kGTMSessionFetcherElapsedIntervalWithRetriesKey;
		[Field("kGTMSessionFetcherElapsedIntervalWithRetriesKey",  "__Internal")]
		NSString kGTMSessionFetcherElapsedIntervalWithRetriesKey { get; }
	}

	// @interface GTMSessionFetcherUserDefaultsFactory : NSObject
	//[BaseType (typeof(NSObject))]
	//interface GTMSessionFetcherUserDefaultsFactory
	//{
	//	// +(NSUserDefaults * _Nonnull)fetcherUserDefaults;
	//	[Static]
	//	[Export ("fetcherUserDefaults")]
	//	//[Verify (MethodToProperty)]
	//	NSUserDefaults FetcherUserDefaults { get; }
	//}

	// typedef void (^GTMSessionFetcherConfigurationBlock)(GTMSessionFetcher * _Nonnull, NSURLSessionConfiguration * _Nonnull);
	delegate void GTMSessionFetcherConfigurationBlock (GTMSessionFetcher arg0, NSUrlSessionConfiguration arg1);

	// typedef void (^GTMSessionFetcherSystemCompletionHandler)();
	delegate void GTMSessionFetcherSystemCompletionHandler ();

	// typedef void (^GTMSessionFetcherCompletionHandler)(NSData * _Nullable, NSError * _Nullable);
	delegate void GTMSessionFetcherCompletionHandler ([NullAllowed] NSData arg0, [NullAllowed] NSError arg1);

	// typedef void (^GTMSessionFetcherBodyStreamProviderResponse)(NSInputStream * _Nonnull);
	delegate void GTMSessionFetcherBodyStreamProviderResponse (NSInputStream arg0);

	// typedef void (^GTMSessionFetcherBodyStreamProvider)(GTMSessionFetcherBodyStreamProviderResponse _Nonnull);
	delegate void GTMSessionFetcherBodyStreamProvider (GTMSessionFetcherBodyStreamProviderResponse arg0);

	// typedef void (^GTMSessionFetcherDidReceiveResponseDispositionBlock)(NSURLSessionResponseDisposition);
	delegate void GTMSessionFetcherDidReceiveResponseDispositionBlock (NSUrlSessionAuthChallengeDisposition arg0);

	// typedef void (^GTMSessionFetcherDidReceiveResponseBlock)(NSURLResponse * _Nonnull, GTMSessionFetcherDidReceiveResponseDispositionBlock _Nonnull);
	delegate void GTMSessionFetcherDidReceiveResponseBlock (NSUrlResponse arg0, GTMSessionFetcherDidReceiveResponseDispositionBlock arg1);

	// typedef void (^GTMSessionFetcherChallengeDispositionBlock)(NSURLSessionAuthChallengeDisposition, NSURLCredential * _Nullable);
	delegate void GTMSessionFetcherChallengeDispositionBlock (NSUrlSessionAuthChallengeDisposition arg0, [NullAllowed] NSUrlCredential arg1);

	// typedef void (^GTMSessionFetcherChallengeBlock)(GTMSessionFetcher * _Nonnull, NSURLAuthenticationChallenge * _Nonnull, GTMSessionFetcherChallengeDispositionBlock _Nonnull);
	delegate void GTMSessionFetcherChallengeBlock (GTMSessionFetcher arg0, NSUrlAuthenticationChallenge arg1, GTMSessionFetcherChallengeDispositionBlock arg2);

	// typedef void (^GTMSessionFetcherWillRedirectResponse)(NSURLRequest * _Nullable);
	delegate void GTMSessionFetcherWillRedirectResponse ([NullAllowed] NSUrlRequest arg0);

	// typedef void (^GTMSessionFetcherWillRedirectBlock)(NSHTTPURLResponse * _Nonnull, NSURLRequest * _Nonnull, GTMSessionFetcherWillRedirectResponse _Nonnull);
	delegate void GTMSessionFetcherWillRedirectBlock (NSHttpUrlResponse arg0, NSUrlRequest arg1, GTMSessionFetcherWillRedirectResponse arg2);

	// typedef void (^GTMSessionFetcherAccumulateDataBlock)(NSData * _Nullable);
	delegate void GTMSessionFetcherAccumulateDataBlock ([NullAllowed] NSData arg0);

	// typedef void (^GTMSessionFetcherSimulateByteTransferBlock)(NSData * _Nullable, int64_t, int64_t, int64_t);
	delegate void GTMSessionFetcherSimulateByteTransferBlock ([NullAllowed] NSData arg0, long arg1, long arg2, long arg3);

	// typedef void (^GTMSessionFetcherReceivedProgressBlock)(int64_t, int64_t);
	delegate void GTMSessionFetcherReceivedProgressBlock (long arg0, long arg1);

	// typedef void (^GTMSessionFetcherDownloadProgressBlock)(int64_t, int64_t, int64_t);
	delegate void GTMSessionFetcherDownloadProgressBlock (long arg0, long arg1, long arg2);

	// typedef void (^GTMSessionFetcherSendProgressBlock)(int64_t, int64_t, int64_t);
	delegate void GTMSessionFetcherSendProgressBlock (long arg0, long arg1, long arg2);

	// typedef void (^GTMSessionFetcherWillCacheURLResponseResponse)(NSCachedURLResponse * _Nullable);
	delegate void GTMSessionFetcherWillCacheURLResponseResponse ([NullAllowed] NSCachedUrlResponse arg0);

	// typedef void (^GTMSessionFetcherWillCacheURLResponseBlock)(NSCachedURLResponse * _Nonnull, GTMSessionFetcherWillCacheURLResponseResponse _Nonnull);
	delegate void GTMSessionFetcherWillCacheURLResponseBlock (NSCachedUrlResponse arg0, GTMSessionFetcherWillCacheURLResponseResponse arg1);

	// typedef void (^GTMSessionFetcherRetryResponse)(BOOL);
	delegate void GTMSessionFetcherRetryResponse (bool arg0);

	// typedef void (^GTMSessionFetcherRetryBlock)(BOOL, NSError * _Nullable, GTMSessionFetcherRetryResponse _Nonnull);
	delegate void GTMSessionFetcherRetryBlock (bool arg0, [NullAllowed] NSError arg1, GTMSessionFetcherRetryResponse arg2);

	// typedef void (^GTMSessionFetcherTestResponse)(NSHTTPURLResponse * _Nullable, NSData * _Nullable, NSError * _Nullable);
	delegate void GTMSessionFetcherTestResponse ([NullAllowed] NSHttpUrlResponse arg0, [NullAllowed] NSData arg1, [NullAllowed] NSError arg2);

	// typedef void (^GTMSessionFetcherTestBlock)(GTMSessionFetcher * _Nonnull, GTMSessionFetcherTestResponse _Nonnull);
	delegate void GTMSessionFetcherTestBlock (GTMSessionFetcher arg0, GTMSessionFetcherTestResponse arg1);

    partial interface IGTMSessionFetcherServiceProtocol {}

	// @protocol GTMSessionFetcherServiceProtocol <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GTMSessionFetcherServiceProtocol
	{
		// @required @property (atomic, strong) dispatch_queue_t _Nonnull callbackQueue;
		[Abstract]
		[Export ("callbackQueue", ArgumentSemantic.Strong)]
		DispatchQueue CallbackQueue { get; set; }

		// @required -(BOOL)fetcherShouldBeginFetching:(GTMSessionFetcher * _Nonnull)fetcher;
		[Abstract]
		[Export ("fetcherShouldBeginFetching:")]
		bool FetcherShouldBeginFetching (GTMSessionFetcher fetcher);

		// @required -(void)fetcherDidCreateSession:(GTMSessionFetcher * _Nonnull)fetcher;
		[Abstract]
		[Export ("fetcherDidCreateSession:")]
		void FetcherDidCreateSession (GTMSessionFetcher fetcher);

		// @required -(void)fetcherDidBeginFetching:(GTMSessionFetcher * _Nonnull)fetcher;
		[Abstract]
		[Export ("fetcherDidBeginFetching:")]
		void FetcherDidBeginFetching (GTMSessionFetcher fetcher);

		// @required -(void)fetcherDidStop:(GTMSessionFetcher * _Nonnull)fetcher;
		[Abstract]
		[Export ("fetcherDidStop:")]
		void FetcherDidStop (GTMSessionFetcher fetcher);

		// @required -(GTMSessionFetcher * _Nonnull)fetcherWithRequest:(NSURLRequest * _Nonnull)request;
		[Abstract]
		[Export ("fetcherWithRequest:")]
		GTMSessionFetcher FetcherWithRequest (NSUrlRequest request);

		// @required -(BOOL)isDelayingFetcher:(GTMSessionFetcher * _Nonnull)fetcher;
		[Abstract]
		[Export ("isDelayingFetcher:")]
		bool IsDelayingFetcher (GTMSessionFetcher fetcher);

		// @required @property (assign, atomic) BOOL reuseSession;
		[Abstract]
		[Export ("reuseSession")]
		bool ReuseSession { get; set; }

		// @required -(NSURLSession * _Nullable)session;
		[Abstract]
		[NullAllowed, Export ("session")]
		//[Verify (MethodToProperty)]
		NSUrlSession Session { get; }

		// @required -(NSURLSession * _Nullable)sessionForFetcherCreation;
		[Abstract]
		[NullAllowed, Export ("sessionForFetcherCreation")]
		//[Verify (MethodToProperty)]
		NSUrlSession SessionForFetcherCreation { get; }

		// @required -(id<NSURLSessionDelegate> _Nullable)sessionDelegate;
		[Abstract]
		[NullAllowed, Export ("sessionDelegate")]
		//[Verify (MethodToProperty)]
		INSUrlSessionDelegate SessionDelegate { get; }

		// @required -(NSDate * _Nullable)stoppedAllFetchersDate;
		[Abstract]
		[NullAllowed, Export ("stoppedAllFetchersDate")]
		//[Verify (MethodToProperty)]
		NSDate StoppedAllFetchersDate { get; }

		// @required @property (readonly, strong) NSOperationQueue * _Nullable delegateQueue;
		[Abstract]
		[NullAllowed, Export ("delegateQueue", ArgumentSemantic.Strong)]
		NSOperationQueue DelegateQueue { get; }
	}

    partial interface IGTMFetcherAuthorizationProtocol {}

	// @protocol GTMFetcherAuthorizationProtocol <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GTMFetcherAuthorizationProtocol
	{
		// @required -(void)authorizeRequest:(NSMutableURLRequest * _Nullable)request delegate:(id _Nonnull)delegate didFinishSelector:(SEL _Nonnull)sel;
		[Abstract]
		[Export ("authorizeRequest:delegate:didFinishSelector:")]
		void AuthorizeRequest ([NullAllowed] NSMutableUrlRequest request, NSObject @delegate, Selector sel);

		// @required -(void)stopAuthorization;
		[Abstract]
		[Export ("stopAuthorization")]
		void StopAuthorization ();

		// @required -(void)stopAuthorizationForRequest:(NSURLRequest * _Nonnull)request;
		[Abstract]
		[Export ("stopAuthorizationForRequest:")]
		void StopAuthorizationForRequest (NSUrlRequest request);

		// @required -(BOOL)isAuthorizingRequest:(NSURLRequest * _Nonnull)request;
		[Abstract]
		[Export ("isAuthorizingRequest:")]
		bool IsAuthorizingRequest (NSUrlRequest request);

		// @required -(BOOL)isAuthorizedRequest:(NSURLRequest * _Nonnull)request;
		[Abstract]
		[Export ("isAuthorizedRequest:")]
		bool IsAuthorizedRequest (NSUrlRequest request);

		// @required @property (readonly, strong) NSString * _Nullable userEmail;
		[Abstract]
		[NullAllowed, Export ("userEmail", ArgumentSemantic.Strong)]
		string UserEmail { get; }

		// @optional @property (readonly) BOOL canAuthorize;
		[Export ("canAuthorize")]
		bool CanAuthorize { get; }

		// @optional @property (assign) BOOL shouldAuthorizeAllRequests;
		[Export ("shouldAuthorizeAllRequests")]
		bool ShouldAuthorizeAllRequests { get; set; }

		// @optional -(void)authorizeRequest:(NSMutableURLRequest * _Nullable)request completionHandler:(void (^ _Nonnull)(NSError * _Nullable))handler;
		[Export ("authorizeRequest:completionHandler:")]
		void AuthorizeRequest ([NullAllowed] NSMutableUrlRequest request, Action<NSError> handler);

		// @optional @property (weak) id<GTMSessionFetcherServiceProtocol> _Nullable fetcherService;
		[NullAllowed, Export ("fetcherService", ArgumentSemantic.Weak)]
		IGTMSessionFetcherServiceProtocol FetcherService { get; set; }

		// @optional -(BOOL)primeForRefresh;
		[Export ("primeForRefresh")]
		//[Verify (MethodToProperty)]
		bool PrimeForRefresh { get; }
	}

    partial interface IGTMUIApplicationProtocol {}
	// @protocol GTMUIApplicationProtocol <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GTMUIApplicationProtocol
	{
		// @required -(UIBackgroundTaskIdentifier)beginBackgroundTaskWithName:(NSString * _Nullable)taskName expirationHandler:(void (^ _Nullable)(void))handler;
		[Abstract]
		[Export ("beginBackgroundTaskWithName:expirationHandler:")]
		nuint BeginBackgroundTaskWithName ([NullAllowed] string taskName, [NullAllowed] Action handler);

		// @required -(void)endBackgroundTask:(UIBackgroundTaskIdentifier)identifier;
		[Abstract]
		[Export ("endBackgroundTask:")]
		void EndBackgroundTask (nuint identifier);
	}

	// @interface GTMSessionFetcher : NSObject <NSURLSessionDelegate>
	[BaseType (typeof(NSObject))]
	interface GTMSessionFetcher : INSUrlSessionDelegate
	{
		// +(instancetype _Nonnull)fetcherWithRequest:(NSURLRequest * _Nullable)request;
		[Static]
		[Export ("fetcherWithRequest:")]
		GTMSessionFetcher FetcherWithRequest ([NullAllowed] NSUrlRequest request);

		// +(instancetype _Nonnull)fetcherWithURL:(NSURL * _Nonnull)requestURL;
		[Static]
		[Export ("fetcherWithURL:")]
		GTMSessionFetcher FetcherWithURL (NSUrl requestURL);

		// +(instancetype _Nonnull)fetcherWithURLString:(NSString * _Nonnull)requestURLString;
		[Static]
		[Export ("fetcherWithURLString:")]
		GTMSessionFetcher FetcherWithURLString (string requestURLString);

		// +(instancetype _Nonnull)fetcherWithDownloadResumeData:(NSData * _Nonnull)resumeData;
		[Static]
		[Export ("fetcherWithDownloadResumeData:")]
		GTMSessionFetcher FetcherWithDownloadResumeData (NSData resumeData);

		// +(instancetype _Nullable)fetcherWithSessionIdentifier:(NSString * _Nonnull)sessionIdentifier;
		[Static]
		[Export ("fetcherWithSessionIdentifier:")]
		[return: NullAllowed]
		GTMSessionFetcher FetcherWithSessionIdentifier (string sessionIdentifier);

		// +(NSArray<GTMSessionFetcher *> * _Nonnull)fetchersForBackgroundSessions;
		[Static]
		[Export ("fetchersForBackgroundSessions")]
		//[Verify (MethodToProperty)]
		GTMSessionFetcher[] FetchersForBackgroundSessions { get; }

		// -(instancetype _Nonnull)initWithRequest:(NSURLRequest * _Nullable)request configuration:(NSURLSessionConfiguration * _Nullable)configuration;
		[Export ("initWithRequest:configuration:")]
		IntPtr Constructor ([NullAllowed] NSUrlRequest request, [NullAllowed] NSUrlSessionConfiguration configuration);

		// @property (strong) NSURLRequest * _Nullable request;
		[NullAllowed, Export ("request", ArgumentSemantic.Strong)]
		NSUrlRequest Request { get; set; }

		// -(void)setRequestValue:(NSString * _Nullable)value forHTTPHeaderField:(NSString * _Nonnull)field;
		[Export ("setRequestValue:forHTTPHeaderField:")]
		void SetRequestValue ([NullAllowed] string value, string field);

		// @property (readonly, atomic) NSMutableURLRequest * _Nullable mutableRequest __attribute__((deprecated("use 'request' or '-setRequestValue:forHTTPHeaderField:'")));
		[NullAllowed, Export ("mutableRequest")]
		NSMutableUrlRequest MutableRequest { get; }

		// @property (readonly, atomic) NSData * _Nullable downloadResumeData;
		[NullAllowed, Export ("downloadResumeData")]
		NSData DownloadResumeData { get; }

		// @property (atomic, strong) NSURLSessionConfiguration * _Nullable configuration;
		[NullAllowed, Export ("configuration", ArgumentSemantic.Strong)]
		NSUrlSessionConfiguration Configuration { get; set; }

		// @property (copy, atomic) GTMSessionFetcherConfigurationBlock _Nullable configurationBlock;
		[NullAllowed, Export ("configurationBlock", ArgumentSemantic.Copy)]
		GTMSessionFetcherConfigurationBlock ConfigurationBlock { get; set; }

		// @property (atomic, strong) NSURLSession * _Nullable session;
		[NullAllowed, Export ("session", ArgumentSemantic.Strong)]
		NSUrlSession Session { get; set; }

		// @property (readonly, atomic) NSURLSessionTask * _Nullable sessionTask;
		[NullAllowed, Export ("sessionTask")]
		NSUrlSessionTask SessionTask { get; }

		// @property (readonly, atomic) NSString * _Nullable sessionIdentifier;
		[NullAllowed, Export ("sessionIdentifier")]
		string SessionIdentifier { get; }

		// @property (readonly, atomic) BOOL wasCreatedFromBackgroundSession;
		[Export ("wasCreatedFromBackgroundSession")]
		bool WasCreatedFromBackgroundSession { get; }

		// @property (atomic, strong) NSDictionary<NSString *,NSString *> * _Nullable sessionUserInfo;
		[NullAllowed, Export ("sessionUserInfo", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSString> SessionUserInfo { get; set; }

		// @property (copy, atomic) NSString * _Nullable taskDescription;
		[NullAllowed, Export ("taskDescription")]
		string TaskDescription { get; set; }

		// @property (assign, atomic) float taskPriority;
		[Export ("taskPriority")]
		float TaskPriority { get; set; }

		// -(NSDictionary<NSString *,NSString *> * _Nullable)sessionIdentifierMetadata;
		[NullAllowed, Export ("sessionIdentifierMetadata")]
		//[Verify (MethodToProperty)]
		NSDictionary<NSString, NSString> SessionIdentifierMetadata { get; }

		// +(void)application:(UIApplication * _Nonnull)application handleEventsForBackgroundURLSession:(NSString * _Nonnull)identifier completionHandler:(GTMSessionFetcherSystemCompletionHandler _Nonnull)completionHandler;
		[Static]
		[Export ("application:handleEventsForBackgroundURLSession:completionHandler:")]
		void Application (UIApplication application, string identifier, GTMSessionFetcherSystemCompletionHandler completionHandler);

		// @property (assign) BOOL useBackgroundSession;
		[Export ("useBackgroundSession")]
		bool UseBackgroundSession { get; set; }

		// @property (readonly, getter = isUsingBackgroundSession, atomic) BOOL usingBackgroundSession;
		[Export ("usingBackgroundSession")]
		bool UsingBackgroundSession { [Bind ("isUsingBackgroundSession")] get; }

		// @property (assign, atomic) BOOL useUploadTask;
		[Export ("useUploadTask")]
		bool UseUploadTask { get; set; }

		// @property (readonly, atomic) BOOL canShareSession;
		[Export ("canShareSession")]
		bool CanShareSession { get; }

		// @property (copy, atomic) NSArray<NSString *> * _Nullable allowedInsecureSchemes;
		[NullAllowed, Export ("allowedInsecureSchemes", ArgumentSemantic.Copy)]
		string[] AllowedInsecureSchemes { get; set; }

		// @property (assign, atomic) BOOL allowLocalhostRequest;
		[Export ("allowLocalhostRequest")]
		bool AllowLocalhostRequest { get; set; }

		// @property (assign, atomic) BOOL allowInvalidServerCertificates;
		[Export ("allowInvalidServerCertificates")]
		bool AllowInvalidServerCertificates { get; set; }

		// @property (atomic, strong) NSHTTPCookieStorage * _Nullable cookieStorage;
		[NullAllowed, Export ("cookieStorage", ArgumentSemantic.Strong)]
		NSHttpCookieStorage CookieStorage { get; set; }

		// @property (atomic, strong) NSURLCredential * _Nullable credential;
		[NullAllowed, Export ("credential", ArgumentSemantic.Strong)]
		NSUrlCredential Credential { get; set; }

		// @property (atomic, strong) NSURLCredential * _Nullable proxyCredential;
		[NullAllowed, Export ("proxyCredential", ArgumentSemantic.Strong)]
		NSUrlCredential ProxyCredential { get; set; }

		// @property (atomic, strong) NSData * _Nullable bodyData;
		[NullAllowed, Export ("bodyData", ArgumentSemantic.Strong)]
		NSData BodyData { get; set; }

		// @property (atomic, strong) NSURL * _Nullable bodyFileURL;
		[NullAllowed, Export ("bodyFileURL", ArgumentSemantic.Strong)]
		NSUrl BodyFileURL { get; set; }

		// @property (readonly, atomic) int64_t bodyLength;
		[Export ("bodyLength")]
		long BodyLength { get; }

		// @property (copy, atomic) GTMSessionFetcherBodyStreamProvider _Nullable bodyStreamProvider;
		[NullAllowed, Export ("bodyStreamProvider", ArgumentSemantic.Copy)]
		GTMSessionFetcherBodyStreamProvider BodyStreamProvider { get; set; }

		// @property (atomic, strong) id<GTMFetcherAuthorizationProtocol> _Nullable authorizer;
		[NullAllowed, Export ("authorizer", ArgumentSemantic.Strong)]
		IGTMFetcherAuthorizationProtocol Authorizer { get; set; }

		// @property (atomic, strong) id<GTMSessionFetcherServiceProtocol> _Nonnull service;
		[Export ("service", ArgumentSemantic.Strong)]
		IGTMSessionFetcherServiceProtocol Service { get; set; }

		// @property (copy, atomic) NSString * _Nullable serviceHost;
		[NullAllowed, Export ("serviceHost")]
		string ServiceHost { get; set; }

		// @property (assign, atomic) NSInteger servicePriority;
		[Export ("servicePriority")]
		nint ServicePriority { get; set; }

		// @property (copy, atomic) GTMSessionFetcherDidReceiveResponseBlock _Nullable didReceiveResponseBlock;
		[NullAllowed, Export ("didReceiveResponseBlock", ArgumentSemantic.Copy)]
		GTMSessionFetcherDidReceiveResponseBlock DidReceiveResponseBlock { get; set; }

		// @property (copy, atomic) GTMSessionFetcherChallengeBlock _Nullable challengeBlock;
		[NullAllowed, Export ("challengeBlock", ArgumentSemantic.Copy)]
		GTMSessionFetcherChallengeBlock ChallengeBlock { get; set; }

		// @property (copy, atomic) GTMSessionFetcherWillRedirectBlock _Nullable willRedirectBlock;
		[NullAllowed, Export ("willRedirectBlock", ArgumentSemantic.Copy)]
		GTMSessionFetcherWillRedirectBlock WillRedirectBlock { get; set; }

		// @property (copy, atomic) GTMSessionFetcherSendProgressBlock _Nullable sendProgressBlock;
		[NullAllowed, Export ("sendProgressBlock", ArgumentSemantic.Copy)]
		GTMSessionFetcherSendProgressBlock SendProgressBlock { get; set; }

		// @property (copy, atomic) GTMSessionFetcherAccumulateDataBlock _Nullable accumulateDataBlock;
		[NullAllowed, Export ("accumulateDataBlock", ArgumentSemantic.Copy)]
		GTMSessionFetcherAccumulateDataBlock AccumulateDataBlock { get; set; }

		// @property (copy, atomic) GTMSessionFetcherReceivedProgressBlock _Nullable receivedProgressBlock;
		[NullAllowed, Export ("receivedProgressBlock", ArgumentSemantic.Copy)]
		GTMSessionFetcherReceivedProgressBlock ReceivedProgressBlock { get; set; }

		// @property (copy, atomic) GTMSessionFetcherDownloadProgressBlock _Nullable downloadProgressBlock;
		[NullAllowed, Export ("downloadProgressBlock", ArgumentSemantic.Copy)]
		GTMSessionFetcherDownloadProgressBlock DownloadProgressBlock { get; set; }

		// @property (copy, atomic) GTMSessionFetcherWillCacheURLResponseBlock _Nullable willCacheURLResponseBlock;
		[NullAllowed, Export ("willCacheURLResponseBlock", ArgumentSemantic.Copy)]
		GTMSessionFetcherWillCacheURLResponseBlock WillCacheURLResponseBlock { get; set; }

		// @property (getter = isRetryEnabled, assign, atomic) BOOL retryEnabled;
		[Export ("retryEnabled")]
		bool RetryEnabled { [Bind ("isRetryEnabled")] get; set; }

		// @property (copy, atomic) GTMSessionFetcherRetryBlock _Nullable retryBlock;
		[NullAllowed, Export ("retryBlock", ArgumentSemantic.Copy)]
		GTMSessionFetcherRetryBlock RetryBlock { get; set; }

		// @property (assign, atomic) NSTimeInterval maxRetryInterval;
		[Export ("maxRetryInterval")]
		double MaxRetryInterval { get; set; }

		// @property (assign, atomic) NSTimeInterval minRetryInterval;
		[Export ("minRetryInterval")]
		double MinRetryInterval { get; set; }

		// @property (assign, atomic) double retryFactor;
		[Export ("retryFactor")]
		double RetryFactor { get; set; }

		// @property (readonly, atomic) NSUInteger retryCount;
		[Export ("retryCount")]
		nuint RetryCount { get; }

		// @property (readonly, atomic) NSTimeInterval nextRetryInterval;
		[Export ("nextRetryInterval")]
		double NextRetryInterval { get; }

		// @property (assign, atomic) BOOL skipBackgroundTask;
		[Export ("skipBackgroundTask")]
		bool SkipBackgroundTask { get; set; }

		// -(void)beginFetchWithDelegate:(id _Nullable)delegate didFinishSelector:(SEL _Nullable)finishedSEL;
		[Export ("beginFetchWithDelegate:didFinishSelector:")]
		void BeginFetchWithDelegate ([NullAllowed] NSObject @delegate, [NullAllowed] Selector finishedSEL);

		// -(void)beginFetchWithCompletionHandler:(GTMSessionFetcherCompletionHandler _Nullable)handler;
		[Export ("beginFetchWithCompletionHandler:")]
		void BeginFetchWithCompletionHandler ([NullAllowed] GTMSessionFetcherCompletionHandler handler);

		// @property (readonly, getter = isFetching, atomic) BOOL fetching;
		[Export ("fetching")]
		bool Fetching { [Bind ("isFetching")] get; }

		// -(void)stopFetching;
		[Export ("stopFetching")]
		void StopFetching ();

		// @property (copy, atomic) GTMSessionFetcherCompletionHandler _Nullable completionHandler;
		[NullAllowed, Export ("completionHandler", ArgumentSemantic.Copy)]
		GTMSessionFetcherCompletionHandler CompletionHandler { get; set; }

		// @property (atomic, strong) void (^ _Nullable)(NSData * _Nonnull) resumeDataBlock;
		[NullAllowed, Export ("resumeDataBlock", ArgumentSemantic.Strong)]
		Action<NSData> ResumeDataBlock { get; set; }

		// @property (readonly, atomic) NSInteger statusCode;
		[Export ("statusCode")]
		nint StatusCode { get; }

		// @property (readonly, atomic, strong) NSDictionary<NSString *,NSString *> * _Nullable responseHeaders;
		[NullAllowed, Export ("responseHeaders", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSString> ResponseHeaders { get; }

		// @property (readonly, atomic, strong) NSURLResponse * _Nullable response;
		[NullAllowed, Export ("response", ArgumentSemantic.Strong)]
		NSUrlResponse Response { get; }

		// @property (readonly, atomic) int64_t downloadedLength;
		[Export ("downloadedLength")]
		long DownloadedLength { get; }

		// @property (readonly, atomic, strong) NSData * _Nullable downloadedData;
		[NullAllowed, Export ("downloadedData", ArgumentSemantic.Strong)]
		NSData DownloadedData { get; }

		// @property (atomic, strong) NSURL * _Nullable destinationFileURL;
		[NullAllowed, Export ("destinationFileURL", ArgumentSemantic.Strong)]
		NSUrl DestinationFileURL { get; set; }

		// @property (readonly, atomic, strong) NSDate * _Nullable initialBeginFetchDate;
		[NullAllowed, Export ("initialBeginFetchDate", ArgumentSemantic.Strong)]
		NSDate InitialBeginFetchDate { get; }

		// @property (atomic, strong) id _Nullable userData;
		[NullAllowed, Export ("userData", ArgumentSemantic.Strong)]
		NSObject UserData { get; set; }

		// @property (copy, atomic) NSDictionary<NSString *,id> * _Nullable properties;
		[NullAllowed, Export ("properties", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Properties { get; set; }

		// -(void)setProperty:(id _Nullable)obj forKey:(NSString * _Nonnull)key;
		[Export ("setProperty:forKey:")]
		void SetProperty ([NullAllowed] NSObject obj, string key);

		// -(id _Nullable)propertyForKey:(NSString * _Nonnull)key;
		[Export ("propertyForKey:")]
		[return: NullAllowed]
		NSObject PropertyForKey (string key);

		// -(void)addPropertiesFromDictionary:(NSDictionary<NSString *,id> * _Nonnull)dict;
		[Export ("addPropertiesFromDictionary:")]
		void AddPropertiesFromDictionary (NSDictionary<NSString, NSObject> dict);

		// @property (copy, atomic) NSString * _Nullable comment;
		[NullAllowed, Export ("comment")]
		string Comment { get; set; }

		// -(void)setCommentWithFormat:(NSString * _Nonnull)format, ... __attribute__((format(NSString, 1, 2)));
		[Internal]
		[Export ("setCommentWithFormat:", IsVariadic = true)]
		void SetCommentWithFormat (string format, IntPtr varArgs);

		// @property (copy, atomic) NSString * _Nullable log;
		[NullAllowed, Export ("log")]
		string Log { get; set; }

		// @property (atomic, strong) dispatch_queue_t _Null_unspecified callbackQueue;
		[Export ("callbackQueue", ArgumentSemantic.Strong)]
		DispatchQueue CallbackQueue { get; set; }

		// @property (atomic, strong) NSOperationQueue * _Null_unspecified sessionDelegateQueue;
		[Export ("sessionDelegateQueue", ArgumentSemantic.Strong)]
		NSOperationQueue SessionDelegateQueue { get; set; }

		// -(BOOL)waitForCompletionWithTimeout:(NSTimeInterval)timeoutInSeconds;
		[Export ("waitForCompletionWithTimeout:")]
		bool WaitForCompletionWithTimeout (double timeoutInSeconds);

		// @property (copy, atomic) GTMSessionFetcherTestBlock _Nullable testBlock;
		[NullAllowed, Export ("testBlock", ArgumentSemantic.Copy)]
		GTMSessionFetcherTestBlock TestBlock { get; set; }

		// +(void)setGlobalTestBlock:(GTMSessionFetcherTestBlock _Nullable)block;
		[Static]
		[Export ("setGlobalTestBlock:")]
		void SetGlobalTestBlock ([NullAllowed] GTMSessionFetcherTestBlock block);

		// @property (readwrite, atomic) NSUInteger testBlockAccumulateDataChunkCount;
		[Export ("testBlockAccumulateDataChunkCount")]
		nuint TestBlockAccumulateDataChunkCount { get; set; }

		// +(id<GTMUIApplicationProtocol> _Nullable)substituteUIApplication;
		// +(void)setSubstituteUIApplication:(id<GTMUIApplicationProtocol> _Nullable)substituteUIApplication;
		[Static]
		[NullAllowed, Export ("substituteUIApplication")]
		//[Verify (MethodToProperty)]
		IGTMUIApplicationProtocol SubstituteUIApplication { get; set; }

		// +(GTMSessionCookieStorage * _Nonnull)staticCookieStorage;
		[Static]
		[Export ("staticCookieStorage")]
		//[Verify (MethodToProperty)]
		GTMSessionCookieStorage StaticCookieStorage { get; }

		// +(BOOL)appAllowsInsecureRequests;
		[Static]
		[Export ("appAllowsInsecureRequests")]
		//[Verify (MethodToProperty)]
		bool AppAllowsInsecureRequests { get; }

		// +(void)setLoggingEnabled:(BOOL)flag;
		[Static]
		[Export ("setLoggingEnabled:")]
		void SetLoggingEnabled (bool flag);

		// +(BOOL)isLoggingEnabled;
		[Static]
		[Export ("isLoggingEnabled")]
		//[Verify (MethodToProperty)]
		bool IsLoggingEnabled { get; }
	}

	// @interface BackwardsCompatibilityOnly (GTMSessionFetcher)
	[Category]
	[BaseType (typeof(GTMSessionFetcher))]
	interface GTMSessionFetcher_BackwardsCompatibilityOnly
	{
		// -(void)setCookieStorageMethod:(NSInteger)method;
        [Static]
		[Export ("setCookieStorageMethod:")]
		void SetCookieStorageMethod (nint method);
	}

	// @interface GTMSessionCookieStorage : NSHTTPCookieStorage
	[BaseType (typeof(NSHttpCookieStorage))]
	interface GTMSessionCookieStorage
	{
		// -(void)setCookies:(NSArray<NSHTTPCookie *> * _Nullable)cookies;
		[Export ("setCookies:")]
		void SetCookies ([NullAllowed] NSHttpCookie[] cookies);

		// -(void)removeAllCookies;
		[Export ("removeAllCookies")]
		void RemoveAllCookies ();
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull kGTMSessionFetcherServiceSessionBecameInvalidNotification;
		[Field("kGTMSessionFetcherServiceSessionBecameInvalidNotification",  "__Internal")]
		NSString kGTMSessionFetcherServiceSessionBecameInvalidNotification { get; }

		// extern NSString *const _Nonnull kGTMSessionFetcherServiceSessionKey;
		[Field("kGTMSessionFetcherServiceSessionKey",  "__Internal")]
		NSString kGTMSessionFetcherServiceSessionKey { get; }
	}

	// @interface GTMSessionFetcherService : NSObject <GTMSessionFetcherServiceProtocol>
	[BaseType (typeof(NSObject))]
	interface GTMSessionFetcherService : GTMSessionFetcherServiceProtocol
	{
		// @property (readonly, atomic, strong) NSDictionary<NSString *,NSArray *> * _Nullable delayedFetchersByHost;
		[NullAllowed, Export ("delayedFetchersByHost", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSArray> DelayedFetchersByHost { get; }

		// @property (readonly, atomic, strong) NSDictionary<NSString *,NSArray *> * _Nullable runningFetchersByHost;
		[NullAllowed, Export ("runningFetchersByHost", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSArray> RunningFetchersByHost { get; }

		// @property (assign, atomic) NSUInteger maxRunningFetchersPerHost;
		[Export ("maxRunningFetchersPerHost")]
		nuint MaxRunningFetchersPerHost { get; set; }

		// @property (atomic, strong) NSURLSessionConfiguration * _Nullable configuration;
		[NullAllowed, Export ("configuration", ArgumentSemantic.Strong)]
		NSUrlSessionConfiguration Configuration { get; set; }

		// @property (copy, atomic) GTMSessionFetcherConfigurationBlock _Nullable configurationBlock;
		[NullAllowed, Export ("configurationBlock", ArgumentSemantic.Copy)]
		GTMSessionFetcherConfigurationBlock ConfigurationBlock { get; set; }

		// @property (atomic, strong) NSHTTPCookieStorage * _Nullable cookieStorage;
		[NullAllowed, Export ("cookieStorage", ArgumentSemantic.Strong)]
		NSHttpCookieStorage CookieStorage { get; set; }

		// @property (atomic, strong) dispatch_queue_t _Null_unspecified callbackQueue;
		[Export ("callbackQueue", ArgumentSemantic.Strong)]
		DispatchQueue CallbackQueue { get; set; }

		// @property (copy, atomic) GTMSessionFetcherChallengeBlock _Nullable challengeBlock;
		[NullAllowed, Export ("challengeBlock", ArgumentSemantic.Copy)]
		GTMSessionFetcherChallengeBlock ChallengeBlock { get; set; }

		// @property (atomic, strong) NSURLCredential * _Nullable credential;
		[NullAllowed, Export ("credential", ArgumentSemantic.Strong)]
		NSUrlCredential Credential { get; set; }

		// @property (atomic, strong) NSURLCredential * _Nonnull proxyCredential;
		[Export ("proxyCredential", ArgumentSemantic.Strong)]
		NSUrlCredential ProxyCredential { get; set; }

		// @property (copy, atomic) NSArray<NSString *> * _Nullable allowedInsecureSchemes;
		[NullAllowed, Export ("allowedInsecureSchemes", ArgumentSemantic.Copy)]
		string[] AllowedInsecureSchemes { get; set; }

		// @property (assign, atomic) BOOL allowLocalhostRequest;
		[Export ("allowLocalhostRequest")]
		bool AllowLocalhostRequest { get; set; }

		// @property (assign, atomic) BOOL allowInvalidServerCertificates;
		[Export ("allowInvalidServerCertificates")]
		bool AllowInvalidServerCertificates { get; set; }

		// @property (getter = isRetryEnabled, assign, atomic) BOOL retryEnabled;
		[Export ("retryEnabled")]
		bool RetryEnabled { [Bind ("isRetryEnabled")] get; set; }

		// @property (copy, atomic) GTMSessionFetcherRetryBlock _Nullable retryBlock;
		[NullAllowed, Export ("retryBlock", ArgumentSemantic.Copy)]
		GTMSessionFetcherRetryBlock RetryBlock { get; set; }

		// @property (assign, atomic) NSTimeInterval maxRetryInterval;
		[Export ("maxRetryInterval")]
		double MaxRetryInterval { get; set; }

		// @property (assign, atomic) NSTimeInterval minRetryInterval;
		[Export ("minRetryInterval")]
		double MinRetryInterval { get; set; }

		// @property (copy, atomic) NSDictionary<NSString *,id> * _Nullable properties;
		[NullAllowed, Export ("properties", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Properties { get; set; }

		// @property (assign, atomic) BOOL skipBackgroundTask;
		[Export ("skipBackgroundTask")]
		bool SkipBackgroundTask { get; set; }

		// @property (copy, atomic) NSString * _Nullable userAgent;
		[NullAllowed, Export ("userAgent")]
		string UserAgent { get; set; }

		// @property (atomic, strong) id<GTMFetcherAuthorizationProtocol> _Nullable authorizer;
		[NullAllowed, Export ("authorizer", ArgumentSemantic.Strong)]
		IGTMFetcherAuthorizationProtocol Authorizer { get; set; }

		// @property (atomic, strong) NSOperationQueue * _Null_unspecified sessionDelegateQueue;
		[Export ("sessionDelegateQueue", ArgumentSemantic.Strong)]
		NSOperationQueue SessionDelegateQueue { get; set; }

		// @property (assign, atomic) BOOL reuseSession;
		[Export ("reuseSession")]
		bool ReuseSession { get; set; }

		// @property (assign, atomic) NSTimeInterval unusedSessionTimeout;
		[Export ("unusedSessionTimeout")]
		double UnusedSessionTimeout { get; set; }

		// -(void)resetSession;
		[Export ("resetSession")]
		void ResetSession ();

		// -(GTMSessionFetcher * _Nonnull)fetcherWithRequest:(NSURLRequest * _Nonnull)request;
		[Export ("fetcherWithRequest:")]
		GTMSessionFetcher FetcherWithRequest (NSUrlRequest request);

		// -(GTMSessionFetcher * _Nonnull)fetcherWithURL:(NSURL * _Nonnull)requestURL;
		[Export ("fetcherWithURL:")]
		GTMSessionFetcher FetcherWithURL (NSUrl requestURL);

		// -(GTMSessionFetcher * _Nonnull)fetcherWithURLString:(NSString * _Nonnull)requestURLString;
		[Export ("fetcherWithURLString:")]
		GTMSessionFetcher FetcherWithURLString (string requestURLString);

		// -(id _Nonnull)fetcherWithRequest:(NSURLRequest * _Nonnull)request fetcherClass:(Class _Nonnull)fetcherClass;
		[Export ("fetcherWithRequest:fetcherClass:")]
		NSObject FetcherWithRequest (NSUrlRequest request, Class fetcherClass);

		// -(BOOL)isDelayingFetcher:(GTMSessionFetcher * _Nonnull)fetcher;
		[Export ("isDelayingFetcher:")]
		bool IsDelayingFetcher (GTMSessionFetcher fetcher);

		// -(NSUInteger)numberOfFetchers;
		[Export ("numberOfFetchers")]
		//[Verify (MethodToProperty)]
		nuint NumberOfFetchers { get; }

		// -(NSUInteger)numberOfRunningFetchers;
		[Export ("numberOfRunningFetchers")]
		//[Verify (MethodToProperty)]
		nuint NumberOfRunningFetchers { get; }

		// -(NSUInteger)numberOfDelayedFetchers;
		[Export ("numberOfDelayedFetchers")]
		//[Verify (MethodToProperty)]
		nuint NumberOfDelayedFetchers { get; }

		// -(NSArray<GTMSessionFetcher *> * _Nullable)issuedFetchers;
		[NullAllowed, Export ("issuedFetchers")]
		//[Verify (MethodToProperty)]
		GTMSessionFetcher[] IssuedFetchers { get; }

		// -(NSArray<GTMSessionFetcher *> * _Nullable)issuedFetchersWithRequestURL:(NSURL * _Nonnull)requestURL;
		[Export ("issuedFetchersWithRequestURL:")]
		[return: NullAllowed]
		GTMSessionFetcher[] IssuedFetchersWithRequestURL (NSUrl requestURL);

		// -(void)stopAllFetchers;
		[Export ("stopAllFetchers")]
		void StopAllFetchers ();

		// -(NSURLSession * _Nullable)session;
		[NullAllowed, Export ("session")]
		//[Verify (MethodToProperty)]
		NSUrlSession Session { get; }

		// -(NSURLSession * _Nullable)sessionForFetcherCreation;
		[NullAllowed, Export ("sessionForFetcherCreation")]
		//[Verify (MethodToProperty)]
		NSUrlSession SessionForFetcherCreation { get; }

		// -(id<NSURLSessionDelegate> _Nullable)sessionDelegate;
		[NullAllowed, Export ("sessionDelegate")]
		//[Verify (MethodToProperty)]
		INSUrlSessionDelegate SessionDelegate { get; }

		// -(NSDate * _Nullable)stoppedAllFetchersDate;
		[NullAllowed, Export ("stoppedAllFetchersDate")]
		//[Verify (MethodToProperty)]
		NSDate StoppedAllFetchersDate { get; }

		// @property (copy, atomic) GTMSessionFetcherTestBlock _Nullable testBlock;
		[NullAllowed, Export ("testBlock", ArgumentSemantic.Copy)]
		GTMSessionFetcherTestBlock TestBlock { get; set; }
	}

	// @interface TestingSupport (GTMSessionFetcherService)
	[Category]
	[BaseType (typeof(GTMSessionFetcherService))]
	interface GTMSessionFetcherService_TestingSupport
	{
		// +(instancetype _Nonnull)mockFetcherServiceWithFakedData:(NSData * _Nullable)fakedDataOrNil fakedError:(NSError * _Nullable)fakedErrorOrNil;
		[Static]
		[Export ("mockFetcherServiceWithFakedData:fakedError:")]
		GTMSessionFetcherService MockFetcherServiceWithFakedData ([NullAllowed] NSData fakedDataOrNil, [NullAllowed] NSError fakedErrorOrNil);

		// -(BOOL)waitForCompletionOfAllFetchersWithTimeout:(NSTimeInterval)timeoutInSeconds;
		[Static]
        [Export ("waitForCompletionOfAllFetchersWithTimeout:")]
		bool WaitForCompletionOfAllFetchersWithTimeout (double timeoutInSeconds);
	}

	// @interface BackwardsCompatibilityOnly (GTMSessionFetcherService)
	[Category]
	[BaseType (typeof(GTMSessionFetcherService))]
	interface GTMSessionFetcherService_BackwardsCompatibilityOnly
	{
        // @property (assign, atomic) NSInteger cookieStorageMethod;
        [Static]
        [Export("cookieStorageMethod")]
		nint CookieStorageMethod();
		[Static]
        [Export("setCookieStorageMethod:")]
		void SetCookieStorageMethod();
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const int64_t kGTMSessionUploadFetcherUnknownFileSize;
		[Field("kGTMSessionUploadFetcherUnknownFileSize",  "__Internal")]
		long kGTMSessionUploadFetcherUnknownFileSize { get; }

		// extern const int64_t kGTMSessionUploadFetcherStandardChunkSize;
		[Field("kGTMSessionUploadFetcherStandardChunkSize",  "__Internal")]
		long kGTMSessionUploadFetcherStandardChunkSize { get; }

		// extern const int64_t kGTMSessionUploadFetcherMaximumDemandBufferSize;
		[Field("kGTMSessionUploadFetcherMaximumDemandBufferSize",  "__Internal")]
		long kGTMSessionUploadFetcherMaximumDemandBufferSize { get; }

		// extern NSString *const _Nonnull kGTMSessionFetcherUploadLocationObtainedNotification;
		[Field("kGTMSessionFetcherUploadLocationObtainedNotification",  "__Internal")]
		NSString kGTMSessionFetcherUploadLocationObtainedNotification { get; }
	}

	// typedef void (^GTMSessionUploadFetcherDataProviderResponse)(NSData * _Nullable, int64_t, NSError * _Nullable);
	delegate void GTMSessionUploadFetcherDataProviderResponse ([NullAllowed] NSData arg0, long arg1, [NullAllowed] NSError arg2);

	// typedef void (^GTMSessionUploadFetcherDataProvider)(int64_t, int64_t, GTMSessionUploadFetcherDataProviderResponse _Nonnull);
	delegate void GTMSessionUploadFetcherDataProvider (long arg0, long arg1, GTMSessionUploadFetcherDataProviderResponse arg2);

	// @interface GTMSessionUploadFetcher : GTMSessionFetcher
	[BaseType (typeof(GTMSessionFetcher))]
	interface GTMSessionUploadFetcher
	{
		// +(instancetype _Nonnull)uploadFetcherWithRequest:(NSURLRequest * _Nonnull)request uploadMIMEType:(NSString * _Nonnull)uploadMIMEType chunkSize:(int64_t)chunkSize fetcherService:(GTMSessionFetcherService * _Nullable)fetcherServiceOrNil;
		[Static]
		[Export ("uploadFetcherWithRequest:uploadMIMEType:chunkSize:fetcherService:")]
		GTMSessionUploadFetcher UploadFetcherWithRequest (NSUrlRequest request, string uploadMIMEType, long chunkSize, [NullAllowed] GTMSessionFetcherService fetcherServiceOrNil);

		// +(instancetype _Nonnull)uploadFetcherWithLocation:(NSURL * _Nullable)uploadLocationURL uploadMIMEType:(NSString * _Nonnull)uploadMIMEType chunkSize:(int64_t)chunkSize fetcherService:(GTMSessionFetcherService * _Nullable)fetcherServiceOrNil;
		[Static]
		[Export ("uploadFetcherWithLocation:uploadMIMEType:chunkSize:fetcherService:")]
		GTMSessionUploadFetcher UploadFetcherWithLocation ([NullAllowed] NSUrl uploadLocationURL, string uploadMIMEType, long chunkSize, [NullAllowed] GTMSessionFetcherService fetcherServiceOrNil);

		// -(void)setUploadDataLength:(int64_t)fullLength provider:(GTMSessionUploadFetcherDataProvider _Nullable)block;
		[Export ("setUploadDataLength:provider:")]
		void SetUploadDataLength (long fullLength, [NullAllowed] GTMSessionUploadFetcherDataProvider block);

		// +(NSArray * _Nonnull)uploadFetchersForBackgroundSessions;
		[Static]
		[Export ("uploadFetchersForBackgroundSessions")]
		//[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
		NSObject[] UploadFetchersForBackgroundSessions { get; }

		// +(instancetype _Nullable)uploadFetcherForSessionIdentifier:(NSString * _Nonnull)sessionIdentifier;
		[Static]
		[Export ("uploadFetcherForSessionIdentifier:")]
		[return: NullAllowed]
		GTMSessionUploadFetcher UploadFetcherForSessionIdentifier (string sessionIdentifier);

		// -(void)pauseFetching;
		[Export ("pauseFetching")]
		void PauseFetching ();

		// -(void)resumeFetching;
		[Export ("resumeFetching")]
		void ResumeFetching ();

		// -(BOOL)isPaused;
		[Export ("isPaused")]
		//[Verify (MethodToProperty)]
		bool IsPaused { get; }

		// @property (atomic, strong) NSURL * _Nullable uploadLocationURL;
		[NullAllowed, Export ("uploadLocationURL", ArgumentSemantic.Strong)]
		NSUrl UploadLocationURL { get; set; }

		// @property (atomic, strong) NSData * _Nullable uploadData;
		[NullAllowed, Export ("uploadData", ArgumentSemantic.Strong)]
		NSData UploadData { get; set; }

		// @property (atomic, strong) NSURL * _Nullable uploadFileURL;
		[NullAllowed, Export ("uploadFileURL", ArgumentSemantic.Strong)]
		NSUrl UploadFileURL { get; set; }

		// @property (atomic, strong) NSFileHandle * _Nullable uploadFileHandle;
		[NullAllowed, Export ("uploadFileHandle", ArgumentSemantic.Strong)]
		NSFileHandle UploadFileHandle { get; set; }

		// @property (readonly, copy, atomic) GTMSessionUploadFetcherDataProvider _Nullable uploadDataProvider;
		[NullAllowed, Export ("uploadDataProvider", ArgumentSemantic.Copy)]
		GTMSessionUploadFetcherDataProvider UploadDataProvider { get; }

		// @property (copy, atomic) NSString * _Nonnull uploadMIMEType;
		[Export ("uploadMIMEType")]
		string UploadMIMEType { get; set; }

		// @property (assign, atomic) int64_t chunkSize;
		[Export ("chunkSize")]
		long ChunkSize { get; set; }

		// @property (readonly, assign, atomic) int64_t currentOffset;
		[Export ("currentOffset")]
		long CurrentOffset { get; }

		// @property (atomic, strong) GTMSessionFetcher * _Nullable chunkFetcher;
		[NullAllowed, Export ("chunkFetcher", ArgumentSemantic.Strong)]
		GTMSessionFetcher ChunkFetcher { get; set; }

		// @property (readonly, atomic) GTMSessionFetcher * _Nonnull activeFetcher;
		[Export ("activeFetcher")]
		GTMSessionFetcher ActiveFetcher { get; }

		// @property (readonly, atomic) NSURLRequest * _Nullable lastChunkRequest;
		[NullAllowed, Export ("lastChunkRequest")]
		NSUrlRequest LastChunkRequest { get; }

		// @property (assign, atomic) NSInteger statusCode;
		[Export ("statusCode")]
		nint StatusCode { get; set; }

		// @property (readonly, atomic) dispatch_queue_t _Nullable delegateCallbackQueue;
		[NullAllowed, Export ("delegateCallbackQueue")]
		DispatchQueue DelegateCallbackQueue { get; }

		// @property (readonly, atomic) GTMSessionFetcherCompletionHandler _Nullable delegateCompletionHandler;
		[NullAllowed, Export ("delegateCompletionHandler")]
		GTMSessionFetcherCompletionHandler DelegateCompletionHandler { get; }
	}

	// @interface GTMSessionUploadFetcherMethods (GTMSessionFetcher)
	[Category]
	[BaseType (typeof(GTMSessionFetcher))]
	interface GTMSessionFetcher_GTMSessionUploadFetcherMethods
	{
        // @property (readonly) GTMSessionUploadFetcher * _Nullable parentUploadFetcher;
        [Static]
        [NullAllowed, Export("parentUploadFetcher")]
        GTMSessionUploadFetcher ParentUploadFetcher();
	}
}
