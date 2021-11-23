namespace WebApplication.Services
{
    public class Result<TSuccess, TError>
    {
        public readonly TypeResult Type;
        public readonly TSuccess Success;
        public readonly TError Error;

        public Result(TSuccess success)
        {
            Type = TypeResult.Success;
            Success = success;
        }
        
        public Result(TError error)
        {
            Type = TypeResult.Error;
            Error = error;
        }
    }

    public enum TypeResult
    {
        Success,
        Error
    }
}