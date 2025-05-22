namespace Application.Exceptions
{
    public abstract class BaseException : Exception
    {
        public int StatusCode {get; }
        public string ErrorAt {get; } = null!;
        public string AddNote {get; } = "";
        
        protected BaseException( int statusCode , string message ) :base(message) 
        {
            StatusCode = statusCode;
        }
        protected BaseException( int statusCode , string message , string errorAt) :base(message) 
        {
            StatusCode = statusCode;
            ErrorAt = errorAt;   
        }

         protected BaseException( int statusCode , string message , string errorAt , string note) :base(message) 
        {
            StatusCode = statusCode;
            ErrorAt = errorAt;   
            AddNote = note;
        }
        protected BaseException(BaseException baseException , string errorAt) : base(baseException.Message)
        {
            StatusCode = baseException.StatusCode;
            ErrorAt = errorAt;
            AddNote = baseException.AddNote;
        }
    }
}