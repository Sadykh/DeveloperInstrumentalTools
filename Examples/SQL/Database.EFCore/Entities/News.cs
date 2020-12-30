using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    [Table("news")]
    public class News
    {
        public int Id { get; set; }

        public User User { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Title { get; set; }
    }
}