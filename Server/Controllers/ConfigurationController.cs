using Microsoft.AspNetCore.Mvc;
using Server.Contracts;

namespace Server.Controllers
{
    public class ConfigurationController : ControllerBase
    {
        private readonly IAWSLexService awsLexSvc;

        public ConfigurationController(IAWSLexService awsLexService)
        {
            awsLexSvc = awsLexService;
        }

        
    }
}
