using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Application.DTOs.Test;

namespace TerraCloud.Application.Test
{
    public interface ITestMapping
    {
        Task<List<TestResponse>> ExecuteAsync();
    }
    internal class TestMapping(ITestMapper testMapper) : ITestMapping
    {
        public async Task<List<TestResponse>> ExecuteAsync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            var testClassList = GenerateMockList(10);
            //List<TestResponse> response = new();

            var response = await testMapper.MapListAsync(testClassList);

            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds:#,##0}ms elapsed.");
            
            return response;
        }

        private List<TestClass> GenerateMockList(int count)
        {
            List<TestClass> mockList = new List<TestClass>();
            Random random = new Random();
            string[] names = { "John", "Alice", "Bob", "Emma", "Michael", "Sophia" };
            string[] lastNames = { "Smith", "Johnson", "Brown", "Williams", "Davis" };

            for (int i = 0; i < count; i++)
            {
                mockList.Add(new TestClass
                {
                    Name = names[random.Next(names.Length)],
                    LastName = lastNames[random.Next(lastNames.Length)],
                    Age = random.Next(18, 80)
                });
            }

            return mockList;
        }
    }
}
