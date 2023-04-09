using System.Text.Json.Serialization;

namespace Application.Features.Addresses.Commands.Add
{
    public class AddAddressCommandResponse<T>
    {
        public T Value { get; set; }
        [JsonIgnore] //Status codu dış dünyaya kapatıyoruz
        public int StatusCode { get; set; } // durum kodu
        public List<string> Errors { get; set; } //hataları tutuyoruz

        public static AddAddressCommandResponse<T> Success(int statusCode, T value)
        {
            return new AddAddressCommandResponse<T> { StatusCode = statusCode, Value = value };
        }
        //Geriye data dönmek zorunda değilsek sadece durum kodunu döneriz
        public static AddAddressCommandResponse<T> Success(int statusCode)
        {
            return new AddAddressCommandResponse<T> { StatusCode = statusCode };
        }
        public static AddAddressCommandResponse<T> Fail(int statusCode, List<string> errors)
        {
            return new AddAddressCommandResponse<T> { StatusCode = statusCode, Errors = errors };
        }
        public static AddAddressCommandResponse<T> Fail(int statusCode, string errors)
        {
            return new AddAddressCommandResponse<T> { StatusCode = statusCode, Errors = new List<string> { errors } };
        }
    }
    
}
