///
/// ApplicationsApiTest.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Client.Com.Cumulocity.Client.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Com.Cumulocity.Client.Supplementary;

namespace Test.Com.Cumulocity.Client.Api;

[TestClass]
public class ApplicationsApiTest
{
	
    private static HttpClient? HttpClient { get; set; }
	
    [ClassInitialize]
    public static void SetupHttpClient(TestContext context)
    {
        var configuration = new TestConfiguration();
        configuration.Load();
	
        var httpClientHandler = new HttpClientHandler()
        {
            Credentials = new NetworkCredential(configuration.Username, configuration.Password)
        };
        ApplicationsApiTest.HttpClient = new HttpClient(httpClientHandler)
        {
            BaseAddress = new Uri(configuration.Hostname)
        };
    }
	
    [TestMethod]
    public async void TestGetApplications()
    {
        var api = new ApplicationsApi(HttpClient!);
        var response = await api.GetApplications();
        Debug.Assert(response != null);
    }
}
