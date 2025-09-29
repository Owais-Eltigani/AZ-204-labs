// Standard .NET namespaces for HTTP status codes
using System.Net;
// Azure Functions Worker SDK - NEW isolated worker model (v4+)
using Microsoft.Azure.Functions.Worker;
// HTTP-specific types for Azure Functions Worker
using Microsoft.Azure.Functions.Worker.Http;
// Dependency injection logging interface
using Microsoft.Extensions.Logging;
// Modern JSON serialization (System.Text.Json instead of Newtonsoft.Json)
using System.Text.Json;

namespace Company.Function
{
    // Regular C# class - no inheritance needed in isolated worker model
    public class HttpTrigger1
    {
        // Private readonly field for dependency-injected logger
        private readonly ILogger _logger;

        // Constructor injection - Azure Functions DI container will provide ILoggerFactory
        // This is the modern way to get loggers (instead of passing ILogger directly to function methods)
        public HttpTrigger1(ILoggerFactory loggerFactory)
        {
            // Create a logger specifically for this class type
            _logger = loggerFactory.CreateLogger<HttpTrigger1>();
        }

        // [Function] ATTRIBUTE: Registers this method as an Azure Function
        // - "HttpTrigger1" is the function name (shown in Azure portal and func command)
        // - This replaces the old [FunctionName] attribute from in-process model
        [Function("HttpTrigger1")]
        // async Task<HttpResponseData>: Returns HTTP response data asynchronously
        // HttpResponseData is the new response type (replaces old IActionResult)
        public async Task<HttpResponseData> Run(
            // [HttpTrigger] ATTRIBUTE: Configures HTTP trigger binding
            // - AuthorizationLevel.Function: Requires function key for access
            // - "get", "post": Allowed HTTP methods
            // HttpRequestData: New request type (replaces old HttpRequest)
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            // Log information using injected logger
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // Create HTTP response with 200 OK status
            // req.CreateResponse() is the new way to create responses
            var response = req.CreateResponse(HttpStatusCode.OK);
            // Set response content type header
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            // Extract 'name' parameter from query string
            // req.Query is the new way to access query parameters
            string? name = req.Query["name"];

            // Check if request has a body (for POST requests)
            if (req.Body != null)
            {
                // using var: C# 8+ feature - automatically disposes StreamReader
                using var reader = new StreamReader(req.Body);
                // Read entire request body as string asynchronously
                string requestBody = await reader.ReadToEndAsync();
                
                // Process JSON body if present
                if (!string.IsNullOrEmpty(requestBody))
                {
                    try
                    {
                        // System.Text.Json deserialization (modern, faster than Newtonsoft.Json)
                        // Deserialize to Dictionary<string, object> for flexible JSON handling
                        var data = JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                        // Check if JSON contains 'name' property
                        if (data != null && data.ContainsKey("name"))
                        {
                            // ?. null-conditional operator: safe navigation
                            // Extract name value and convert to string
                            name = data["name"]?.ToString();
                        }
                    }
                    catch (JsonException)
                    {
                        // Silently ignore malformed JSON - function continues
                    }
                }
            }

            // Conditional (ternary) operator: condition ? value_if_true : value_if_false
            // $"string interpolation" - C# 6+ feature for embedding variables in strings
            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            // Write response body asynchronously
            // New pattern: WriteStringAsync instead of old response.WriteAsync
            await response.WriteStringAsync(responseMessage);
            // Return the response object
            return response;
        }
    }
}
