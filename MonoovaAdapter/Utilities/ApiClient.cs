using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MonoovaAdapter.Entities;

namespace MonoovaAdapter.Utilities
{
    class ApiClient
    {
        private readonly ProviderParam _param;
        public ApiClient(ProviderParam param)
        {
            this._param = param;
        }

        private string GetAuthorization()
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(_param.Username + ":" + _param.Password);
            var authenticationValue = Convert.ToBase64String(plainTextBytes);
            return authenticationValue;
        }

        private HttpClient GetHttpClient()
        {
            var client = new HttpClient { BaseAddress = new Uri(_param.BaseUrl) };
            var authorization = this.GetAuthorization();

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Basic",
                    authorization);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private static async Task<ResponseResult<T>> ResponseJson<T>(ResponseResult<T> result, Task<HttpResponseMessage> response)
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
        
        public async Task<Stream> GetFile<T>(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(_param.BaseUrl + url);
            response.Wait();
            Console.WriteLine(response.Result.Content.Headers);
            var stream = await response.Result.Content.ReadAsStreamAsync();
            return stream;
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
