using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travela.EntityLayer.Concrete
{
    public class UIFeature
    {
        [Key]
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public string Title2 { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
