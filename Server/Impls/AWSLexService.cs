using Amazon.CognitoIdentity;
using Server.Contracts;
using System.Collections.Generic;
using Amazon;
using Amazon.Lex;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;
using Amazon.Lex.Model;

namespace Server.Impls
{
    public class AWSLexService : IAWSLexService
    {
        private readonly AWSOptions _awsOptions;
        private Dictionary<string, string> _lexSessionAttribs;

        private CognitoAWSCredentials awsCredentials;
        private AmazonLexClient awsLexClient;
        public AWSLexService(IOptions<AWSOptions> awsOptions)
        {
            _awsOptions = awsOptions.Value;
            InitLexService();
        }
        protected void InitLexService()
        {
            RegionEndpoint svcRegionEndpoint;

            //Grab region for Lex Bot services
            svcRegionEndpoint = RegionEndpoint.GetBySystemName(_awsOptions.BotRegion);

            //Get credentials from Cognito
            awsCredentials = new CognitoAWSCredentials(
                                _awsOptions.CognitoPoolID, // Identity pool ID
                                svcRegionEndpoint); // Region

            //Instantiate Lex Client with Region
            awsLexClient = new AmazonLexClient(awsCredentials, svcRegionEndpoint);
        }

        public async Task<string> PostToLex(string messageToSend)
        {
            throw new NotImplementedException();
        }

        public async Task<PostTextResponse> SendTextMsgToLex(string messageToSend, Dictionary<string, string> lexSessionAttributes, string sessionId)
        {
            _lexSessionAttribs = lexSessionAttributes;
            return await SendTextMsgToLex(messageToSend, sessionId);

        }
        public async Task<PostTextResponse> SendTextMsgToLex(string messageToSend, string sessionId)
        {
            PostTextResponse lexTextResponse;
            PostTextRequest lexTextRequest = new PostTextRequest()
            {
                BotAlias = _awsOptions.LexBotAlias,
                BotName = _awsOptions.LexBotName,
                UserId = sessionId,
                InputText = messageToSend,
                SessionAttributes = _lexSessionAttribs
            };

            try
            {
                lexTextResponse = await awsLexClient.PostTextAsync(lexTextRequest);
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex);
            }

            return lexTextResponse;
        }

        /**
         * Later to Implement receiving Voice input for the Lex Bot
         * with Amazon Lex PostContent and Streams
         * **/
        public Task<Stream> SendAudioMsgToLex(Stream audioToSend)
        {
            throw new NotImplementedException();
        }

        public string PostContentToLex(string messageToSend)
        {
            throw new NotImplementedException();
        }
    }
}
