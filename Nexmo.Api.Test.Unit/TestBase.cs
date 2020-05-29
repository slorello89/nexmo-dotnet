﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;

namespace Nexmo.Api.Test.Unit
{
    public class TestBase
    {
        const string MOCKED_METHOD = "SendAsync";
        protected string ApiUrl = Configuration.Instance.Settings["appSettings:Nexmo.Url.Api"];
        protected string RestUrl = Configuration.Instance.Settings["appSettings:Nexmo.Url.Rest"];
        protected string ApiKey = Environment.GetEnvironmentVariable("NEXMO_API_KEY")??"testKey";
        protected string ApiSecret = Environment.GetEnvironmentVariable("NEXMO_API_Secret") ?? "testSecret";
        protected string AppId = Environment.GetEnvironmentVariable("APPLICATION_ID")?? "afed99d2-ae38-487c-bb5a-fe2518febd44";
        protected string PrivateKey = Environment.GetEnvironmentVariable("PRIVATE_KEY") ?? @"-----BEGIN RSA PRIVATE KEY-----
MIICXAIBAAKBgQCqGKukO1De7zhZj6+H0qtjTkVxwTCpvKe4eCZ0FPqri0cb2JZfXJ/DgYSF6vUp
wmJG8wVQZKjeGcjDOL5UlsuusFncCzWBQ7RKNUSesmQRMSGkVb1/3j+skZ6UtW+5u09lHNsj6tQ5
1s1SPrCBkedbNf0Tp0GbMJDyR4e9T04ZZwIDAQABAoGAFijko56+qGyN8M0RVyaRAXz++xTqHBLh
3tx4VgMtrQ+WEgCjhoTwo23KMBAuJGSYnRmoBZM3lMfTKevIkAidPExvYCdm5dYq3XToLkkLv5L2
pIIVOFMDG+KESnAFV7l2c+cnzRMW0+b6f8mR1CJzZuxVLL6Q02fvLi55/mbSYxECQQDeAw6fiIQX
GukBI4eMZZt4nscy2o12KyYner3VpoeE+Np2q+Z3pvAMd/aNzQ/W9WaI+NRfcxUJrmfPwIGm63il
AkEAxCL5HQb2bQr4ByorcMWm/hEP2MZzROV73yF41hPsRC9m66KrheO9HPTJuo3/9s5p+sqGxOlF
L0NDt4SkosjgGwJAFklyR1uZ/wPJjj611cdBcztlPdqoxssQGnh85BzCj/u3WqBpE2vjvyyvyI5k
X6zk7S0ljKtt2jny2+00VsBerQJBAJGC1Mg5Oydo5NwD6BiROrPxGo2bpTbu/fhrT8ebHkTz2epl
U9VQQSQzY1oZMVX8i1m5WUTLPz2yLJIBQVdXqhMCQBGoiuSoSjafUhV7i1cEGpb88h5NBYZzWXGZ
37sJ5QsW+sJyoNde3xH8vdXhzU7eT82D6X/scw9RZz+/6rCJ4p0=
-----END RSA PRIVATE KEY-----";
        public void Setup(string uri, string responseContent, string requestContent = null, HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            typeof(Configuration).GetField("_client", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(Configuration.Instance, null);
            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(MOCKED_METHOD,
                ItExpr.Is<HttpRequestMessage>(
                    x => 
                    string.Equals(x.RequestUri.AbsoluteUri, uri, StringComparison.OrdinalIgnoreCase) && 
                    (requestContent == null) || 
                    (string.Equals(x.Content.ReadAsStringAsync().Result, requestContent, StringComparison.OrdinalIgnoreCase))),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = expectedCode,
                    Content = new StringContent(responseContent)
                })
                .Verifiable();
            Configuration.Instance.ClientHandler = mockHandler.Object;
            
        }

        public void Setup(string uri, byte[] responseContent, HttpStatusCode expectedCode = HttpStatusCode.OK)
        {
            typeof(Configuration).GetField("_client", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(Configuration.Instance, null);
            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(MOCKED_METHOD,
                ItExpr.Is<HttpRequestMessage>(
                    x =>
                    string.Equals(x.RequestUri.AbsoluteUri, uri, StringComparison.OrdinalIgnoreCase)),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = expectedCode,
                    Content = new StreamContent(new MemoryStream(responseContent))
                })
                .Verifiable();
            Configuration.Instance.ClientHandler = mockHandler.Object;

        }
    }
}
