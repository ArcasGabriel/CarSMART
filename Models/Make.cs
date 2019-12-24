using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace DotNetAngularApp.Models
{
    public class Make
    {
        public int Id { get; set; } 

        [StringLength(255)]
        [Required]
        public string Name { get; set; } 

        public IList<Model> Models { get; set; }  

        public Make()
        {
            Models = new List<Model>();
        }

    }
}