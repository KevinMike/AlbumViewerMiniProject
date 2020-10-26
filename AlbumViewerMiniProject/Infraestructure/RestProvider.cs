using Newtonsoft.Json;
using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlbumViewerMiniProject.Infraestructure
{ 
    interface IRestProvider
    {
        Task<T> AsyncSendRequest<T>() where T : new();
    }
    public class RestProvider : IRestProvider
    {

        private readonly HttpClient _client;
        private readonly string _baseUrl;

        public RestProvider(string baseUrl)
        {
            _client = new HttpClient();
            _baseUrl = baseUrl;
        }

        public async Task<T> AsyncSendRequest<T>() where T : new()
        {
            var response = await _client.GetAsync(this._baseUrl);
            if(!response.IsSuccessStatusCode)
            {
                this.HandleOtherResponses(response);
            }
            var retVal = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            return retVal;
        }

        private void HandleOtherResponses(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.OK) return;
            if (response.StatusCode == HttpStatusCode.NoContent) throw new DataException();
            if (response.StatusCode == HttpStatusCode.NotFound) throw new DataException();
            if (response.StatusCode == HttpStatusCode.InternalServerError) throw new ApplicationException();
            if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }

            throw new Exception("Not Controlled Exception");
        }

    }
}