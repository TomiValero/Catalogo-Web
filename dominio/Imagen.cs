using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {
        public int ID { get; set; }
        public string ImagenUrl { get; set; }
        public int IDArticulo { get; set; }
    }
}
