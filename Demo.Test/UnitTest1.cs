// Copyright (c) Mohamed Hassan & Contributors. All rights reserved. See License.md in the project root for license information.

namespace Demo.Test;

using System.Net;
using System.Net.Http.Headers;
using DemoLib;
using Newtonsoft.Json.Linq;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void Test2()
    {
        var api_key = Environment.GetEnvironmentVariable("API_KEY");
        Console.WriteLine($"api_key: {api_key}");
        var helper = new Helper();
        Assert.AreEqual("Hello from DemoLib", helper.GetMessage());
    }

    [Test]
    public async Task Test3()
    {
        var token = Environment.GetEnvironmentVariable("appveyor_token");
        Console.WriteLine($"token: {token}");
        var account = Environment.GetEnvironmentVariable("appveyor_account");
        Console.WriteLine($"account: {account}");
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        // get the list of projects
        using var response = await client
            .GetAsync($"https://ci.appveyor.com/api/account/{account}/projects");
        response.EnsureSuccessStatusCode();

        var projects = await response.Content.ReadAsStringAsync();
        Console.WriteLine(projects);
        var json = JArray.Parse(projects);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}
