using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travela.EntityLayer.Concrete
{
    public class UIAboutFeature
    {
        [Key]
        public int AboutFeatureId { get; set; }
        public string Description { get; set; }
    }
}
