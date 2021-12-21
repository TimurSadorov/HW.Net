using System.Net.Http;
using System.Text;
using JetBrains.dotMemoryUnit;
using Microsoft.Extensions.Hosting;
using Xunit;
using Xunit.Abstractions;
using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace Homework13Calculator.Tests
{
    public class TestMemory : IClassFixture<Microsoft.Extensions.Hosting.HostBuilder>
    {
        private readonly HttpClient _client;
        private ITestOutputHelper _output;

        public TestMemory(ITestOutputHelper output)
        {
            _output = output;
            DotMemoryUnitTestOutput.SetOutputMethod(_output.WriteLine);
            _client = new HostBuilder().CreateClient();
        }

        [Fact]
        [DotMemoryUnit(FailIfRunWithoutSupport = true,CollectAllocations = true)]
        public void TestMemoryAsync()
        {
            var memoryPoint = dotMemory.Check();
            long size = 0;
            for (var i = 0; i < 10000000; i++)
            {
                var expression = $"{i}+{i}";
                size += Encoding.UTF8.GetBytes(expression).Length;
                SendRequest(expression);
            }

            dotMemory.Check(
                memory =>
                {
                    _output.WriteLine(memory.GetTrafficFrom(memoryPoint).CollectedMemory.SizeInBytes.ToString());
                    _output.WriteLine(size.ToString());
                    Assert.True(memory.GetTrafficFrom(memoryPoint).CollectedMemory.SizeInBytes >= size);
                });
        }

        private void SendRequest(string expression)
        {
            var stringContent = new StringContent($"expression={expression}", Encoding.UTF8);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            _client.PostAsync("https://localhost:5001/Calculator/Calculate", stringContent).GetAwaiter().GetResult();
        }
    }
}