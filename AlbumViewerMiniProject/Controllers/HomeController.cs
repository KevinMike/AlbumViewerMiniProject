using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AlbumViewerMiniProject.Models;
using AlbumViewerMiniProject.Integration;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlbumViewerMiniProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAlbumClient _albumClient = new AlbumClient();
        private readonly IPhotoClient _photoClient = new PhotoClient();
        private readonly ICommentClient _commentClient = new CommentClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        // GET: Home
        public async Task<IActionResult> Index()
        {
            var albums = await _albumClient.GetAlbums();
            var retVal  = albums.Select(p => new SelectListItem { Text = p.Title, Value = p.Id.ToString() })
                            .ToList();
            return View(retVal);
        }

        // GET: Home/Photos/albumId
        public async Task<IActionResult> Photos(int id)
        {
            var photos = await _photoClient.GetPhotos();
            photos = photos.Where(p => p.AlbumId == id).ToList();
            return PartialView(photos);
        }

        // GET: Home/Comments/PostId
        public async Task<IActionResult> Comments(int id)
        {
            var comments = await _commentClient.GetComments();
            comments = comments.Where(p => p.PostId == id).ToList();
            return PartialView(comments);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
