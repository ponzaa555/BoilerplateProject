using System.Net;

namespace Application.Exceptions
{
    public class AuthenError : BaseException
    {
        public static AuthenError AU001 {get;} = new AuthenError(((int)HttpStatusCode.BadRequest) , "Not found username");
        public AuthenError(int statusCode , string message , string errorAt) : base(statusCode,message,errorAt)
        {
            
        }
        public AuthenError(int statusCode , string message) : base(statusCode , message)
        {

        }
        public AuthenError(AuthenError error , string errorAt) :base(error , errorAt)
        {

        }
    }
}