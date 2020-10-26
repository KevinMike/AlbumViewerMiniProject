using AlbumViewerMiniProject.Infraestructure;
using AlbumViewerMiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumViewerMiniProject.Integration
{
    interface ICommentClient
    {
        Task<List<Comment>> GetComments();
    }
    public class CommentClient : ICommentClient
    {
        private readonly IRestProvider _restProvider = new RestProvider(Global.CommentEndpoint);

        public async Task<List<Comment>> GetComments()
        {
            return await _restProvider.AsyncSendRequest<List<Comment>>();
        }
    }
}
