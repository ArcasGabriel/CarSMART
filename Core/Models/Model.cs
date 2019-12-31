using System.ComponentModel.DataAnnotations;

namespace DotNetAngularApp.Core.Models
{
    public class Model
    {

        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public Make Make {get;set;}

        public int MakeId { get; set; }
    }
}