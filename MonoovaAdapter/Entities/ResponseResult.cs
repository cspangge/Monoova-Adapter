using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MonoovaAdapter.Entities
{
    class ResponseResult<T>
    {
        [JsonIgnore]
        public string RequestBody { get; set; }

        [JsonIgnore]
        public string ResponseText { get; set; }

        [JsonIgnore]
        public string Url { get; set; }

        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; }

        public ResponseError Errors { get; set; }

        [JsonProperty(PropertyName = "@total")]
        public int TotalObjectCount { get; set; }

        public T Data { get; set; }

        [JsonIgnore]
        public bool Success => Errors == null;

        [JsonIgnore]
        public string ErrorCode => Errors != null ? Errors.Code : "";

        [JsonIgnore]
        public string ErrorMessage => Errors != null ? Errors.Message : "";
    }

    internal class ResponseError
    {
        public string Code { get; set; }

        public string Message { get; set; }
    }
}
