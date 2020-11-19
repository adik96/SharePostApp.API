using System;
using System.Collections.Generic;
using System.Text;

namespace SharePostApp.INFRASTRUCTURE.DTOs
{
    public class PostDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public string Author { get; set; }
    }
}
