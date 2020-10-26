using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumViewerMiniProject.Models
{
    public class Comment
    {
        public int PostId  { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
    }
}
