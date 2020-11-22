using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TestWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .ConfigureKestrel( kestrelOptions => 
                    {
                        kestrelOptions.ConfigureHttpsDefaults(configureOptions =>
                       {
                           configureOptions.SslProtocols = System.Security.Authentication.SslProtocols.Tls12 | System.Security.Authentication.SslProtocols.Tls13;
                       });
                    })
                    .UseStartup<Startup>();
                });

        // Ciphersuit policy for this server:
static readonly System.Net.Security.CipherSuitesPolicy cipherSuitesPolicy = new System.Net.Security.CipherSuitesPolicy
    (
        new System.Net.Security.TlsCipherSuite[]
        {
            // Cipher suits as recommended by: https://wiki.mozilla.org/Security/Server_Side_TLS
            // Listed in preferred order.

            // Highly secure TLS 1.3 cipher suits:
            System.Net.Security.TlsCipherSuite.TLS_AES_128_GCM_SHA256,
            System.Net.Security.TlsCipherSuite.TLS_AES_256_GCM_SHA384,
            System.Net.Security.TlsCipherSuite.TLS_CHACHA20_POLY1305_SHA256,

            // Medium secure compatibility TLS 1.2 cipher suits:
            System.Net.Security.TlsCipherSuite.TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256,
            System.Net.Security.TlsCipherSuite.TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256,
            System.Net.Security.TlsCipherSuite.TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384,
            System.Net.Security.TlsCipherSuite.TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384,
            System.Net.Security.TlsCipherSuite.TLS_ECDHE_ECDSA_WITH_CHACHA20_POLY1305_SHA256,
            System.Net.Security.TlsCipherSuite.TLS_ECDHE_RSA_WITH_CHACHA20_POLY1305_SHA256,
            System.Net.Security.TlsCipherSuite.TLS_DHE_RSA_WITH_AES_128_GCM_SHA256,
            System.Net.Security.TlsCipherSuite.TLS_DHE_RSA_WITH_AES_256_GCM_SHA384
        }
    );
    }
}
