using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class ArticuloCarrito
    {
        public int Id { get; set; }

        public int Cant { get; set; }

        public string Titulo { get; set; }
        public string Img { get; set; }
        public SqlMoney Precio { get; set; }

    }
}
