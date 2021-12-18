using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Homework10.DbModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;
using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace Homework10.Tests
{
    public class HostBuilder : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<Startup>()
                    .UseTestServer())
                .ConfigureServices(a => a.AddDbContext<ApplicationContext>());
    }

    public class IntegrationCalculatorControllerTests : IClassFixture<HostBuilder>
    {
        private readonly HttpClient client;
        private readonly string successString = "Result: ";
        private readonly string errorString = "Error: ";

        public IntegrationCalculatorControllerTests(HostBuilder fixture)
        {
            client = fixture.CreateClient();
        }

        [Theory]
        [InlineData("2 %2B 3", "5")]
        [InlineData("(10 - 3) * 2", "14")]
        [InlineData("3 - 4 / 2", "1")]
        [InlineData("8 * (2 %2B 2) - 3 * 4", "20")]
        [InlineData("10 - 3 * (-4)", "22")]
        public async Task Calculate_CalculateExpression_Success(string expression, string result)
        {
            await MakeTest(expression, result, successString);
        }
        
        [Theory]
        [InlineData("", "Empty string")]
        [InlineData("10 + i", "Unknown character i")]
        [InlineData("3 - 4 / 2.2.3", "There is no such number 2.2.3")]
        [InlineData("2 - 2.23.1 - 23", "There is no such number 2.23.1")]
        [InlineData("(20 - 2.3.4) * 2", "There is no such number 2.3.4")]
        [InlineData("8 %2B 34 - / 2", "There are two operations in a row - and /")]
        [InlineData("4 - 10 * (/10 %2B 2)", "After the opening brackets, only negation can go: (/")]
        [InlineData("10 - 2 * (10 - 1 /)", "There is only a number before the closing parenthesis /)")]
        public async Task Calculate_CalculateExpression_Error(string expression, string result)
        {
            await MakeTest(expression, result, errorString);
        }

        private async Task MakeTest(string expression, string result, string successOrError)
        {
            var stringContent = new StringContent($"expression={expression}", Encoding.UTF8);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var response = await client.PostAsync("https://localhost:5001/Calculator/Calculate", stringContent);
            var output = await response.Content.ReadAsStringAsync();

            Assert.Equal(successOrError + result, FindResult(output));
        }

        private async Task<long> GetRequestExecutionTime(StringContent stringContent)
        {
            var watch = new Stopwatch();
            watch.Start();
            var response = await client.PostAsync("https://localhost:5001/Calculator/Calculate", stringContent);
            watch.Stop();
            var result = watch.ElapsedMilliseconds;
            return result;
        }


        private string FindResult(string html)
        {
            return html.Split("<span id=\"response\" class=\"mt-3\">")[1].Split("</span>")[0];
        }
    }
}