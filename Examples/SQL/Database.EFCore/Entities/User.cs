using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    [Table("user")]
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}