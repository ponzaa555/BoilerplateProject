using System.Net;

namespace Application.Exceptions
{
    public class AuthenError : BaseException
    {
        public static AuthenError AU001 {get;} = new AuthenError(((int)HttpStatusCode.BadRequest) , "Not found username");
        public static AuthenError AU002 {get;} = new AuthenError(((int)HttpStatusCode.BadRequest) , "Duplicate username");
        public static AuthenError AU003 {get;} = new AuthenError(((int)HttpStatusCode.BadRequest) , "Username or password is incorrect");
        public AuthenError(int statusCode , string message) : base(statusCode , message)
        {

        }
        // ไว้ใช้ หน้่า Handler ใน business logic ใส่ path handler มา
        public AuthenError(AuthenError error , string errorAt) :base(error , errorAt)
        {
            
        }
    }
}