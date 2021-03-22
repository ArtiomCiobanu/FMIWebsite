using System;

namespace NewsWebsiteAPI.Infrastructure.Models.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }
        //public DateTime Date { get; set; }
    }
}