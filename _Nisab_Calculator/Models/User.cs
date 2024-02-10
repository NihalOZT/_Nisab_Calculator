using System.ComponentModel.DataAnnotations.Schema;

namespace _Nisab_Calculator.Models
{
    [Table("TBL_Users", Schema = "dbo")]
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }    
        public List<Comment> comments { get; set; }
    }
}
