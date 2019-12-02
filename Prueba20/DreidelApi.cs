using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace Prueba25
{
    //https://25daysofserverless.azurewebsites.net/calendar/1
    public static class DreidelApi
    {
        [FunctionName("GetDreidel")]
        public static IActionResult GetDreidel(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route="dreidel")]
            HttpRequest req, ILogger log)
        {            
            var salutations = new string[] { "Nun", "Gimmel", "Hay", "Shin" };
            try
            {
                log.LogInformation("Retrieving the Dreidel");
                var rnd = new Random(System.DateTime.Now.Millisecond);
                var indexSalutation = rnd.Next(0, 4);
                var salutation = salutations[indexSalutation];
                return new OkObjectResult(salutation);
            }
            catch (Exception ex)
            {
                log.LogError(ex, ex.Message);
                return new BadRequestResult();                
            }
            
            
        }

    }
}
