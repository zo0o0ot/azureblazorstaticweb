using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class DraftsDelete
    {
        private readonly IDraftData draftData;

        public DraftsDelete(IDraftData draftData)
        {
            this.draftData = draftData;
        }

        [FunctionName("DraftsDelete")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "drafts/{draftId:int}")] HttpRequest req,
            int draftId,
            ILogger log)
        {
            var result = await draftData.DeleteDraft(draftId);

            if (result)
            {
                return new OkResult();
            }
            else
            {
                return new BadRequestResult();
            }
        }
    }
}
