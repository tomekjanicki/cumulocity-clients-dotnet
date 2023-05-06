///
/// OperationsApiTest.cs
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
using Client.Com.Cumulocity.Client.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Com.Cumulocity.Client.Supplementary;

namespace Test.Com.Cumulocity.Client.Api;

[TestClass]
public sealed class OperationsApiTest
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
        OperationsApiTest.HttpClient = new HttpClient(httpClientHandler)
        {
            BaseAddress = new Uri(configuration.Hostname)
        };
    }
	
    [TestMethod]
    public async void TestGetOperations()
    {
        var api = new OperationsApi(HttpClient!);
        var response = await api.GetOperations<Operation>();
        Debug.Assert(response != null);
    }
}
