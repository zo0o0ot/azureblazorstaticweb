using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text.Json;
using Data;

namespace Api
{
    public class DraftsPost
    {
        private readonly IDraftData draftData;

        public DraftsPost(IDraftData draftData)
        {
            this.draftData = draftData;
        }

        [FunctionName("DraftsPost")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "drafts")] HttpRequest req,
            ILogger log)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var draft = JsonSerializer.Deserialize<Draft>(body, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            var newDraft = await draftData.AddDraft(draft);
            return new OkObjectResult(newDraft);
        }
    }
}
