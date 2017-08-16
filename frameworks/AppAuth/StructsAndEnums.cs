using System;
using ObjCRuntime;

namespace AppAuth
{
	[Native]
	public enum OIDErrorCode : nint
	{
		InvalidDiscoveryDocument = -2,
		UserCanceledAuthorizationFlow = -3,
		ProgramCanceledAuthorizationFlow = -4,
		NetworkError = -5,
		ServerError = -6,
		JSONDeserializationError = -7,
		TokenResponseConstructionError = -8,
		SafariOpenError = -9,
		BrowserOpenError = -10,
		TokenRefreshError = -11,
		RegistrationResponseConstructionError = -12,
		JSONSerializationError = -13
	}

	[Native]
	public enum OIDErrorCodeOAuth : nint
	{
		InvalidRequest = -2,
		UnauthorizedClient = -3,
		AccessDenied = -4,
		UnsupportedResponseType = -5,
		InvalidScope = -6,
		ServerError = -7,
		TemporarilyUnavailable = -8,
		InvalidClient = -9,
		InvalidGrant = -10,
		UnsupportedGrantType = -11,
		InvalidRedirectURI = -12,
		InvalidClientMetadata = -13,
		ClientError = -61439,
		Other = -61440
	}

	[Native]
	public enum OIDErrorCodeOAuthAuthorization : nint
	{
		InvalidRequest = OIDErrorCodeOAuthInvalidRequest,
		UnauthorizedClient = OIDErrorCodeOAuthUnauthorizedClient,
		AccessDenied = OIDErrorCodeOAuthAccessDenied,
		UnsupportedResponseType = OIDErrorCodeOAuthUnsupportedResponseType,
		AuthorizationInvalidScope = OIDErrorCodeOAuthInvalidScope,
		ServerError = OIDErrorCodeOAuthServerError,
		TemporarilyUnavailable = OIDErrorCodeOAuthTemporarilyUnavailable,
		ClientError = OIDErrorCodeOAuthClientError,
		Other = OIDErrorCodeOAuthOther
	}

	[Native]
	public enum OIDErrorCodeOAuthToken : nint
	{
		InvalidRequest = OIDErrorCodeOAuthInvalidRequest,
		InvalidClient = OIDErrorCodeOAuthInvalidClient,
		InvalidGrant = OIDErrorCodeOAuthInvalidGrant,
		UnauthorizedClient = OIDErrorCodeOAuthUnauthorizedClient,
		UnsupportedGrantType = OIDErrorCodeOAuthUnsupportedGrantType,
		InvalidScope = OIDErrorCodeOAuthInvalidScope,
		ClientError = OIDErrorCodeOAuthClientError,
		Other = OIDErrorCodeOAuthOther
	}

	[Native]
	public enum OIDErrorCodeOAuthRegistration : nint
	{
		InvalidRequest = OIDErrorCodeOAuthInvalidRequest,
		InvalidRedirectURI = OIDErrorCodeOAuthInvalidRedirectURI,
		InvalidClientMetadata = OIDErrorCodeOAuthInvalidClientMetadata,
		ClientError = OIDErrorCodeOAuthClientError,
		Other = OIDErrorCodeOAuthOther
	}
}
