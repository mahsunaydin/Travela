using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travela.EntityLayer.Concrete
{
    public class PageHeaderDeatil
    {
        [Key]
        public int PageHeaderId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? PageTitle { get; set; }
    }
}
