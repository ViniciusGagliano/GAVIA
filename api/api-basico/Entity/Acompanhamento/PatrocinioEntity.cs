using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PatrocinioEntity
    {
        public int Id { get; set; }
        public SeguradoraEntity Seguradora { get; set; }
        public RepresentanteEntity Representante { get; set; }
    }
}
