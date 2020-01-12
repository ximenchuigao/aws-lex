using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelperController : ControllerBase
    {
        private readonly IAWSLexService awsLexSvc;
        private ISession userHttpSession;
        private Dictionary<string, string> lexSessionData;
        private List<ChatBotMessage> botMessages;
        private string botMsgKey = "ChatBotMessages",
                       botAtrribsKey = "LexSessionData",
                       userSessionID = String.Empty;

        public HelperController(IAWSLexService awsLexService) 
        {
            awsLexSvc = awsLexService;
        }

        [HttpGet]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<List<ChatBotMessage>> GetChatMessage(string userMessage)
        {
            //Get user session and chat info
            userHttpSession = HttpContext.Session;
            userSessionID = userHttpSession.Id;
            //botMessages = userHttpSession<List<ChatBotMessage>>(botMsgKey) ?? new List<ChatBotMessage>();
           // lexSessionData = userHttpSession.Get<Dictionary<string, string>>(botAtrribsKey) ?? new Dictionary<string, string>();

            //No message was provided, return to current view
            if (String.IsNullOrEmpty(userMessage)) return botMessages;

            //A Valid Message exists, Add to page and allow Lex to process
            botMessages.Add(new ChatBotMessage()
            { MsgType = MessageType.UserMessage, ChatMessage = userMessage });

            //await postUserData(botMessages);

            //Call Amazon Lex with Text, capture response
            //var lexResponse = await awsLexSvc.SendTextMsgToLex(userMessage, lexSessionData, userSessionID);

            //lexSessionData = lexResponse.SessionAttributes;
            //botMessages.Add(new ChatBotMessage()
            //{ MsgType = MessageType.LexMessage, ChatMessage = lexResponse.Message });

            //Add updated botMessages and lexSessionData object to Session
            //userHttpSession.Set<List<ChatBotMessage>>(botMsgKey, botMessages);
            //userHttpSession.Set<Dictionary<string, string>>(botAtrribsKey, lexSessionData);

            return botMessages;
        }
    }
}
