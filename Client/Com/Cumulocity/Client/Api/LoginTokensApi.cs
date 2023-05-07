///
/// LoginTokensApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Net.Http;

namespace Client.Com.Cumulocity.Client.Api;

/// <summary> 
/// API methods to obtain access tokens to the Cumulocity IoT platform in case of OAI-Secure or SSO authentication. <br />
/// </summary>
///

public sealed class LoginTokensApi : ILoginTokensApi
{
    public LoginTokensApi(HttpClient httpClient)
    {
    }
	
}
