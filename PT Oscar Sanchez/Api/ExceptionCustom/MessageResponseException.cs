namespace Api
{
    public class MessageResponseException
    {
        public string Message { get; set; }

        public MessageResponseException(string message)
        {
            this.Message = message;
        }
    }
}
