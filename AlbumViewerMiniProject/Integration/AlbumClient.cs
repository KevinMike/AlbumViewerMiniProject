using AlbumViewerMiniProject.Infraestructure;
using AlbumViewerMiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumViewerMiniProject.Integration
{
    interface IAlbumClient
    {
        Task<List<Album>> GetAlbums();
    }

    public class AlbumClient : IAlbumClient
    {
        private readonly IRestProvider _restProvider = new RestProvider(Global.AlbumEndpoint);
        public async Task<List<Album>> GetAlbums()
        {
            return await _restProvider.AsyncSendRequest<List<Album>>();
        }
    }
}
