using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace Api
{
    public class DraftsGet
    {
        private readonly IDraftData draftData;

        public DraftsGet(IDraftData draftData)
        {
            this.draftData = draftData;
        }

        [FunctionName("DraftsGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "drafts")] HttpRequest req)
        {
            var drafts = await draftData.GetDrafts();
            return new OkObjectResult(drafts);
        }
    }
}