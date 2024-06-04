using System.Text.Json.Serialization;

namespace Fina.Core.Response
{
    public class Response<TData>
    {
        //HTTP Status
        private int _code = Configuration.DefaultStatusCode;
        public TData? Data {get; set;}
        public string? Message {get; set;}
        [JsonConstructor]
        public Response() => _code = Configuration.DefaultStatusCode;

        public Response(
            TData? data,
            int code = Configuration.DefaultStatusCode, 
            string? message =  null
            ){
                Data = data;
                Message = message;
                _code = code;
        }   

        [JsonIgnore]
        public bool IsSucessul => _code is >= 200 and <= 299;
    }
}
