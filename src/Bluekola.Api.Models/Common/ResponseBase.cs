namespace Bluekola.Api.Models.Common
{
    public abstract class ResponseBase 
    {
        public static string SUCCESSFUL = "Completed Successfully";
        public static string FAILED = "Failed!";
        public static string ERROR = "Error processing request";
        public bool success {get; set;}
        public string message {get; set;}
    }
}