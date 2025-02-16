using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TerraCloud.Application.DTOs.Test;

namespace TerraCloud.Application.Test
{
    public interface ITestMapper
    {
        Task<TestResponse> MapAsync(TestClass test);
        Task<List<TestResponse>> MapListAsync(List<TestClass> testList);
    }

    internal class TestMapper : ITestMapper
    {
        public async Task<TestResponse> MapAsync(TestClass test)
        {
            await Task.Delay(1000); // Symulacja opóźnienia asynchronicznego
            return new TestResponse
            {
                Name = test.Name,
                LastName = test.LastName,
                Age = test.Age
            };
        }

        public async Task<List<TestResponse>> MapListAsync(List<TestClass> testList)
        {
            var tasks = testList.Select(MapAsync);
            var results = await Task.WhenAll(tasks);
            return results.ToList();
        }
    }
}