using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace MonoovaAdapter.Utilities
{
    public static class ResponseHandler
    {
        public static async Task<string> ResponseJson(HttpResponseMessage response)
        {
            var contents = await response.Content.ReadAsStreamAsync();
            //Setting Up the Stream Reader  
            var readerStream = new StreamReader(contents, System.Text.Encoding.GetEncoding("utf-8"));
            //Get in a string  
            var json = await readerStream.ReadToEndAsync();
            //Close the Stream  
            readerStream.Close();
            return json;
        }
    }
}
