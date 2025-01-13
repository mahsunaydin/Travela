using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travela.EntityLayer.Concrete
{
    public class UIGuide
    {
        [Key]
        public int GuideId { get; set; }
        public string GuideNameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Designation { get; set; }
        public string? facebookUrl { get; set; }
        public string? twitterUrl { get; set; }
        public string? instagramUrl { get; set; }
        public string? linkedinUrl { get; set; }
    }
}
