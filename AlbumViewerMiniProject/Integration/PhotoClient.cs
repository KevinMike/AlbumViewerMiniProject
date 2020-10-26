using AlbumViewerMiniProject.Infraestructure;
using AlbumViewerMiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumViewerMiniProject.Integration
{
    interface IPhotoClient
    {
        Task<List<Photo>> GetPhotos();
    }
    public class PhotoClient : IPhotoClient
    {
        private readonly IRestProvider _restProvider = new RestProvider(Global.PhotoEndpoint);

        public async Task<List<Photo>> GetPhotos()
        {
            return await _restProvider.AsyncSendRequest<List<Photo>>();
        }
    }
}
