using System.Runtime.InteropServices;

namespace GTMAppAuth
{
	static class CFunctions
	{
		// extern int NS_ENUM (int NSInteger, int GTMAppAuthFetcherAuthorizationError);
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern int NS_ENUM (int NSInteger, int GTMAppAuthFetcherAuthorizationError);
	}
}
