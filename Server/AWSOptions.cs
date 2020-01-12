namespace Server
{
    public class AWSOptions
    {
        public string CognitoPoolID { get; set; }
        public string LexBotName { get; set; }

        public string LexRole { get; set; }

        public string LexBotAlias { get; set; }

        public string BotRegion { get; set; }
    }
}
