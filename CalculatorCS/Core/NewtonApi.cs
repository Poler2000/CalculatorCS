using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CalculatorCS.Core
{
    public class NewtonApi 
    {
        private static readonly HttpClient Client = new HttpClient();
        private const string BaseAddress = "https://newton.vercel.app/api/v2/";

        public static async Task<Result> IssueCalculation(string expression, string operation)
        {
            expression = MathParser.Encode(expression);
            var resultStream = Client.GetStreamAsync(BaseAddress + operation + '/' + expression);
            var result = await JsonSerializer.DeserializeAsync<Result>(await resultStream);
            return result;
        }
    }
}