using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using MonoovaAdapter.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MonoovaAdapter.Utilities
{
    class ApiClient
    {
        private readonly ProviderParam param;
        public ApiClient(ProviderParam param)
        {
            this.param = param;
        }

        private string GetAuthorization()
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(param.Username + ":" + param.Password);
            var authenticationValue = Convert.ToBase64String(plainTextBytes);
            return authenticationValue;
        }

        private HttpClient GetHttpClient()
        {
            var client = new HttpClient { BaseAddress = new Uri(param.BaseUrl) };
            var authorization = this.GetAuthorization();

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Basic",
                    authorization);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private async Task<ResponseResult<T>> ResponseJson<T>(ResponseResult<T> result, Task<HttpResponseMessage> response)
        {
            result.StatusCode = response.Result.StatusCode;
            var contents = await response.Result.Content.ReadAsStreamAsync();
            //Setting Up the Stream Reader  
            var readerStream = new StreamReader(contents, Encoding.GetEncoding("utf-8"));
            //Get in a string  
            var json = await readerStream.ReadToEndAsync();
            result.ResponseText = json;
            //Close the Stream  
            readerStream.Close();
            return result;
        }

        public async Task<ResponseResult<T>> Get<T>(string url)
        {
            var response = new ResponseResult<T> {Url = url};
            var clientResponse = GetHttpClient().GetAsync(url);
            clientResponse.Wait();
            response = await ResponseJson(response, clientResponse);
            return response;
        } 
        
        public async Task<ResponseResult<T>> Post<T>(string url, HttpContent content)
        {
            var response = new ResponseResult<T> {Url = url};
            var clientResponse = GetHttpClient().PostAsync(url, content);
            clientResponse.Wait();
            response = await ResponseJson(response, clientResponse);
            return response;
        } 
        
        public async Task<ResponseResult<T>> PostBatch<T>(string url, HttpContent content)
        {
            var response = new ResponseResult<T> {Url = url};
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            var clientResponse = GetHttpClient().PostAsync(url, content);
            clientResponse.Wait();
            response = await ResponseJson(response, clientResponse);
            return response;
        } 
        
        public async Task<ResponseResult<T>> Delete<T>(string url)
        {
            var response = new ResponseResult<T> {Url = url};
            var clientResponse = GetHttpClient().DeleteAsync(url);
            clientResponse.Wait();
            response = await ResponseJson(response, clientResponse);
            return response;
        } 
    }
}
