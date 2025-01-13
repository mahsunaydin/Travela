using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travela.EntityLayer.Concrete
{
    public class UIAbout
    {
        [Key]
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string SubTitle1 { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
