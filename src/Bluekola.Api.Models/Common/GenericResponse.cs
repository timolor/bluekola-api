namespace Bluekola.Api.Models.Common
{
    public class GenericResponse<T> : ResponseBase 
    {
        public T data {get;set;}

        public GenericResponse(bool success, string message, T t){
            this.success = success;
            this.message = message;
            this.data = t;
        }
    }
}