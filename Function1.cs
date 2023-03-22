using AzureFunctionDemo.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace AzureFunctionDemo
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "validateEmail")] HttpRequest req)
        {
            string email = req.Query["email"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            dynamic data = JsonConvert.DeserializeObject(requestBody);

            email ??= data?.Email;

            string responseMessage;

            if (!string.IsNullOrEmpty(email))
            {
                var validationResult = EmailValidation.ValidateEmail(email);

                if (validationResult)
                    responseMessage = $"\"{email}\" address is a valid address.";
                else
                    responseMessage = "Invalid email address";
            }
            else
                responseMessage = "Invalid email address";

            return new OkObjectResult(responseMessage);
        }

        
    }
}
