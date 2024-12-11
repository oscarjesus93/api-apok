using System.Net;

namespace Api
{
    public class ExceptionCustom : Exception
    {
        public HttpStatusCode code { get; set; }

        public ExceptionCustom(string message, HttpStatusCode code) : base(message) 
        {
            this.code = code;
        }
    }
}
