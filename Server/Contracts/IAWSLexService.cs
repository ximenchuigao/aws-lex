using Amazon.Lex.Model;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Server.Contracts
{
    public interface IAWSLexService
    {
        string PostContentToLex(string messageToSend);

        Task<PostTextResponse> SendTextMsgToLex(string messageToSend, Dictionary<string, string> lexSessionAttributes, string sessionId);

        Task<PostTextResponse> SendTextMsgToLex(string messageToSend, string sessionId);

        Task<Stream> SendAudioMsgToLex(Stream audioToSend);
    }
}
