namespace Tasnim.Domain.Common
{
    public class ErrorModel
    {
        public ErrorModel(int? code, string message)
        {
            Code = code;
            Message = message;
        }
        public int? Code { get; set; }
        public string Message { get; set; }
    }
}
