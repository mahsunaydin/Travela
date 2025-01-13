using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travela.EntityLayer.Concrete
{
    public class UITestimonial
    {
        [Key]
        public int TestimonialId { get; set; }
        public string NameSurname { get; set; }
        public string Comment { get; set; }
        public string CommenterLocation { get; set; }
        public string ImageUrl { get; set; }
        public int CountStar { get; set; }
        public string Country { get; set; }
    }
}
