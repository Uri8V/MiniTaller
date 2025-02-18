using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTaller.Entidades.Dtos
{
    public class ImagenesDto
    {

        [DisplayName("Imagen")]
        public string imageURL { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
