using System.ComponentModel.DataAnnotations.Schema;

namespace NewsWebsiteAPI.Infrastructure.Models.Entities
{
    //[Table("Posts")]
    public class Post : BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }
        //public DateTime Date { get; set; }
    }
}